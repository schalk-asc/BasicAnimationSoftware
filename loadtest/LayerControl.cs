using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loadtest
{
    public partial class LayerControl : UserControl
    {
        public LayerControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SetLabel(string framenumber)
        {
            LblNumber.Text = framenumber;
        }

        public void SetPicture(Image image)
        {
            PicFrame.Image = image;
        }

        public string GetLabel()
        {
            return LblNumber.Text;
        }

    }
}
