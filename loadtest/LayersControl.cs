using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loadtest
{
    public partial class LayersControl : UserControl
    {
        public string Path;
        public LayersControl()
        {
            InitializeComponent();
        }

        private void LayersControl_Load(object sender, EventArgs e)
        {

        }

        public void RefreshControls()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(FrameControl))
                {
                    string path = Path + ((FrameControl)c).GetLabel() + ".png";

                    if (File.Exists(path.Replace('/', '\\')))
                    {
                        Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(path.Replace('/', '\\'))));
                        ((FrameControl)c).SetPicture(image);
                    }
                }
            }
        }



    }
}
