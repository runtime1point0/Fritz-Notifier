using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FritzNotifier.Twitter
{
    public partial class TwitterOptionsControl : Plugins.OptionsControl
    {
        public TwitterOptionsControl()
        {
            InitializeComponent();
        }

        public TwitterOptionsControl(List<Objects.Option> initialValues)
        {
            InitializeComponent();
            SetOptionValues(initialValues);
        }

        public override void SetOptionValues(List<Objects.Option> initialValues)
        {
        }
    }
}
