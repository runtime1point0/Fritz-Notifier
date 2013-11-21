using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace FritzNotifier
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();
        }

        private class EmptyNotifier : Plugins.INotifier
        {
            public Plugins.OptionsControl CreateOptionsControl(List<Objects.Option> initialValues)
            {
                throw new NotImplementedException();
            }

            public List<Objects.Option> GetAllAvailableOptions()
            {
                throw new NotImplementedException();
            }

            public string NotificationApplication
            {
                get { return string.Empty; }
            }

            public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
            {
                throw new NotImplementedException();
            }

            public string WebsiteOrProgramAddress
            {
                get { throw new NotImplementedException(); }
            }
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            LoadPlugins();
            ReadSavedOptions();

            List<Plugins.INotifier> pluginsWithBlank = new List<Plugins.INotifier>(plugins.Count);
            pluginsWithBlank.Add(new EmptyNotifier());
            pluginsWithBlank.AddRange(plugins);
            notificationToConfigureComboBox.DataSource = pluginsWithBlank;
            notificationToConfigureComboBox.DisplayMember = "NotificationApplication";
            notificationToConfigureComboBox.ValueMember = "NotificationApplication";

            ActivateTimer();

            // temporary
            //TestFirst();
        }

        private void ActivateTimer()
        {
            if (plugins != null)
            {
                // if any plugin options are active across any of the pluginoptions associated with any application
                if (pluginOptions.Any(pluginNamePluginOptionsPair => pluginNamePluginOptionsPair.Value.Any(option => option.Active)))
                {
                    if (checkNotifications == null)
                    {
                        checkNotifications = new Timer();
                        checkNotifications.Interval = 1000 * 60; // 60 seconds
                        checkNotifications.Tick += checkNotifications_Tick;
                        checkNotifications_Tick(checkNotifications, EventArgs.Empty); // testing for first time
                        checkNotifications.Start();
                    }
                }
                else
                {
                    if (checkNotifications != null)
                    {
                        checkNotifications.Stop();
                        checkNotifications.Tick -= checkNotifications_Tick;
                        checkNotifications.Dispose();
                        checkNotifications = null;
                    }
                }
            }
            else
            {
                if (checkNotifications != null)
                {
                    checkNotifications.Stop();
                    checkNotifications.Tick -= checkNotifications_Tick;
                    checkNotifications.Dispose();
                    checkNotifications = null;
                }
            }

        }

        void checkNotifications_Tick(object sender, EventArgs e)
        {
            foreach (Plugins.INotifier plugin in plugins)
            {
                var newNotifications = plugin.TestForNotifications(pluginOptions[plugin.NotificationApplication]);
                notifications.AddRange(newNotifications);
                // update simple view count
                PushNotifications(newNotifications, false);
            }
        }

        internal void PushNotifications(List<Objects.Notification> newNotifications, bool clearPrevious)
        {
            if (clearPrevious)
            {
                notificationTableLayoutPanel.Controls.Clear();
            }
            foreach (var newNotification in newNotifications)
            {
                notificationTableLayoutPanel.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
                var notificationControl = new NotificationControl();
                notificationControl.SetupScreen(newNotification);
                notificationControl.DismissNotification += notificationControl_DismissNotification;
                notificationControl.ReplyNotification += notificationControl_ReplyNotification;
                notificationTableLayoutPanel.Controls.Add(notificationControl);
                notificationTableLayoutPanel.SetCellPosition(notificationControl, new TableLayoutPanelCellPosition(0, 0));
            }
        }

        void notificationControl_ReplyNotification(object sender, NotificationControl.ReplayNotificationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void notificationControl_DismissNotification(object sender, NotificationControl.DismissNotificationEventArgs e)
        {
            notifications.Remove(e.notification);
            PushNotifications(notifications, true);
        }

        private void TestFirst()
        {
            notifications.AddRange(plugins[0].TestForNotifications(pluginOptions[plugins[0].NotificationApplication]));
        }

        private void LoadPlugins()
        {
            //var catalog = new System.ComponentModel.Composition.Hosting.DirectoryCatalog(@".\");

            //var container = new System.ComponentModel.Composition.Hosting.CompositionContainer(catalog);

            //container.ComposeParts(this);


            // add any predefined ones here
            plugins.Add(new Twitter.TwitterNotifier());
            plugins.Add(new Facebook.FacebookNotifier());

            if (System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + @"plugins\"))
            {
                foreach (string fileName in System.IO.Directory.GetFiles(System.Windows.Forms.Application.StartupPath + @"plugins\", "*.dll", System.IO.SearchOption.TopDirectoryOnly))
                {
                    System.Reflection.Assembly pluginAssembly = System.Reflection.Assembly.LoadFrom(fileName);

                    var plugInTypes = pluginAssembly.GetTypes().Where(x => typeof(Plugins.INotifier).IsAssignableFrom(x));

                    foreach (Type pluginType in plugInTypes)
                    {
                        var plugin = Activator.CreateInstance(pluginType) as Plugins.INotifier;
                        plugins.Add(plugin);
                    }
                }
            }
        }

        private void ReadSavedOptions()
        {
            System.Xml.Linq.XDocument doc = null;

            if (System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\settings.xml"))
            {
                doc = System.Xml.Linq.XDocument.Load(System.Windows.Forms.Application.StartupPath + @"\settings.xml");
            }

            foreach (Plugins.INotifier plugin in plugins)
            {
                /* example of settings file that would store the selected options so they can be reloaded the next time the application loads
                 * <Settings>
                 *  <Setting Application="Twitter">
                 *      <Option Id="1" Active="true"><Numerics><Numeric>20</Numeric></Numerics></Option>
                 *      <Option Id="3" Active="false"><Gestures><Gesture>1</Gesture></Gestures></Option>
                 *  </Setting>
                 * </Settings>
                 */
                // find options from plugin.NotificationApplication in configuration file and set up correct notificationsettings

                System.Xml.Linq.XElement settingElement = null;
                if (doc != null)
                {
                    settingElement = (from item in doc.Descendants("Setting") where item.Attributes("Application").FirstOrDefault().ToString() == plugin.NotificationApplication select item).FirstOrDefault();
                }
                SetupPluginOptions(plugin, settingElement);
            }
        }

        private void SetupPluginOptions(Plugins.INotifier plugin, System.Xml.Linq.XElement settingElement)
        {
            var options = plugin.GetAllAvailableOptions();

            if (settingElement != null)
            {
                foreach (var optionElement in (from configuredOption in settingElement.Descendants("Options") select configuredOption))
                {
                    var numericsElement = optionElement.Element("Numerics");
                    var numerics = new List<int>();
                    // TODO: loop through and set up all numerics

                    var gesturesElement = optionElement.Element("Gestures");
                    var gestures = new List<int>();
                    // TODO: loop through and set up all gestures

                    var active = Convert.ToBoolean(optionElement.Attribute("Active").Value);

                    int index = options.FindIndex(x => x.OptionId == Convert.ToInt32(optionElement.Attribute("Id").Value));

                    var newOption = new Objects.Option(Convert.ToInt32(optionElement.Attribute("Id").Value), gestures, numerics, active);
                    if (index == -1)
                    {
                        options.Add(newOption);
                    }
                    else
                    {
                        options[index] = newOption;
                    }
                }
            }

            pluginOptions[plugin.NotificationApplication] = options;
        }

        private List<Plugins.INotifier> plugins = new List<Plugins.INotifier>();
        private Dictionary<string, List<Objects.Option>> pluginOptions = new Dictionary<string, List<Objects.Option>>();
        private List<Objects.Notification> notifications = new List<Objects.Notification>();
        private SimpleNotificationForm childForm;
        private Timer checkNotifications;

        private void quickOverViewButton_Click(object sender, EventArgs e)
        {
            if (this.childForm == null)
            {
                childForm = new SimpleNotificationForm(this, this.notifications);
            }

            this.Visible = false;
            this.Enabled = false;
            childForm.update();
            childForm.Enabled = true;
            childForm.Visible = true;
            //childForm.ShowDialog(this);
        }

        private void notificationToConfigureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pluginOptions.ContainsKey(notificationToConfigureComboBox.SelectedValue.ToString()))
            {
                for (int i = editingOptionsControlHolderPanel.Controls.Count - 1; i >= 0; i--)
                {
                    editingOptionsControlHolderPanel.Controls[i].Dispose();
                }
                var optionsControl = plugins.Single(x => x.NotificationApplication == notificationToConfigureComboBox.SelectedValue.ToString()).CreateOptionsControl(pluginOptions[notificationToConfigureComboBox.SelectedValue.ToString()]);
                optionsControl.OptionsChanged += optionsControl_OptionsChanged;
                editingOptionsControlHolderPanel.Controls.Add(optionsControl);
            }
            else
            {
                for (int i = editingOptionsControlHolderPanel.Controls.Count - 1; i >= 0; i--)
                {
                    editingOptionsControlHolderPanel.Controls[i].Dispose();
                }
                editingOptionsControlHolderPanel.Controls.Add(new Plugins.OptionsControl());
            }
        }

        void optionsControl_OptionsChanged(object sender, EventArgs e)
        {
            var optionsControl = sender as Plugins.OptionsControl;

            pluginOptions[notificationToConfigureComboBox.SelectedValue.ToString()] = optionsControl.Options;

            ActivateTimer();
        }
    }
}
