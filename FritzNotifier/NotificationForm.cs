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

            // temporary
            TestFirst();
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
            //plugins.Add(new Twitter.TwitterNotifier());
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
                /*
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

        private void quickOverViewButton_Click(object sender, EventArgs e)
        {
            if (this.childForm == null)
            {
                childForm = new SimpleNotificationForm(this, this.notifications);
            }

            this.Visible = false;
            this.Enabled = false;
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
                editingOptionsControlHolderPanel.Controls.Add(
                    plugins.Single(x => x.NotificationApplication == notificationToConfigureComboBox.SelectedValue.ToString()).CreateOptionsControl(pluginOptions[notificationToConfigureComboBox.SelectedValue.ToString()]));
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
    }
}
