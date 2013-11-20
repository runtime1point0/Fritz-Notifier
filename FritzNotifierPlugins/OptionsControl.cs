using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FritzNotifier.Plugins
{
    public partial class OptionsControl : UserControl
    {
        public event EventHandler OptionsChanged;

        public OptionsControl()
        {
            InitializeComponent();
        }

        private List<Objects.Option> options;
        public List<Objects.Option> Options{
            get 
            {
                return options;
            }
        }

        public OptionsControl(List<Objects.Option> initialValues)
        {
            InitializeComponent();
            SetOptionValues(initialValues);
        }

        protected virtual void SetOptionValues(List<Objects.Option> initialValues)
        {
            this.options = initialValues;
        }

        private void ApplyChangesButton_Click(object sender, EventArgs e)
        {
            // change initialOptions based off of screen
            ApplyChanges(ref options);
        }

        // Invoke the OptionsChanged event; called whenever option changes are saved
        protected virtual void OnChanged(EventArgs e)
        {
            if (OptionsChanged != null)
                OptionsChanged(this, e);
        }

        protected virtual void ApplyChanges(ref List<Objects.Option> initialOptions)
        {
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
        }
    }
}
