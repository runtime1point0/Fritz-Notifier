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
        public TwitterOptionsControl() : base()
        {
            InitializeComponent();
        }

        public TwitterOptionsControl(List<Objects.Option> initialValues)
        {
            InitializeComponent();
            SetOptionValues(initialValues);
        }

        protected override void SetOptionValues(List<Objects.Option> initialValues)
        {
            foreach (Objects.Option option in initialValues)
            {
                switch ((TwitterNotifier.TwitterOptionId)option.OptionId)
                {
                    case TwitterNotifier.TwitterOptionId.TweetCount:
                        TweetCountCheckbox.Checked = option.Active;
                        TweetCountMinutesNumericUpDown.Value = option.Numerics[0];
                        break;
                    case TwitterNotifier.TwitterOptionId.DirectMessage:
                        ReadDirectMessagecheckBox.Checked = option.Active;
                        break;
                }
            }

            base.SetOptionValues(initialValues);
        }

        protected override void ApplyChanges(ref List<Objects.Option> initialOptions)
        {
            var tweetCountOption = initialOptions.Single(x => x.OptionId == (int)TwitterNotifier.TwitterOptionId.TweetCount);
            tweetCountOption.Active = TweetCountCheckbox.Checked;
            tweetCountOption.Numerics[0] = Convert.ToInt32(TweetCountMinutesNumericUpDown.Value);

            var directMessageOption = initialOptions.Single(x => x.OptionId == (int)TwitterNotifier.TwitterOptionId.DirectMessage);
            directMessageOption.Active = ReadDirectMessagecheckBox.Checked;
        }
    }
}
