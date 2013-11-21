namespace FritzNotifier
{
    partial class SimpleNotificationForm
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
            this.notificationCategoryBox = new System.Windows.Forms.ListBox();
            this.goToSiteButton = new System.Windows.Forms.Button();
            this.dismissButton = new System.Windows.Forms.Button();
            this.detailedViewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notificationCategoryBox
            // 
            this.notificationCategoryBox.FormattingEnabled = true;
            this.notificationCategoryBox.Items.AddRange(new object[] {
            "Facebook (0)",
            "Twitter (0)"});
            this.notificationCategoryBox.Location = new System.Drawing.Point(12, 35);
            this.notificationCategoryBox.Name = "notificationCategoryBox";
            this.notificationCategoryBox.Size = new System.Drawing.Size(192, 95);
            this.notificationCategoryBox.TabIndex = 0;
            // 
            // goToSiteButton
            // 
            this.goToSiteButton.Location = new System.Drawing.Point(12, 136);
            this.goToSiteButton.Name = "goToSiteButton";
            this.goToSiteButton.Size = new System.Drawing.Size(75, 23);
            this.goToSiteButton.TabIndex = 1;
            this.goToSiteButton.Text = "Go to Site";
            this.goToSiteButton.UseVisualStyleBackColor = true;
            this.goToSiteButton.Click += new System.EventHandler(this.goToSiteButton_Click);
            // 
            // dismissButton
            // 
            this.dismissButton.Location = new System.Drawing.Point(129, 136);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.Size = new System.Drawing.Size(75, 23);
            this.dismissButton.TabIndex = 2;
            this.dismissButton.Text = "Dismiss";
            this.dismissButton.UseVisualStyleBackColor = true;
            this.dismissButton.Click += new System.EventHandler(this.dismissButton_Click);
            // 
            // detailedViewButton
            // 
            this.detailedViewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.detailedViewButton.Location = new System.Drawing.Point(93, 6);
            this.detailedViewButton.Name = "detailedViewButton";
            this.detailedViewButton.Size = new System.Drawing.Size(111, 23);
            this.detailedViewButton.TabIndex = 3;
            this.detailedViewButton.Text = "Detailed Overview";
            this.detailedViewButton.UseVisualStyleBackColor = true;
            this.detailedViewButton.Click += new System.EventHandler(this.detailedViewButton_Click);
            // 
            // SimpleNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 171);
            this.Controls.Add(this.detailedViewButton);
            this.Controls.Add(this.dismissButton);
            this.Controls.Add(this.goToSiteButton);
            this.Controls.Add(this.notificationCategoryBox);
            this.Name = "SimpleNotificationForm";
            this.Text = "Fritz Notifier";
            this.Load += new System.EventHandler(this.SimpleNotificationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox notificationCategoryBox;
        private System.Windows.Forms.Button goToSiteButton;
        private System.Windows.Forms.Button dismissButton;
        private System.Windows.Forms.Button detailedViewButton;
    }
}