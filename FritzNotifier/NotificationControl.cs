using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FritzNotifier
{
    public partial class NotificationControl : UserControl
    {
        public class DismissNotificationEventArgs : EventArgs
        {
            public Objects.Notification notification {get;set;}
        }

        public delegate void DismissNotificationEventHandler(object sender, DismissNotificationEventArgs e);
        public event DismissNotificationEventHandler DismissNotification;

        public class ReplayNotificationEventArgs : EventArgs
        {
            public int Gesture { get; set; }
            public string Speech { get; set; }
        }

        public delegate void ReplayNotificationEventHandler(object sender, ReplayNotificationEventArgs e);
        public event ReplayNotificationEventHandler ReplyNotification;

        public NotificationControl()
        {
            InitializeComponent();
        }

        private Objects.Notification notification;

        public void SetupScreen(Objects.Notification notification)
        {
            this.notification = notification;
            this.notificationTextTextBox.Text = notification.Text;
            if (notification.AssociatedGesture == 0 && string.IsNullOrEmpty(notification.Speech))
            {
                this.replayButton.Visible = false;
            }
            this.timeLabel.Text = notification.NotificationTime.ToString("t", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
        }

        private void dismissButton_Click(object sender, EventArgs e)
        {
            if (DismissNotification != null)
            {
                DismissNotification(this, new DismissNotificationEventArgs() { notification = this.notification });
            }
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            if (ReplyNotification != null)
            {
                ReplyNotification(this, new ReplayNotificationEventArgs() { Gesture = this.notification.AssociatedGesture, Speech = this.notification.Speech });
            }
        }

        private void gotoSiteButton_Click(object sender, EventArgs e)
        {
            if (this.notification != null && !string.IsNullOrEmpty(this.notification.ApplicationAddress))
            {
                System.Diagnostics.Process.Start(this.notification.ApplicationAddress);
            }
        }
    }
}
