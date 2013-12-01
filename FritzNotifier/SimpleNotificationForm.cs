using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FritzNotifier
{
    public partial class SimpleNotificationForm : Form
    {

        NotificationForm parentForm;

        public SimpleNotificationForm(NotificationForm parent, List<Plugins.INotifier> parentNotifiers, List<Objects.Notification> parentNotifications)
        {
            InitializeComponent();

            this.parentForm = parent;
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

                this.notifications.RemoveAll(x => x.ApplicationName == applicationToDismiss);

                update();
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
                    Process.Start(plugin.WebsiteOrProgramAddress);
                }
            }
        }

        public void update()
        {
            notificationCategoryBox.Items.Clear();

            foreach (var plugin in plugins)
            {
                notificationCategoryBox.Items.Add(plugin.NotificationApplication + " (" + notifications.Count(x => x.ApplicationName == plugin.NotificationApplication).ToString() + ")");
            }
        }

        private List<Plugins.INotifier> plugins = new List<Plugins.INotifier>();
        private List<Objects.Notification> notifications = new List<Objects.Notification>();

        private void SimpleNotificationForm_Load(object sender, EventArgs e)
        {

        }

        private void detailedViewButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Visible = false;
            this.Enabled = false;
            this.parentForm.PushNotifications(this.notifications, true);
            this.parentForm.Visible = true;
            this.parentForm.Enabled = true;
        }
    }
}
