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
            this.ReactToNotificationsCheckBox = new System.Windows.Forms.CheckBox();
            this.gestureComboBox = new System.Windows.Forms.ComboBox();
            this.faceLabel = new System.Windows.Forms.Label();
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
            // ReactToNotificationsCheckBox
            // 
            this.ReactToNotificationsCheckBox.AutoSize = true;
            this.ReactToNotificationsCheckBox.Location = new System.Drawing.Point(16, 41);
            this.ReactToNotificationsCheckBox.Name = "ReactToNotificationsCheckBox";
            this.ReactToNotificationsCheckBox.Size = new System.Drawing.Size(185, 17);
            this.ReactToNotificationsCheckBox.TabIndex = 3;
            this.ReactToNotificationsCheckBox.Text = "React to new notifications.  Make";
            this.ReactToNotificationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // gestureComboBox
            // 
            this.gestureComboBox.FormattingEnabled = true;
            this.gestureComboBox.Items.AddRange(new object[] {
            "Happy",
            "Surprised",
            "Awkward"});
            this.gestureComboBox.Location = new System.Drawing.Point(196, 37);
            this.gestureComboBox.Name = "gestureComboBox";
            this.gestureComboBox.Size = new System.Drawing.Size(121, 21);
            this.gestureComboBox.TabIndex = 4;
            // 
            // faceLabel
            // 
            this.faceLabel.AutoSize = true;
            this.faceLabel.Location = new System.Drawing.Point(323, 42);
            this.faceLabel.Name = "faceLabel";
            this.faceLabel.Size = new System.Drawing.Size(31, 13);
            this.faceLabel.TabIndex = 5;
            this.faceLabel.Text = "face.";
            // 
            // FacebookOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.faceLabel);
            this.Controls.Add(this.gestureComboBox);
            this.Controls.Add(this.ReactToNotificationsCheckBox);
            this.Name = "FacebookOptionsControl";
            this.Size = new System.Drawing.Size(394, 124);
            this.Controls.SetChildIndex(this.ReactToNotificationsCheckBox, 0);
            this.Controls.SetChildIndex(this.ApplyChangesButton, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.gestureComboBox, 0);
            this.Controls.SetChildIndex(this.faceLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ReactToNotificationsCheckBox;
        private System.Windows.Forms.ComboBox gestureComboBox;
        private System.Windows.Forms.Label faceLabel;
    }
}
