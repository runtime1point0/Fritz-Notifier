using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FritzNotifier.Proto
{
    // example notifier
    class PrototypeNotifier : Plugins.INotifier
    {
        internal enum PrototypeOptionId
        {
            CountOption = 1,
            GestureOption = 2,
            CheckedOnlyOption = 3,
        }

        public string NotificationApplication
        {
            get { return "Example"; }
        }

        public string WebsiteOrProgramAddress
        {
            get { return "http://www.google.com"; }
        }

        public Plugins.OptionsControl CreateOptionsControl(List<Objects.Option> initialValues)
        {
            return new Proto.PrototypeOptionsControl(initialValues);
        }

        public List<Objects.Option> GetAllAvailableOptions()
        {
            var firstCountNumerics = new List<int>(1);
            firstCountNumerics.Add(5); // default to 10 minutes

            var countOption = new Objects.Option((int)PrototypeOptionId.CountOption, null, firstCountNumerics);

            var newGestures = new List<int>(1);
            newGestures.Add((int)Plugins.Gesture.Happy); // default to Happy face

            var newGestureOption = new Objects.Option((int)PrototypeOptionId.GestureOption, newGestures, null);

            var checkedOnlyOption = new Objects.Option((int)PrototypeOptionId.CheckedOnlyOption, null, null);

            var options = new List<Objects.Option>(3);
            options.Add(countOption);
            options.Add(newGestureOption);
            options.Add(checkedOnlyOption);

            return options;
        }

        System.Random sr = new System.Random();
        public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
        {
            var notifications = new List<Objects.Notification>(options.Count);

            if (options.Count(x => x.Active) > 0)
            {
                DateTime currentDate = DateTime.Now.ToUniversalTime();
                foreach (Objects.Option option in options.Where(x => x.Active))
                {
                    switch ((PrototypeOptionId)option.OptionId)
                    {
                        case PrototypeOptionId.CountOption:
                            // if enough time has passed since we last accessed this
                            if ((currentDate - option.LastAccessed).TotalMinutes > option.Numerics[0])
                            {
                                int count = sr.Next(51);

                                if (count > 0)
                                {
                                    var newTweetCountNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, count.ToString() + " special notifications.", count.ToString() + " special notifications.", currentDate);
                                    option.LastAccessed = currentDate;
                                    notifications.Add(newTweetCountNotification);
                                }
                            }
                            break;
                        case PrototypeOptionId.CheckedOnlyOption:

                            int messageCount = sr.Next(3); // between 0 and 2 possible messages
                            for (int i = 0; i < messageCount; i++)
                            {
                                string msg = string.Empty;

                                switch (sr.Next(3))
                                {
                                    case 0:
                                        msg = "Message 1 occurred.";
                                        break;
                                    case 1:
                                        msg = "Message 2 occurred.";
                                        break;
                                    case 2:
                                        msg = "Message 3 occurred.";
                                        break;
                                }

                                var newDirectMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, msg, "Alert: " + msg, currentDate);
                                notifications.Add(newDirectMessageNotification);
                                option.LastAccessed = currentDate;
                            }

                            break;
                        case PrototypeOptionId.GestureOption:
                            if (sr.Next(5) < 3) // 3 out of 4 will make notification
                            {
                                string emotion = "(neutral)";
                                Plugins.Gesture gesture = Plugins.Gesture.Neutral;
                                switch (sr.Next(4))
                                {
                                    case 1:
                                        emotion = "Happy";
                                        gesture = Plugins.Gesture.Happy;
                                        break;
                                    case 2:
                                        emotion = "Awkward";
                                        gesture = Plugins.Gesture.Awkward;
                                        break;
                                    case 3:
                                        emotion = "Surprised";
                                        gesture = Plugins.Gesture.Surprised;
                                        break;
                                }
                                FritzNotifier.Objects.Notification newMessageNotification = null;
                                        newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, (int) gesture, emotion + " gesture received", null, currentDate);
                                option.LastAccessed = currentDate;
                                notifications.Add(newMessageNotification);
                            }
                            break;
                    }
                }

            }
            return notifications;
        }

        public void ResetLastAccessed(List<Objects.Option> options, int defaultPollingInterval)
        {
            if (options.Count(x => x.Active) > 0)
            {
                DateTime currentDate = DateTime.Now.ToUniversalTime();
                DateTime defaultLastCheckedDate = currentDate.AddMilliseconds(-defaultPollingInterval);
                foreach (Objects.Option option in options.Where(x => x.Active))
                {
                    switch ((PrototypeOptionId)option.OptionId)
                    {
                        case PrototypeOptionId.CountOption:
                            option.LastAccessed = currentDate.AddMinutes(-option.Numerics[0]);
                            break;
                        default:
                            option.LastAccessed = defaultLastCheckedDate;
                            break;
                    }
                }
            }
        }    
    }
}
