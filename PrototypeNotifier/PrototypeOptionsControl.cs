using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FritzNotifier.Proto
{
    public partial class PrototypeOptionsControl : Plugins.OptionsControl
    {
        public PrototypeOptionsControl () : base()
        {
            InitializeComponent();
        }

        public PrototypeOptionsControl(List<Objects.Option> initialValues)
        {
            InitializeComponent();
            SetOptionValues(initialValues);
        }

        protected override void SetOptionValues(List<Objects.Option> initialValues)
        {
            foreach (Objects.Option option in initialValues)
            {
                switch ((PrototypeNotifier.PrototypeOptionId)option.OptionId)
                {
                    case PrototypeNotifier.PrototypeOptionId.CountOption:
                        TweetCountCheckbox.Checked = option.Active;
                        TweetCountMinutesNumericUpDown.Value = option.Numerics[0];
                        break;
                    case PrototypeNotifier.PrototypeOptionId.CheckedOnlyOption:
                        ReadDirectMessagecheckBox.Checked = option.Active;
                        break;
                    case PrototypeNotifier.PrototypeOptionId.GestureOption:
                        ReactToNotificationsCheckBox.Checked = option.Active;
                        break;
                }
            }

            base.SetOptionValues(initialValues);
        }

        protected override void ApplyChanges(ref List<Objects.Option> initialOptions)
        {
            var tweetCountOption = initialOptions.Single(x => x.OptionId == (int)PrototypeNotifier.PrototypeOptionId.CountOption);
            tweetCountOption.Active = TweetCountCheckbox.Checked;
            tweetCountOption.Numerics[0] = Convert.ToInt32(TweetCountMinutesNumericUpDown.Value);

            var directMessageOption = initialOptions.Single(x => x.OptionId == (int)PrototypeNotifier.PrototypeOptionId.CheckedOnlyOption);
            directMessageOption.Active = ReadDirectMessagecheckBox.Checked;

            var newNotificationOption = initialOptions.Single(x => x.OptionId == (int)PrototypeNotifier.PrototypeOptionId.GestureOption);
            newNotificationOption.Active = ReactToNotificationsCheckBox.Checked;
        }
    }
}
