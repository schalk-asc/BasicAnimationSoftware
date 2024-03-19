namespace loadtest
{
    partial class FrameControl
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
            this.PicFrame = new System.Windows.Forms.PictureBox();
            this.LblNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // PicFrame
            // 
            this.PicFrame.Location = new System.Drawing.Point(3, 3);
            this.PicFrame.Name = "PicFrame";
            this.PicFrame.Size = new System.Drawing.Size(144, 119);
            this.PicFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicFrame.TabIndex = 0;
            this.PicFrame.TabStop = false;
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Location = new System.Drawing.Point(46, 125);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(44, 16);
            this.LblNumber.TabIndex = 1;
            this.LblNumber.Text = "label1";
            // 
            // FrameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.PicFrame);
            this.Name = "FrameControl";
            ((System.ComponentModel.ISupportInitialize)(this.PicFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicFrame;
        private System.Windows.Forms.Label LblNumber;
    }
}
