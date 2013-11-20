namespace FritzNotifier.Facebook
{
    partial class FacebookOptionsControl
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
            this.ReadMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ApplyChangesButton
            // 
            this.ApplyChangesButton.Visible = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Visible = true;
            // 
            // ReadMessageCheckBox
            // 
            this.ReadMessageCheckBox.AutoSize = true;
            this.ReadMessageCheckBox.Location = new System.Drawing.Point(16, 41);
            this.ReadMessageCheckBox.Name = "ReadMessageCheckBox";
            this.ReadMessageCheckBox.Size = new System.Drawing.Size(154, 17);
            this.ReadMessageCheckBox.TabIndex = 3;
            this.ReadMessageCheckBox.Text = "Read new direct messages";
            this.ReadMessageCheckBox.UseVisualStyleBackColor = true;
            // 
            // FacebookOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReadMessageCheckBox);
            this.Name = "FacebookOptionsControl";
            this.Size = new System.Drawing.Size(394, 124);
            this.Controls.SetChildIndex(this.ReadMessageCheckBox, 0);
            this.Controls.SetChildIndex(this.ApplyChangesButton, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ReadMessageCheckBox;
    }
}
