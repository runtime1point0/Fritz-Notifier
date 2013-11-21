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
            this.components = new System.ComponentModel.Container();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.notificationsTabPage = new System.Windows.Forms.TabPage();
            this.quickOverViewButton = new System.Windows.Forms.Button();
            this.notificationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.configureNotificationsTabPage = new System.Windows.Forms.TabPage();
            this.editingOptionsControlHolderPanel = new System.Windows.Forms.Panel();
            this.ConfigureForLabel = new System.Windows.Forms.Label();
            this.notificationToConfigureComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainTabControl.SuspendLayout();
            this.notificationsTabPage.SuspendLayout();
            this.configureNotificationsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.notificationsTabPage);
            this.mainTabControl.Controls.Add(this.configureNotificationsTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1078, 598);
            this.mainTabControl.TabIndex = 0;
            // 
            // notificationsTabPage
            // 
            this.notificationsTabPage.Controls.Add(this.quickOverViewButton);
            this.notificationsTabPage.Controls.Add(this.notificationTableLayoutPanel);
            this.notificationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.notificationsTabPage.Name = "notificationsTabPage";
            this.notificationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.notificationsTabPage.Size = new System.Drawing.Size(1070, 572);
            this.notificationsTabPage.TabIndex = 0;
            this.notificationsTabPage.Text = "Notifications";
            this.notificationsTabPage.UseVisualStyleBackColor = true;
            // 
            // quickOverViewButton
            // 
            this.quickOverViewButton.Location = new System.Drawing.Point(954, 6);
            this.quickOverViewButton.Name = "quickOverViewButton";
            this.quickOverViewButton.Size = new System.Drawing.Size(108, 23);
            this.quickOverViewButton.TabIndex = 1;
            this.quickOverViewButton.Text = "Quick Overview";
            this.quickOverViewButton.UseVisualStyleBackColor = true;
            this.quickOverViewButton.Click += new System.EventHandler(this.quickOverViewButton_Click);
            // 
            // notificationTableLayoutPanel
            // 
            this.notificationTableLayoutPanel.AutoScroll = true;
            this.notificationTableLayoutPanel.ColumnCount = 1;
            this.notificationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.notificationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.notificationTableLayoutPanel.Name = "notificationTableLayoutPanel";
            this.notificationTableLayoutPanel.RowCount = 1;
            this.notificationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 566F));
            this.notificationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 566F));
            this.notificationTableLayoutPanel.Size = new System.Drawing.Size(1064, 566);
            this.notificationTableLayoutPanel.TabIndex = 0;
            // 
            // configureNotificationsTabPage
            // 
            this.configureNotificationsTabPage.Controls.Add(this.editingOptionsControlHolderPanel);
            this.configureNotificationsTabPage.Controls.Add(this.ConfigureForLabel);
            this.configureNotificationsTabPage.Controls.Add(this.notificationToConfigureComboBox);
            this.configureNotificationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.configureNotificationsTabPage.Name = "configureNotificationsTabPage";
            this.configureNotificationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.configureNotificationsTabPage.Size = new System.Drawing.Size(1070, 572);
            this.configureNotificationsTabPage.TabIndex = 1;
            this.configureNotificationsTabPage.Text = "Configure Notifications";
            this.configureNotificationsTabPage.UseVisualStyleBackColor = true;
            // 
            // editingOptionsControlHolderPanel
            // 
            this.editingOptionsControlHolderPanel.Location = new System.Drawing.Point(11, 42);
            this.editingOptionsControlHolderPanel.Name = "editingOptionsControlHolderPanel";
            this.editingOptionsControlHolderPanel.Size = new System.Drawing.Size(648, 420);
            this.editingOptionsControlHolderPanel.TabIndex = 2;
            // 
            // ConfigureForLabel
            // 
            this.ConfigureForLabel.AutoSize = true;
            this.ConfigureForLabel.Location = new System.Drawing.Point(8, 18);
            this.ConfigureForLabel.Name = "ConfigureForLabel";
            this.ConfigureForLabel.Size = new System.Drawing.Size(67, 13);
            this.ConfigureForLabel.TabIndex = 1;
            this.ConfigureForLabel.Text = "Configure for";
            // 
            // notificationToConfigureComboBox
            // 
            this.notificationToConfigureComboBox.FormattingEnabled = true;
            this.notificationToConfigureComboBox.Location = new System.Drawing.Point(79, 15);
            this.notificationToConfigureComboBox.Name = "notificationToConfigureComboBox";
            this.notificationToConfigureComboBox.Size = new System.Drawing.Size(121, 21);
            this.notificationToConfigureComboBox.TabIndex = 0;
            this.notificationToConfigureComboBox.SelectedIndexChanged += new System.EventHandler(this.notificationToConfigureComboBox_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.notificationsTabPage.ResumeLayout(false);
            this.configureNotificationsTabPage.ResumeLayout(false);
            this.configureNotificationsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage notificationsTabPage;
        private System.Windows.Forms.TabPage configureNotificationsTabPage;
        private System.Windows.Forms.TableLayoutPanel notificationTableLayoutPanel;
        private System.Windows.Forms.Button quickOverViewButton;
        private System.Windows.Forms.ComboBox notificationToConfigureComboBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label ConfigureForLabel;
        private System.Windows.Forms.Panel editingOptionsControlHolderPanel;
    }
}

