using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Data;
using System.Xml;
using System.Xml.XPath;

using System.Text.RegularExpressions;

using System.Diagnostics;
using System.Drawing;

namespace MediaSync.Media.Movie
{
    public class Asset : MediaSync.Asset
    {

        public Asset(string assetLocation)
        {

            this.Directory = new FileInfo(assetLocation);
            this.Title = this.Directory.Directory.Name;

            string posterPath = this.Directory.Directory + "\\folder.jpg";

            if (File.Exists(posterPath))
            {
                this.Poster = Image.FromFile(posterPath);
            }
           

        }

        public override void Sync()
        {

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Before we go any further, check to make sure the nfo File isnt malformed.
            try
            {
                XPathDocument docNav = new XPathDocument(this.Directory.ToString());
            }
            catch
            {
                // If its bad looking, meh.
                return;
            }

            DirectoryInfo nfoDirectory = this.Directory.Directory;

            string fullMovieName = this.Directory.Name.Replace(".nfo", "");
            string shortMovieName = fullMovieName.Replace("-", "").Replace(" ", "_").Replace("'", "").Replace("&", "_");
            shortMovieName = shortMovieName.Replace(".", "").Replace("(", "").Replace(")", "").Replace("__", "");
            shortMovieName = shortMovieName.Replace(",", "");

            // Copy the poster JPG if we can.
            if (File.Exists(nfoDirectory + "\\folder.jpg"))
            {

                string newFolderImage = appDataPath + "\\Microsoft\\eHome\\DvdCoverCache\\" + shortMovieName + ".jpg";

                if (File.Exists(newFolderImage))
                {
                    File.Delete(newFolderImage);
                }

                ImageResize imageResize = new ImageResize(nfoDirectory + "\\folder.jpg");
                // imageResize.Resize(newFolderImage, 230, 320, true);
                imageResize.Resize(newFolderImage, 130, 120, true);

            }

            // Delete source XML file if it exists.
            string soureXMLFile = nfoDirectory + "\\" + fullMovieName + ".xml";

            if (File.Exists(soureXMLFile))
            {
                File.Delete(soureXMLFile);
            }

            // Create local source XML file.
            XmlDocument xmlDoc = ConvertNFOToXML(fullMovieName, shortMovieName);
            xmlDoc.Save(soureXMLFile);

            // Delete XML file in DvdInfoCache if it exits.

            string cachedXMLFile = appDataPath + "\\Microsoft\\eHome\\DvdInfoCache\\" + fullMovieName + ".xml";

            if (File.Exists(cachedXMLFile))
            {
                File.Delete(cachedXMLFile);
            }

            // Copy local source XML file to Dvd Info Cache
            File.Copy(soureXMLFile, cachedXMLFile);

            // Delete local .dvdid XML file if it exists.
            string localDvdIDFile = nfoDirectory + "\\" + fullMovieName + ".dvdid.xml";

            if (File.Exists(localDvdIDFile))
            {
                File.Delete(localDvdIDFile);
            }

            // Create local .dvdid XML file if it exists.

            TextWriter dvdIdStream = new StreamWriter(localDvdIDFile);
            dvdIdStream.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            dvdIdStream.WriteLine("<DISC>");
            dvdIdStream.WriteLine("  <NAME>" + fullMovieName + "</NAME>");
            dvdIdStream.WriteLine("  <ID>" + fullMovieName + "</ID>");
            dvdIdStream.WriteLine("</DISC>");
            dvdIdStream.Close();

        }

        public XmlDocument ConvertNFOToXML(string fullMovieName, string shortMovieName)
        {

            MovieNFODocument nfoDocument = new MovieNFODocument(this.Directory.ToString());

            // Create the new document.
            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);

            XmlElement metaData = xmlDoc.CreateElement("METADATA");
            xmlDoc.AppendChild(metaData);

            XmlElement mdrDvd = xmlDoc.CreateElement("MDR-DVD");
            metaData.AppendChild(mdrDvd);

