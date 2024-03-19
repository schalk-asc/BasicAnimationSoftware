using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loadtest
{
    public partial class Form1 : Form
    {
        Thread thread;
        Color SelectedColor = Color.Red;
        string Brush;
        int processId;
        
        public enum PaintAction
        {
            Animate,
            Draw
        }


        List<string> animation = new List<string>();

        public PaintAction currentAction;
        public Form1()
        {
            InitializeComponent();


            if (!System.IO.Directory.Exists("TempDraw"))
            {
                Directory.CreateDirectory("TempDraw");
            }

            currentAction = PaintAction.Draw;

            

        }




        public void InitFolder()
        {
            string folderpath = (System.IO.Path.GetDirectoryName(Application.ExecutablePath)).Replace('\\', '/') + "/TempDraw/"+ processId + "/";

            if (!System.IO.Directory.Exists(folderpath))
            {
                System.IO.Directory.CreateDirectory(folderpath);
            }
        }

        public string GetWorkFolder()
        {
            string folderpath = (System.IO.Path.GetDirectoryName(Application.ExecutablePath)).Replace('\\', '/') + "/TempDraw/" + processId + "/";
            return folderpath;
        }

        void callRender()
        {
            while (true)
            {

                switch (currentAction)
                {
                    case PaintAction.Draw:
                        myUserControl1.clear();
                        string path = GetWorkFolder() + animation1.getFrame() + ".png";
                        myUserControl1.RenderFunction(path);
                        myUserControl1.captureEvents();
                        myUserControl1.Render();
                        myUserControl1.SaveImage(path);


                        if (animation1.InvokeRequired)
                        {
                            this.Invoke(new Action(() => {
                                animation1.Refresh(); // Ejemplo de acción que modifica la interfaz de usuario
                            }));
                        }
                        else
                        {
                            animation1.Refresh(); // Si no se requiere invocación, se realiza directamente
                        }

                      
                    break;
                    case PaintAction.Animate:

                        myUserControl1.clear();
                        string AnimPath = GetWorkFolder() + animation1.getFrame() + ".png";
                        myUserControl1.RenderFunction(AnimPath);
                        myUserControl1.Render();

                        animation1.Frames = animation1.Frames + 1;
                        Thread.Sleep(animation1.GetFrameSpeed());

                        break;
                }



            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            myUserControl1.CloseWindows();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog1;
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            colorDialog1.ShowDialog();
            SelectedColor= colorDialog1.Color;
            myUserControl1.SetBrush(Brush, SelectedColor);
        }

        public void update_Brush(string Brush)
        {
            myUserControl1.SetBrush(Brush, SelectedColor);
            this.Brush = Brush;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            processId = System.Diagnostics.Process.GetCurrentProcess().Id;
            InitFolder();
            animation1.Path = GetWorkFolder();
            myUserControl1.Inicialize();
            myUserControl1.SetBrush("C:/Users/schal/source/repos/loadtest/Brushes/Pincel2.png", SelectedColor);
            thread = new Thread(callRender);
            thread.Start();
        }
    }
}
