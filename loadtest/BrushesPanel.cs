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
    public partial class BrushesPanel : UserControl
    {
        public BrushesPanel()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BrushesPanel_Load(object sender, EventArgs e)
        {
           string[] availablebrushes =  Directory.GetFiles(@"Brushes");

            int x = 0;
            int y = 0;

            foreach (string avbrush in availablebrushes)
            {
                BrushControl box = new BrushControl(avbrush);

                box.SetImage(Image.FromFile(avbrush));

                if (5 + (5 * x) + (box.Size.Width * x) + box.Size.Width > this.Width)
                {
                    x = 0;
                    y = y + 1;
                }
                
                box.Location = new Point(5 + (5 * x) + (box.Size.Width * x), 5 + (5 * y) + (box.Size.Width * y));

                this.Controls.Add(box);

                x = x + 1;
            }

        }

        public void ClearSubcomponent()
        {
            foreach (BrushControl c in this.Controls)
            {
                c.unselectBrush();
            }

        }



    }
}
