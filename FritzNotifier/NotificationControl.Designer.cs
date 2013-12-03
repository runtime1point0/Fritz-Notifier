namespace FritzNotifier
{
    partial class NotificationControl
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
            this.notificationTextTextBox = new System.Windows.Forms.TextBox();
            this.dismissButton = new System.Windows.Forms.Button();
            this.replayButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.gotoSiteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notificationTextTextBox
            // 
            this.notificationTextTextBox.Location = new System.Drawing.Point(0, 0);
            this.notificationTextTextBox.Multiline = true;
            this.notificationTextTextBox.Name = "notificationTextTextBox";
            this.notificationTextTextBox.ReadOnly = true;
            this.notificationTextTextBox.Size = new System.Drawing.Size(231, 36);
            this.notificationTextTextBox.TabIndex = 0;
            // 
            // dismissButton
            // 
            this.dismissButton.Location = new System.Drawing.Point(254, -1);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.Size = new System.Drawing.Size(75, 23);
            this.dismissButton.TabIndex = 1;
            this.dismissButton.Text = "Dismiss";
            this.dismissButton.UseVisualStyleBackColor = true;
            this.dismissButton.Click += new System.EventHandler(this.dismissButton_Click);
            // 
            // replayButton
            // 
            this.replayButton.Location = new System.Drawing.Point(254, 30);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(75, 23);
            this.replayButton.TabIndex = 2;
            this.replayButton.Text = "Replay";
            this.replayButton.UseVisualStyleBackColor = true;
            this.replayButton.Click += new System.EventHandler(this.replayButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(255, 61);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(83, 23);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "5:49 pm";
            // 
            // gotoSiteButton
            // 
            this.gotoSiteButton.Location = new System.Drawing.Point(0, 39);
            this.gotoSiteButton.Name = "gotoSiteButton";
            this.gotoSiteButton.Size = new System.Drawing.Size(75, 23);
            this.gotoSiteButton.TabIndex = 4;
            this.gotoSiteButton.Text = "Go to site";
            this.gotoSiteButton.UseVisualStyleBackColor = true;
            this.gotoSiteButton.Click += new System.EventHandler(this.gotoSiteButton_Click);
            // 
            // NotificationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gotoSiteButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.replayButton);
            this.Controls.Add(this.dismissButton);
            this.Controls.Add(this.notificationTextTextBox);
            this.Name = "NotificationControl";
            this.Size = new System.Drawing.Size(339, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox notificationTextTextBox;
        private System.Windows.Forms.Button dismissButton;
        private System.Windows.Forms.Button replayButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button gotoSiteButton;
    }
}
