namespace loadtest
{
    partial class Animation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFrames = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAnimate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFrames
            // 
            this.txtFrames.Location = new System.Drawing.Point(74, 4);
            this.txtFrames.Name = "txtFrames";
            this.txtFrames.Size = new System.Drawing.Size(72, 22);
            this.txtFrames.TabIndex = 0;
            this.txtFrames.Text = "1";
            this.txtFrames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrames_KeyPress);
            this.txtFrames.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFrames_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frames";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 191);
            this.panel1.TabIndex = 2;
            // 
            // BtnAnimate
            // 
            this.BtnAnimate.Location = new System.Drawing.Point(470, 7);
            this.BtnAnimate.Name = "BtnAnimate";
            this.BtnAnimate.Size = new System.Drawing.Size(53, 23);
            this.BtnAnimate.TabIndex = 3;
            this.BtnAnimate.Text = "Play";
            this.BtnAnimate.UseVisualStyleBackColor = true;
            this.BtnAnimate.Click += new System.EventHandler(this.BtnAnimate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Speed:";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(220, 4);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(52, 22);
            this.txtSpeed.TabIndex = 5;
            this.txtSpeed.TextChanged += new System.EventHandler(this.txtSpeed_TextChanged);
            this.txtSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpeed_KeyPress);
            // 
            // Animation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnAnimate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFrames);
            this.Name = "Animation";
            this.Size = new System.Drawing.Size(1066, 226);
            this.Load += new System.EventHandler(this.Animation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAnimate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpeed;
    }
}
