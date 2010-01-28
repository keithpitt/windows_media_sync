using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaSync
{
    public partial class Main : Form
    {

        public AssetDiscovery assetDiscovery;

        public Main()
        {
            InitializeComponent();
            
            assetDiscovery = new AssetDiscovery();
            assetGridView.DataSource = assetDiscovery.DataSource;

            assetDiscovery.Discover("D:\\Movies");
        }

        private void loadMediaButton_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                assetDiscovery.Discover(folderBrowserDialog.SelectedPath);
            }
        }

        private void syncMediaButton_Click(object sender, EventArgs e)
        {
            foreach (Media.Movie.Asset asset in assetDiscovery.DataSource)
            {
                asset.Sync();
            }
        }

    }
}
