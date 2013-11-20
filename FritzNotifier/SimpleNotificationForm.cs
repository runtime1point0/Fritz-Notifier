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
        public SimpleNotificationForm()
        {
            InitializeComponent();
        }

        private void dismissButton_Click(object sender, EventArgs e)
        {
            
        }

        private void goToSiteButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
            Process.Start("http://" + "facebook" + ".com");
        }
    }
}
