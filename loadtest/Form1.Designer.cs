namespace loadtest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myUserControl1 = new testlibrary2.MyUserControl();
            this.btnColor = new System.Windows.Forms.Button();
            this.brushesPanel1 = new loadtest.BrushesPanel();
            this.animation1 = new loadtest.Animation();
            this.layersControl1 = new loadtest.LayersControl();
            this.SuspendLayout();
            // 
            // myUserControl1
            // 
            this.myUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myUserControl1.Location = new System.Drawing.Point(12, 189);
            this.myUserControl1.Name = "myUserControl1";
            this.myUserControl1.Size = new System.Drawing.Size(777, 324);
            this.myUserControl1.TabIndex = 0;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(23, 99);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 1;
            this.btnColor.Text = "ColorPicker";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // brushesPanel1
            // 
            this.brushesPanel1.AutoScroll = true;
            this.brushesPanel1.Location = new System.Drawing.Point(177, 56);
            this.brushesPanel1.Name = "brushesPanel1";
            this.brushesPanel1.Size = new System.Drawing.Size(487, 127);
            this.brushesPanel1.TabIndex = 2;
            // 
            // animation1
            // 
            this.animation1.Frames = 1;
            this.animation1.Location = new System.Drawing.Point(12, 519);
            this.animation1.Name = "animation1";
            this.animation1.Size = new System.Drawing.Size(777, 198);
            this.animation1.TabIndex = 3;
            // 
            // layersControl1
            // 
            this.layersControl1.Location = new System.Drawing.Point(12, 738);
            this.layersControl1.Name = "layersControl1";
            this.layersControl1.Size = new System.Drawing.Size(777, 173);
            this.layersControl1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 923);
            this.Controls.Add(this.layersControl1);
            this.Controls.Add(this.animation1);
            this.Controls.Add(this.brushesPanel1);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.myUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private testlibrary2.MyUserControl myUserControl1;
        private System.Windows.Forms.Button btnColor;
        private BrushesPanel brushesPanel1;
        private Animation animation1;
        private LayersControl layersControl1;
    }
}

