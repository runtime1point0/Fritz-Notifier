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

        public SimpleNotificationForm(NotificationForm parent, List<Objects.Notification> parentNotifications)
        {
            InitializeComponent();
            twitterOptions = twitterPlugin.GetAllAvailableOptions();

            notificationCategoryBox.Items.Clear();
            notificationCategoryBox.Items.Add(twitterPlugin.NotificationApplication + " (0)");

            notificationCategoryBox.Items.Add("Facebook (0)");

            this.parentForm = parent;
            this.notifications = parentNotifications;

            update();

        }

        private void dismissButton_Click(object sender, EventArgs e)
        {

            try
            {

                string applicationToDismiss = notificationCategoryBox.SelectedItem.ToString().Substring(0, notificationCategoryBox.SelectedItem.ToString().IndexOf(" ("));

                List<Objects.Notification> notificationsToRemove = new List<Objects.Notification>();

                foreach (Objects.Notification notificationToCheck in this.notifications)
                {
                    if (notificationToCheck.ApplicationName == applicationToDismiss)
                    {
                        notificationsToRemove.Add(notificationToCheck);
                    }
                }

                foreach (Objects.Notification notificationToRemove in notificationsToRemove)
                {
                    this.notifications.Remove(notificationToRemove);
                }

                update();
            }
            catch (NullReferenceException exception)
            {
                // Ignore the call
            }

        }

        private void goToSiteButton_Click(object sender, EventArgs e)
        {

            try
            {
                // if implement plugin collection, search for appropriate one here
                string item = notificationCategoryBox.SelectedItem.ToString().Substring(0, notificationCategoryBox.SelectedItem.ToString().IndexOf(" ("));

                if (item == twitterPlugin.NotificationApplication)
                {
                    Process.Start(twitterPlugin.WebsiteOrProgramAddress);
                }
                else
                {
                    Process.Start("http://" + "facebook" + ".com");
                }
            }
            catch (NullReferenceException excep)
            {
                // Ignore the event
            }
        }

        public void update()
        {

            for (int i = 0; i < notificationCategoryBox.Items.Count; i++)
            {
                // Remove the (#) count from the end of the line at the index in the listbox.
                notificationCategoryBox.Items[i] = notificationCategoryBox.Items[i].ToString().Substring(0, notificationCategoryBox.Items[i].ToString().IndexOf("("));
                int count = 0;

                foreach (Objects.Notification notificationToCheckNameAgainst in this.notifications)
                {

                    if (notificationCategoryBox.Items[i].ToString().Trim() == notificationToCheckNameAgainst.ApplicationName.Trim())
                    {
                        count += 1;
                    }

                }

                notificationCategoryBox.Items[i] += "(" + count.ToString() + ")";
                Console.WriteLine(count);

            }
        }

        private Plugins.INotifier twitterPlugin = new Twitter.TwitterNotifier();
        private List<Objects.Option> twitterOptions = new List<Objects.Option>();
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
