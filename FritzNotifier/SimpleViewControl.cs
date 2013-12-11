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
    public partial class SimpleViewControl : UserControl
    {
        public delegate void DismissNotificationsEventHandler(object sender, EventArgs e);
        public event DismissNotificationsEventHandler DismissNotifications;

        public SimpleViewControl()
        {
            InitializeComponent();
        }

        public SimpleViewControl(List<Plugins.INotifier> parentNotifiers, List<Objects.Notification> parentNotifications)
        {
            InitializeComponent();

            InitializeNotificationsCount(parentNotifiers, parentNotifications);
        }

        public void InitializeNotificationsCount(List<Plugins.INotifier> parentNotifiers, List<Objects.Notification> parentNotifications)
        {
            this.plugins = parentNotifiers;
            this.notifications = parentNotifications;

            update();
        }

        private void dismissButton_Click(object sender, EventArgs e)
        {
            object selectedItem = notificationCategoryBox.SelectedItem;

            if (selectedItem != null)
            {
                string applicationToDismiss = selectedItem.ToString();
                applicationToDismiss = applicationToDismiss.Substring(0, applicationToDismiss.IndexOf(" ("));

                int count = this.notifications.RemoveAll(x => x.ApplicationName == applicationToDismiss);

                update();

                if (count > 0 && DismissNotifications != null)
                {
                    DismissNotifications(this, EventArgs.Empty);
                }
            }
        }

        private void goToSiteButton_Click(object sender, EventArgs e)
        {
            object selectedItem = notificationCategoryBox.SelectedItem;

            if (selectedItem != null)
            {
                string item = selectedItem.ToString();
                item = item.Substring(0, item.IndexOf(" ("));

                var plugin = plugins.Find(x => x.NotificationApplication == item);
                if (plugin != null)
                {
                    System.Diagnostics.Process.Start(plugin.WebsiteOrProgramAddress);
                }
            }
        }

        public void update()
        {
            int selectedIndex = notificationCategoryBox.SelectedIndex;

            notificationCategoryBox.Items.Clear();

            foreach (var plugin in plugins)
            {
                notificationCategoryBox.Items.Add(plugin.NotificationApplication + " (" + notifications.Count(x => x.ApplicationName == plugin.NotificationApplication).ToString() + ")");
            }

            if (notificationCategoryBox.Items.Count > selectedIndex && notificationCategoryBox.Items.Count > 0)
            {
                if (selectedIndex == -1) selectedIndex = 0;
                notificationCategoryBox.SelectedIndex = selectedIndex;
            }
        }

        private List<Plugins.INotifier> plugins = new List<Plugins.INotifier>();
        private List<Objects.Notification> notifications = new List<Objects.Notification>();

        public List<Objects.Notification> Notifications { get { return this.notifications; } }
    }
}
