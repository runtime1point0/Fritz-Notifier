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
            System.Windows.Forms.Panel quickOverviewPanel;
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.robotVoiceLabel = new System.Windows.Forms.Label();
            this.robotVoiceComboBox = new System.Windows.Forms.ComboBox();
            this.noOptionsLabel = new System.Windows.Forms.Label();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.simpleViewButton = new System.Windows.Forms.Button();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.notificationsTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.notificationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.simpleViewControl = new FritzNotifier.SimpleViewControl();
            this.configureNotificationsTabPage = new System.Windows.Forms.TabPage();
            this.editingOptionsControlHolderPanel = new System.Windows.Forms.Panel();
            this.ConfigureForLabel = new System.Windows.Forms.Label();
            this.notificationToConfigureComboBox = new System.Windows.Forms.ComboBox();
            quickOverviewPanel = new System.Windows.Forms.Panel();
            quickOverviewPanel.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.notificationsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.configureNotificationsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // quickOverviewPanel
            // 
            quickOverviewPanel.CausesValidation = false;
            quickOverviewPanel.Controls.Add(this.filterComboBox);
            quickOverviewPanel.Controls.Add(this.filterLabel);
            quickOverviewPanel.Controls.Add(this.robotVoiceLabel);
            quickOverviewPanel.Controls.Add(this.robotVoiceComboBox);
            quickOverviewPanel.Controls.Add(this.noOptionsLabel);
            quickOverviewPanel.Controls.Add(this.connectionStatusLabel);
            quickOverviewPanel.Controls.Add(this.simpleViewButton);
            quickOverviewPanel.Dock = System.Windows.Forms.DockStyle.Top;
            quickOverviewPanel.Location = new System.Drawing.Point(3, 3);
            quickOverviewPanel.Name = "quickOverviewPanel";
            quickOverviewPanel.Size = new System.Drawing.Size(1064, 31);
            quickOverviewPanel.TabIndex = 1;
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(45, 4);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(121, 21);
            this.filterComboBox.TabIndex = 6;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(6, 10);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(32, 13);
            this.filterLabel.TabIndex = 5;
            this.filterLabel.Text = "Filter:";
            // 
            // robotVoiceLabel
            // 
            this.robotVoiceLabel.AutoSize = true;
            this.robotVoiceLabel.Location = new System.Drawing.Point(754, 10);
            this.robotVoiceLabel.Name = "robotVoiceLabel";
            this.robotVoiceLabel.Size = new System.Drawing.Size(66, 13);
            this.robotVoiceLabel.TabIndex = 4;
            this.robotVoiceLabel.Text = "Robot Voice";
            // 
            // robotVoiceComboBox
            // 
            this.robotVoiceComboBox.FormattingEnabled = true;
            this.robotVoiceComboBox.Location = new System.Drawing.Point(824, 5);
            this.robotVoiceComboBox.Name = "robotVoiceComboBox";
            this.robotVoiceComboBox.Size = new System.Drawing.Size(121, 21);
            this.robotVoiceComboBox.TabIndex = 3;
            // 
            // noOptionsLabel
            // 
            this.noOptionsLabel.AutoSize = true;
            this.noOptionsLabel.CausesValidation = false;
            this.noOptionsLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.noOptionsLabel.Location = new System.Drawing.Point(234, 10);
            this.noOptionsLabel.Name = "noOptionsLabel";
            this.noOptionsLabel.Size = new System.Drawing.Size(353, 13);
            this.noOptionsLabel.TabIndex = 2;
            this.noOptionsLabel.Text = "No notifications are set up.  Configure notifications to start receiving them.";
            this.noOptionsLabel.Visible = false;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.connectionStatusLabel.Location = new System.Drawing.Point(644, 10);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(105, 13);
            this.connectionStatusLabel.TabIndex = 1;
            this.connectionStatusLabel.Text = "Robot Disconnected";
            // 
            // simpleViewButton
            // 
            this.simpleViewButton.Location = new System.Drawing.Point(951, 5);
            this.simpleViewButton.Name = "simpleViewButton";
            this.simpleViewButton.Size = new System.Drawing.Size(108, 23);
            this.simpleViewButton.TabIndex = 0;
            this.simpleViewButton.Text = "Simple View";
            this.simpleViewButton.UseVisualStyleBackColor = true;
            this.simpleViewButton.Click += new System.EventHandler(this.simpleViewButton_Click);
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
            this.notificationsTabPage.Controls.Add(this.splitContainer1);
            this.notificationsTabPage.Controls.Add(quickOverviewPanel);
            this.notificationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.notificationsTabPage.Name = "notificationsTabPage";
            this.notificationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.notificationsTabPage.Size = new System.Drawing.Size(1070, 572);
            this.notificationsTabPage.TabIndex = 0;
            this.notificationsTabPage.Text = "Notifications";
            this.notificationsTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.notificationTableLayoutPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.simpleViewControl);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.splitContainer1.Panel2MinSize = 219;
            this.splitContainer1.Size = new System.Drawing.Size(1064, 535);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 3;
            // 
            // notificationTableLayoutPanel
            // 
            this.notificationTableLayoutPanel.AutoScroll = true;
            this.notificationTableLayoutPanel.AutoSize = true;
            this.notificationTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.notificationTableLayoutPanel.ColumnCount = 1;
            this.notificationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.notificationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.notificationTableLayoutPanel.Name = "notificationTableLayoutPanel";
            this.notificationTableLayoutPanel.RowCount = 1;
            this.notificationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.notificationTableLayoutPanel.Size = new System.Drawing.Size(354, 535);
            this.notificationTableLayoutPanel.TabIndex = 1;
            // 
            // simpleViewControl
            // 
            this.simpleViewControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleViewControl.Location = new System.Drawing.Point(5, 0);
            this.simpleViewControl.Name = "simpleViewControl";
            this.simpleViewControl.Size = new System.Drawing.Size(701, 150);
            this.simpleViewControl.TabIndex = 2;
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
            this.ConfigureForLabel.TabIndex = 0;
            this.ConfigureForLabel.Text = "Configure for";
            // 
            // notificationToConfigureComboBox
            // 
            this.notificationToConfigureComboBox.FormattingEnabled = true;
            this.notificationToConfigureComboBox.Location = new System.Drawing.Point(79, 15);
            this.notificationToConfigureComboBox.Name = "notificationToConfigureComboBox";
            this.notificationToConfigureComboBox.Size = new System.Drawing.Size(121, 21);
            this.notificationToConfigureComboBox.TabIndex = 1;
            this.notificationToConfigureComboBox.SelectedIndexChanged += new System.EventHandler(this.notificationToConfigureComboBox_SelectedIndexChanged);
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1078, 598);
            this.Controls.Add(this.mainTabControl);
            this.DoubleBuffered = true;
            this.Name = "NotificationForm";
            this.Text = "Fritz Notifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotificationForm_FormClosing);
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            quickOverviewPanel.ResumeLayout(false);
            quickOverviewPanel.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.notificationsTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.configureNotificationsTabPage.ResumeLayout(false);
            this.configureNotificationsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage notificationsTabPage;
        private System.Windows.Forms.TabPage configureNotificationsTabPage;
        private System.Windows.Forms.TableLayoutPanel notificationTableLayoutPanel;
        private System.Windows.Forms.Button simpleViewButton;
        private System.Windows.Forms.ComboBox notificationToConfigureComboBox;
        private System.Windows.Forms.Label ConfigureForLabel;
        private System.Windows.Forms.Panel editingOptionsControlHolderPanel;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Label noOptionsLabel;
        private System.Windows.Forms.Label robotVoiceLabel;
        private System.Windows.Forms.ComboBox robotVoiceComboBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.ComboBox filterComboBox;
        private SimpleViewControl simpleViewControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

