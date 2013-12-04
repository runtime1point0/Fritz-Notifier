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
    public partial class SimpleViewForm : Form
    {

        NotificationForm parentForm;

        public SimpleViewForm()
        {
            InitializeComponent();
        }

        public SimpleViewForm(NotificationForm parent, List<Plugins.INotifier> parentNotifiers, List<Objects.Notification> parentNotifications)
        {
            InitializeComponent();

            this.parentForm = parent;
            this.simpleViewControl.InitializeNotificationsCount(parentNotifiers, parentNotifications);
        }

        public void update()
        {
            simpleViewControl.update();
        }

        private void detailedViewButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Visible = false;
            this.Enabled = false;
            this.parentForm.PushNotifications(this.simpleViewControl.Notifications, true);
            this.parentForm.Visible = true;
            this.parentForm.Enabled = true;
        }
    }
}
