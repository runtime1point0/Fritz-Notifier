using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;

namespace FritzNotifier.Facebook
{
    // built in notifier for twitter
    class FacebookNotifier : Plugins.INotifier
    {
        internal enum FacebookOptionId
        {
            NewNotification = 1,
        }

        public string NotificationApplication
        {
            get { return "Facebook"; }
        }

        public string WebsiteOrProgramAddress
        {
            get { return "http://www.facebook.com"; }
        }

        public Plugins.OptionsControl CreateOptionsControl(List<Objects.Option> initialValues)
        {
            return new Facebook.FacebookOptionsControl(initialValues);
        }

        public List<Objects.Option> GetAllAvailableOptions()
        {
            var newNotificationGestures = new List<int>(1);
            newNotificationGestures.Add((int)Plugins.Gesture.Happy); // default to Happy face

            var newNotificationOption = new Objects.Option((int)FacebookOptionId.NewNotification, newNotificationGestures, null);

            var options = new List<Objects.Option>(1);
            options.Add(newNotificationOption);

            return options;
        }

        FacebookClient appClient = null;
        FacebookClient userClient = null;
        string userId = null;

        System.Random sr = new System.Random();

        //public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
        //{
        //    var notifications = new List<Objects.Notification>(options.Count);

        //    if (options.Count(x => x.Active) > 0)
        //    {
        //        if (appClient == null)
        //        {
        //            var appAccessTokenLong = System.Configuration.ConfigurationManager.AppSettings.Get("fbAppIdLong");
        //            var appAccessToken = System.Configuration.ConfigurationManager.AppSettings.Get("fbAppId");
        //            appClient = new FacebookClient(appAccessTokenLong);

        //            dynamic userResult = appClient.Post(string.Format("{0}/accounts/test-users", appAccessToken), new { installed = true, name = "Fritz Test", permissions = "manage_notifications" });
        //            userClient = new FacebookClient((string)(userResult["access_token"]));
        //            userId = userResult["id"];
        //        }

        //        try
        //        {
        //            DateTime currentDate = DateTime.Now;
        //            foreach (Objects.Option option in options.Where(x => x.Active))
        //            {
        //                switch ((FacebookOptionId)option.OptionId)
        //                {
        //                    case FacebookOptionId.NewNotification:

        //                        DateTime ePoch = new DateTime(1970, 1, 1, 0, 0, 0);
        //                        //var unixTimestampLastAccessed = System.Convert.ToInt64((option.LastAccessed - ePoch).TotalSeconds);
        //                        var unixTimestampLastAccessed = System.Convert.ToInt64((DateTime.Now.AddDays(-10) - ePoch).TotalSeconds);

        //                        //dynamic result = userClient.Get("fql", new { q = "SELECT author_id, body, source FROM message" });
        //                        dynamic result = userClient.Get("fql", new { q = "SELECT title_text, updated_time FROM notification WHERE recipient_id = " + userId });

        //                        if (result["data"].Count > 0)
        //                        {
        //                            if (result["data"]["updated_time"] > unixTimestampLastAccessed.ToString())
        //                            {

        //                                var newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, (int)option.Gestures[0], "New Facebook notification: " + result["data"]["title_text"], null, currentDate);
        //                                option.LastAccessed = currentDate;
        //                                notifications.Add(newMessageNotification);
        //                            }
        //                        }
        //                        break;
        //                }
        //            }
        //        }
        //        catch (System.Net.WebException wex)
        //        {
        //            Console.WriteLine("Facebook did not recognize the credentials. Response from Facebook: " + wex.Message);
        //        }
        //    }

        //    return notifications;
        //}

        public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
        {
            var notifications = new List<Objects.Notification>(options.Count);

            if (options.Count(x => x.Active) > 0)
            {
                DateTime currentDate = DateTime.Now;
                foreach (Objects.Option option in options.Where(x => x.Active))
                {
                    switch ((FacebookOptionId)option.OptionId)
                    {
                        case FacebookOptionId.NewNotification:

                            /* 
                            DateTime ePoch = new DateTime(1970, 1, 1, 0, 0, 0);
                            //var unixTimestampLastAccessed = System.Convert.ToInt64((option.LastAccessed - ePoch).TotalSeconds);
                            var unixTimestampLastAccessed = System.Convert.ToInt64((DateTime.Now.AddDays(-10) - ePoch).TotalSeconds);
                              */

                            if (sr.Next(4) < 3) // 3 out of 4 will make notification
                            {
                                string emotion = "(neutral)";

                                switch ((Plugins.Gesture)option.Gestures[0])
                                {
                                    case Plugins.Gesture.Happy:
                                        emotion = "(Happy face! :-) ) ";
                                        break;
                                    case Plugins.Gesture.Awkward:
                                        emotion = "(-Awkward-)";
                                        break;
                                    case Plugins.Gesture.Surprised:
                                        emotion = "(SUPRISED!!!!)";
                                        break;
                                }

                                FritzNotifier.Objects.Notification newMessageNotification = null;
                                int app = sr.Next(4);
                                switch (app)
                                {
                                    case 0:
                                        newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, option.Gestures[0], emotion + "New Facebook notification: John has sent you a friend request.", null, currentDate);
                                        break;
                                    case 1:
                                        newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, option.Gestures[0], emotion + "New Facebook notification: Mary needs help with her Farmville farm", null, currentDate);
                                        break;
                                    case 2:
                                        newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, option.Gestures[0], emotion + "New Facebook notification: Fred needs your help with his Mafia in Mafia Wars.", null, currentDate);
                                        break;
                                    case 3:
                                        newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, option.Gestures[0], emotion + "New Facebook notification: Jenny has commented on one of your posts.", null, currentDate);
                                        break;
                                }
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
                DateTime currentDate = DateTime.Now;
                DateTime defaultLastCheckedDate = currentDate.AddSeconds(-defaultPollingInterval);
                foreach (Objects.Option option in options.Where(x => x.Active))
                {
                    switch ((FacebookOptionId)option.OptionId)
                    {
                        default:
                            option.LastAccessed = defaultLastCheckedDate;
                            break;
                    }
                }
            }
        }
    }
}
