using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Xml;
using System.Xml.XPath;

using System.Text.RegularExpressions;

namespace MediaSync.Media.Movie
{

    public class MovieNFODocument
    {

        public String Title { get; set; }
        public String Studio { get; set; }
        public String Genre { get; set; }
        public String Director { get; set; }
        public String MPAARating { get; set; }
        public String ReleaseDate { get; set; }
        public String Runtime { get; set; }
        public String Plot { get; set; }

        XPathDocument docNav;
        XPathNavigator nav;

        public MovieNFODocument(string location)
        {

            // Read the current document and strip out as much information as possible
            docNav = new XPathDocument(location);
            nav = docNav.CreateNavigator();

            this.Title = SelectSingleNode("/movie/title");
            this.Studio = SelectSingleNode("/movie/studio");
            this.Genre = SelectSingleNode("/movie/genre");

            // WMC only supports 1 genre.
            if (this.Genre != "")
            {
                string[] genres = this.Genre.Split('/');
                this.Genre = genres.First().ToString().Trim();
            }

            this.Director = SelectSingleNode("/movie/director");
            this.MPAARating = SelectSingleNode("/movie/mpaa");

            // Condense rating into something like PG or R
            if (this.MPAARating != "")
            {

                Regex pg13Regex = new Regex("PG-13", RegexOptions.IgnoreCase);
                Match pg13RegexMatch = pg13Regex.Match(this.MPAARating);

                if (pg13RegexMatch.Success)
                {
                    this.MPAARating = "PG-13";
                }

                Regex pgRegex = new Regex("PG", RegexOptions.IgnoreCase);
                Match pgRegexMatch = pgRegex.Match(this.MPAARating);

                if (pgRegexMatch.Success)
                {
                    this.MPAARating = "PG";
                }

                Regex ratedRRegex = new Regex("Rated R", RegexOptions.IgnoreCase);
                Match ratedRRegexMatch = ratedRRegex.Match(this.MPAARating);

                if (ratedRRegexMatch.Success)
                {
                    this.MPAARating = "R";
                }

            }

            this.ReleaseDate = SelectSingleNode("/movie/releasedate");
            this.Runtime = SelectSingleNode("/movie/runtime");
            this.Plot = SelectSingleNode("/movie/plot");

        }

        public string SelectSingleNode(string expression)
        {

            XPathNavigator item = nav.SelectSingleNode(expression);

            if (item == null)
            {
                return "";
            }
            else
            {
                return item.InnerXml;
            }

        }

    }

}
