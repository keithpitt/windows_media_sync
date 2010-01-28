using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.ComponentModel;
using System.Diagnostics;

namespace MediaSync
{
    public class AssetDiscovery
    {

        public string Location { get; set; }
        public BindingList<Asset> DataSource { get; set; }

        public AssetDiscovery() 
        {
            DataSource = new BindingList<Asset>();
        }

        public void Discover(string assetLocation)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(assetLocation))
                {
                    foreach (string f in Directory.GetFiles(d, "*.nfo"))
                    {
                        DataSource.Add(new MediaSync.Media.Movie.Asset(f));
                    }
                    Discover(d);
                }
            }
            catch
            {
                // Do nothing for the time being.
            }
        }

        public void Clear()
        {
            DataSource.Clear();
        }

    }
}
