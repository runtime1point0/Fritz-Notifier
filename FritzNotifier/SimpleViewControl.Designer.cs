namespace FritzNotifier
{
    partial class SimpleViewControl
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
            this.notificationCategoryBox = new System.Windows.Forms.ListBox();
            this.goToSiteButton = new System.Windows.Forms.Button();
            this.dismissButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notificationCategoryBox
            // 
            this.notificationCategoryBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.notificationCategoryBox.FormattingEnabled = true;
            this.notificationCategoryBox.Location = new System.Drawing.Point(0, 0);
            this.notificationCategoryBox.Name = "notificationCategoryBox";
            this.notificationCategoryBox.Size = new System.Drawing.Size(219, 95);
            this.notificationCategoryBox.TabIndex = 0;
            // 
            // goToSiteButton
            // 
            this.goToSiteButton.Location = new System.Drawing.Point(12, 113);
            this.goToSiteButton.Name = "goToSiteButton";
            this.goToSiteButton.Size = new System.Drawing.Size(75, 23);
            this.goToSiteButton.TabIndex = 1;
            this.goToSiteButton.Text = "Go to Site";
            this.goToSiteButton.UseVisualStyleBackColor = true;
            this.goToSiteButton.Click += new System.EventHandler(this.goToSiteButton_Click);
            // 
            // dismissButton
            // 
            this.dismissButton.Location = new System.Drawing.Point(129, 113);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.Size = new System.Drawing.Size(75, 23);
            this.dismissButton.TabIndex = 2;
            this.dismissButton.Text = "Dismiss";
            this.dismissButton.UseVisualStyleBackColor = true;
            this.dismissButton.Click += new System.EventHandler(this.dismissButton_Click);
            // 
            // SimpleViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dismissButton);
            this.Controls.Add(this.goToSiteButton);
            this.Controls.Add(this.notificationCategoryBox);
            this.Name = "SimpleViewControl";
            this.Size = new System.Drawing.Size(219, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox notificationCategoryBox;
        private System.Windows.Forms.Button goToSiteButton;
        private System.Windows.Forms.Button dismissButton;
    }
}
