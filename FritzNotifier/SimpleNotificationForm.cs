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

        public SimpleNotificationForm(NotificationForm parent)
        {
            InitializeComponent();
            twitterOptions = twitterPlugin.GetAllAvailableOptions();

            notificationCategoryBox.Items.Clear();
            notificationCategoryBox.Items.Add(twitterPlugin.NotificationApplication);

            notificationCategoryBox.Items.Add("Facebook");

            this.parentForm = parent;
        }

        private void dismissButton_Click(object sender, EventArgs e)
        {
            
        }

        private void goToSiteButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
            // if implement plugin collection, search for appropriate one here
            if (notificationCategoryBox.SelectedValue.ToString() == twitterPlugin.NotificationApplication)
            {
                Process.Start(twitterPlugin.WebsiteOrProgramAddress);
            }
            else
            {
                Process.Start("http://" + "facebook" + ".com");
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
            this.Visible = false;
            this.Enabled = false;
            this.parentForm.Visible = true;
            this.parentForm.Enabled = true;

        }
    }
}
