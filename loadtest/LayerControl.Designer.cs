namespace loadtest
{
    partial class LayerControl
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
            this.PicFrame.Location = new System.Drawing.Point(10, 3);
            this.PicFrame.Name = "PicFrame";
            this.PicFrame.Size = new System.Drawing.Size(120, 120);
            this.PicFrame.TabIndex = 0;
            this.PicFrame.TabStop = false;
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Location = new System.Drawing.Point(47, 124);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(44, 16);
            this.LblNumber.TabIndex = 1;
            this.LblNumber.Text = "label1";
            this.LblNumber.Click += new System.EventHandler(this.label1_Click);
            // 
            // LayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.PicFrame);
            this.Name = "LayerControl";
            this.Size = new System.Drawing.Size(140, 140);
            ((System.ComponentModel.ISupportInitialize)(this.PicFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicFrame;
        private System.Windows.Forms.Label LblNumber;
    }
}
