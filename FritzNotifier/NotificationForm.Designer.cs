namespace FritzNotifier
{
    partial class NotificationForm
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.notificationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.quickOverViewButton = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1078, 598);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.quickOverViewButton);
            this.tabPage1.Controls.Add(this.notificationTableLayoutPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1070, 572);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Notifications";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1070, 572);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // notificationTableLayoutPanel
            // 
            this.notificationTableLayoutPanel.ColumnCount = 1;
            this.notificationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.notificationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.notificationTableLayoutPanel.Name = "notificationTableLayoutPanel";
            this.notificationTableLayoutPanel.RowCount = 1;
            this.notificationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.notificationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.notificationTableLayoutPanel.Size = new System.Drawing.Size(1064, 566);
            this.notificationTableLayoutPanel.TabIndex = 0;
            // 
            // quickOverViewButton
            // 
            this.quickOverViewButton.Location = new System.Drawing.Point(954, 6);
            this.quickOverViewButton.Name = "quickOverViewButton";
            this.quickOverViewButton.Size = new System.Drawing.Size(108, 23);
            this.quickOverViewButton.TabIndex = 1;
            this.quickOverViewButton.Text = "Quick Overview";
            this.quickOverViewButton.UseVisualStyleBackColor = true;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 598);
            this.Controls.Add(this.mainTabControl);
            this.Name = "NotificationForm";
            this.Text = "Fritz Notifier";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel notificationTableLayoutPanel;
        private System.Windows.Forms.Button quickOverViewButton;
    }
}

