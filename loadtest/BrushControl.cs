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
    public partial class BrushControl : UserControl
    {

        bool selected = false;
        public string brushPath ="";
        public BrushControl(string brushPath)
        {
            InitializeComponent();

            this.brushPath = brushPath;
        }

        public void SetImage(Image img)
        {
            pictureBox1.Image = img;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ((BrushesPanel)this.Parent).ClearSubcomponent();
            selected = true;
            this.BackColor = Color.Black;

            ((Form1)this.ParentForm).update_Brush(brushPath.Replace('\\','/'));
        }

        public void unselectBrush()
        {
            this.BackColor = SystemColors.Control;
            selected = false;
        }


    }

}
