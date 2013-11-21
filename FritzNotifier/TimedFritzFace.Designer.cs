namespace FritzNotifier
{
    partial class TimedFritzFace
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
            this.fritzFacePictureBox = new System.Windows.Forms.PictureBox();
            this.fritzSpeechTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fritzFacePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fritzFacePictureBox
            // 
            this.fritzFacePictureBox.Location = new System.Drawing.Point(0, 0);
            this.fritzFacePictureBox.Name = "fritzFacePictureBox";
            this.fritzFacePictureBox.Size = new System.Drawing.Size(255, 347);
            this.fritzFacePictureBox.TabIndex = 0;
            this.fritzFacePictureBox.TabStop = false;
            // 
            // fritzSpeechTextBox
            // 
            this.fritzSpeechTextBox.Location = new System.Drawing.Point(0, 353);
            this.fritzSpeechTextBox.Multiline = true;
            this.fritzSpeechTextBox.Name = "fritzSpeechTextBox";
            this.fritzSpeechTextBox.Size = new System.Drawing.Size(255, 232);
            this.fritzSpeechTextBox.TabIndex = 1;
            // 
            // TimedFritzFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 586);
            this.Controls.Add(this.fritzSpeechTextBox);
            this.Controls.Add(this.fritzFacePictureBox);
            this.MaximizeBox = false;
            this.Name = "TimedFritzFace";
            this.Text = "TimedFritzFace";
            ((System.ComponentModel.ISupportInitialize)(this.fritzFacePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fritzFacePictureBox;
        private System.Windows.Forms.TextBox fritzSpeechTextBox;
    }
}