using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace MediaSync
{
    public abstract class Asset
    {

        public Image Poster { get; set; }
        public String Title { get; set; }
        public FileInfo Directory { get; set; }

        public virtual void Sync()
        {
            // Overwrite me, kthnx.
        }

    }
}
