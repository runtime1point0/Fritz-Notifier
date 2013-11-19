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

            foreach (string fileName in System.IO.Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "*.dll", System.IO.SearchOption.TopDirectoryOnly))
            {
                System.Reflection.Assembly pluginAssembly = System.Reflection.Assembly.LoadFrom(fileName);

                var plugInTypes = pluginAssembly.GetTypes().Where(x => typeof(Plugins.INotifier).IsAssignableFrom(x));

                foreach (Type pluginType in plugInTypes)
                {
                    plugins.Add(Activator.CreateInstance(pluginType) as Plugins.INotifier);
                }
            }
        }

        private void ReadSavedOptions()
        {
            foreach (Plugins.INotifier plugin in plugins)
            {
                // find options from plugin.NotificationApplication in configuration file and set up correct notificationsettings
            }
        }

        private List<Plugins.INotifier> plugins = new List<Plugins.INotifier>();
    }
}