            XmlElement version = xmlDoc.CreateElement("version");
            version.AppendChild(xmlDoc.CreateTextNode("5.0"));
            mdrDvd.AppendChild(version);

            XmlElement dvdTitle = xmlDoc.CreateElement("dvdTitle");
            dvdTitle.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Title));
            mdrDvd.AppendChild(dvdTitle);

            XmlElement studio = xmlDoc.CreateElement("studio");
            studio.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Studio));
            mdrDvd.AppendChild(studio);

            XmlElement leadPerformer = xmlDoc.CreateElement("leadPerformer");
            mdrDvd.AppendChild(leadPerformer);

            XmlElement director = xmlDoc.CreateElement("director");
            director.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Director));
            mdrDvd.AppendChild(director);

            XmlElement mpaaRating = xmlDoc.CreateElement("MPAARating");
            mpaaRating.AppendChild(xmlDoc.CreateTextNode(nfoDocument.MPAARating));
            mdrDvd.AppendChild(mpaaRating);

            XmlElement largeCoverParams = xmlDoc.CreateElement("largeCoverParams");
            largeCoverParams.AppendChild(xmlDoc.CreateTextNode(shortMovieName + ".jpg"));
            mdrDvd.AppendChild(largeCoverParams);

            XmlElement smallCoverParams = xmlDoc.CreateElement("smallCoverParams");
            smallCoverParams.AppendChild(xmlDoc.CreateTextNode(shortMovieName + ".jpg"));
            mdrDvd.AppendChild(smallCoverParams);

            XmlElement language = xmlDoc.CreateElement("language");
            mdrDvd.AppendChild(language);

            string releaseDateText = nfoDocument.ReleaseDate;
            if (releaseDateText != "")
            {
                DateTime releaseDateParsed = DateTime.Parse(releaseDateText);
                XmlElement releaseDate = xmlDoc.CreateElement("releaseDate");
                releaseDate.AppendChild(xmlDoc.CreateTextNode(releaseDateParsed.ToString("yyyy MM dd")));
                mdrDvd.AppendChild(releaseDate);
            }

            XmlElement genre = xmlDoc.CreateElement("genre");
            genre.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Genre));
            mdrDvd.AppendChild(genre);

            XmlElement dataProvider = xmlDoc.CreateElement("dataProvider");
            mdrDvd.AppendChild(dataProvider);

            XmlElement title = xmlDoc.CreateElement("title");
            mdrDvd.AppendChild(title);

            XmlElement titleNum = xmlDoc.CreateElement("titleNum");
            titleNum.AppendChild(xmlDoc.CreateTextNode("1"));
            title.AppendChild(titleNum);

            XmlElement titleTitle = xmlDoc.CreateElement("titleTitle");
            titleTitle.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Title));
            title.AppendChild(titleTitle);

            XmlElement titleStudio = xmlDoc.CreateElement("studio");
            titleStudio.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Studio));
            title.AppendChild(titleStudio);

            XmlElement titleLeadPerformer = xmlDoc.CreateElement("leadPerformer");
            title.AppendChild(titleLeadPerformer);

            XmlElement titleDirector = xmlDoc.CreateElement("director");
            titleDirector.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Director));
            title.AppendChild(titleDirector);

            XmlElement titleMPAARating = xmlDoc.CreateElement("MPAARating");
            titleMPAARating.AppendChild(xmlDoc.CreateTextNode(nfoDocument.MPAARating));
            title.AppendChild(titleMPAARating);

            XmlElement titleGenre = xmlDoc.CreateElement("genre");
            titleGenre.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Genre));
            title.AppendChild(titleGenre);

            XmlElement titleSynopsis = xmlDoc.CreateElement("synopsis");
            titleSynopsis.AppendChild(xmlDoc.CreateTextNode(nfoDocument.Plot));
            title.AppendChild(titleSynopsis);

            return xmlDoc;

        }

    }
}
