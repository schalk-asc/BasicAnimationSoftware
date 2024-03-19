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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loadtest
{
    public partial class Animation : UserControl
    {
        int frames = 1;
        bool isplaying = false;

        public string Path = "";
        public int Frames   // property
        {
            get { return frames; }
            set {
                if (value <= int.Parse(txtFrames.Text))
                {
                    frames = value;
                }
                else
                {
                    frames = 1;
                }
                }
        }
        public Animation()
        {
            InitializeComponent();

            //Refresh();
            
        }




        public void Refresh()
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


        public void RefreshFrames()
        {
            panel1.Controls.Clear();

            int x = 0;

            for (int i = 0; i < int.Parse(txtFrames.Text); i++)
            {
                string path = Path + (i +1) + ".png";

                FrameControl c = new FrameControl();

                c.SetLabel((i + 1).ToString());

               // c.Size = new Size(50, 50);

                if (File.Exists(path.Replace('/', '\\')))
                {
                  //  Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(path.Replace('/', '\\'))));

                  //  c.SetPicture(image);
                        //c.Image = (image);
                }
                

                c.Location = new Point(5 + (5 * x) + (c.Size.Width * x), 5);

                c.BackColor = Color.Blue;


                panel1.Controls.Add(c);

                x = x + 1;

            }
        }

        private void txtFrames_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPreass(sender, e);
        }

        private void BtnAnimate_Click(object sender, EventArgs e)
        {

            isplaying = !isplaying;

            if (isplaying)
            {
                BtnAnimate.Text = "Stop";
                ((Form1)ParentForm).currentAction = Form1.PaintAction.Animate;
            }
            else
            {
                BtnAnimate.Text = "Play";
                ((Form1)ParentForm).currentAction = Form1.PaintAction.Draw;
            }
        }

        public int getFrame()
        {
            return Frames;
        }

        private void txtFrames_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (int.Parse(txtFrames.Text) >= 1)
                {
                    RefreshFrames();
                }

                Frames = int.Parse(txtFrames.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {

            KeyPreass(sender, e);

            
            
        }

        public void KeyPreass(object sender, KeyPressEventArgs e)
        {
            //&& (e.KeyChar != '.')
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        public int  GetFrameSpeed()
        {
            return int.Parse(txtSpeed.Text);
        }

        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Animation_Load(object sender, EventArgs e)
        {
            txtSpeed.Text = "100";
            txtFrames.Text = Frames.ToString();
            RefreshFrames();
        }
    }
}
