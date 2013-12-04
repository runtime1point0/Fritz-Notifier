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
                    case FacebookNotifier.FacebookOptionId.NewNotification:
                        ReactToNotificationsCheckBox.Checked = option.Active;
                        switch ((Plugins.Gesture)option.Gestures[0])
                        {
                            case Plugins.Gesture.Happy:
                                gestureComboBox.Text = "Happy";
                                break;
                            case Plugins.Gesture.Surprised:
                                gestureComboBox.Text = "Surprised";
                                break;
                            case Plugins.Gesture.Awkward:
                                gestureComboBox.Text = "Awkward";
                                break;
                        }
                        break;
                }
            }

            base.SetOptionValues(initialValues);
        }

        protected override void ApplyChanges(ref List<Objects.Option> initialOptions)
        {
            var newNotificationOption = initialOptions.Single(x => x.OptionId == (int)FacebookNotifier.FacebookOptionId.NewNotification);
            newNotificationOption.Active = ReactToNotificationsCheckBox.Checked;
            switch ((gestureComboBox.SelectedItem ?? "Neutral").ToString())
            {
                case "Happy":
                    newNotificationOption.Gestures[0] = (int)Plugins.Gesture.Happy;
                    break;
                case "Surprised":
                    newNotificationOption.Gestures[0] = (int)Plugins.Gesture.Surprised;
                    break;
                case "Awkward":
                    newNotificationOption.Gestures[0] = (int)Plugins.Gesture.Awkward;
                    break;
                case "Neutral":
                    newNotificationOption.Gestures[0] = (int)Plugins.Gesture.Neutral;
                    break;
            }
        }
    }
}
