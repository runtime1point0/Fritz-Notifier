using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FritzNotifier.Facebook
{
    public partial class FacebookOptionsControl : Plugins.OptionsControl
    {
        public FacebookOptionsControl() : base()
        {
            InitializeComponent();
        }

        public FacebookOptionsControl(List<Objects.Option> initialValues)
        {
            InitializeComponent();
            SetOptionValues(initialValues);
        }

        protected override void SetOptionValues(List<Objects.Option> initialValues)
        {
            foreach (Objects.Option option in initialValues)
            {
                switch ((FacebookNotifier.FacebookOptionId)option.OptionId)
                {
                    case FacebookNotifier.FacebookOptionId.NewMessage:
                        ReadMessageCheckBox.Checked = option.Active;
                        break;
                }
            }
        }
    }
}
