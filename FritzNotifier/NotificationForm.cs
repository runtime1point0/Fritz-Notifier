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

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            LoadPlugins();
            ReadSavedOptions();
        }

        private void LoadPlugins()
        {
            //var catalog = new System.ComponentModel.Composition.Hosting.DirectoryCatalog(@".\");

            //var container = new System.ComponentModel.Composition.Hosting.CompositionContainer(catalog);

            //container.ComposeParts(this);


            // add any predefined ones here

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
            if (System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\settings.xml"))
            {
                System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load(System.Windows.Forms.Application.StartupPath + @"\settings.xml");
                foreach (Plugins.INotifier plugin in plugins)
                {
                    /*
                     * <Settings>
                     *  <Setting Application="Twitter">
                     *      <Option Id="1"><Numerics><Numeric>20</Numeric></Numerics></Option>
                     *      <Option Id="3"><Gestures><Gesture>1</Gesture></Gestures></Option>
                     *  </Setting>
                     * </Settings>
                     */
                    // find options from plugin.NotificationApplication in configuration file and set up correct notificationsettings
                    var setting = (from item in doc.Descendants("Setting") where item.Attributes("Application").FirstOrDefault().ToString() == plugin.NotificationApplication select item).FirstOrDefault();
                    if (setting != null)
                    {
                        // look through each option in XML and create new options with correct values
                    }
                }
            }
        }

        private List<Plugins.INotifier> plugins = new List<Plugins.INotifier>();
    }
}
