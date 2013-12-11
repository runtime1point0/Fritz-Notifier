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

        public FacebookNotifier()
        {
            if (appClient == null)
            {
                var appAccessTokenLong = System.Configuration.ConfigurationManager.AppSettings.Get("fbAppIdLong");
                var appAccessToken = System.Configuration.ConfigurationManager.AppSettings.Get("fbAppId");
                appClient = new FacebookClient(appAccessTokenLong);

                DeleteAllCurrentTestUsers(appAccessTokenLong, appAccessToken);
                CreateTwoTestFriendUsers(appAccessTokenLong, appAccessToken);
            }
        }

        private void DeleteAllCurrentTestUsers(string appAccessTokenLong, string appAccessToken)
        {
            dynamic usersResult = appClient.Get(string.Format("{0}/accounts/test-users", appAccessToken), new { });
            if (usersResult["data"].Count > 0)
            {
                foreach (dynamic data in usersResult["data"])
                {
                    dynamic id = data["id"];

                    dynamic deleteUserResult = appClient.Delete(string.Format("{0}", id), new { access_token=data["access_token"] });
                }
            }
        }

        private void CreateTwoTestFriendUsers(string appAccessTokenLong, string appAccessToken)
        {
            dynamic userResult = appClient.Post(string.Format("{0}/accounts/test-users", appAccessToken), new { installed = true, name = "Fritz Test", permissions = "manage_notifications" });
            userClient = new FacebookClient((string)(userResult["access_token"]));
            userId = userResult["id"];

            string friendId;
            dynamic user2Result = appClient.Post(string.Format("{0}/accounts/test-users", appAccessToken), new { installed = true, name = "Fritz Talker" });
            var user2Client = new FacebookClient((string)(user2Result["access_token"]));
            friendId = user2Result["id"];

            userClient.Post(string.Format("{0}/friends/{1}", userId, friendId), new {});
            user2Client.Post(string.Format("{0}/friends/{1}", friendId, userId), new {});
        }

        System.Random sr = new System.Random();

        public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
        {
            var notifications = new List<Objects.Notification>(options.Count);
            if (options.Count(x => x.Active) > 0)
            {
                if (appClient == null)
                {
                    var appAccessTokenLong = System.Configuration.ConfigurationManager.AppSettings.Get("fbAppIdLong");
                    var appAccessToken = System.Configuration.ConfigurationManager.AppSettings.Get("fbAppId");
                    appClient = new FacebookClient(appAccessTokenLong);

                    dynamic userResult = appClient.Post(string.Format("{0}/accounts/test-users", appAccessToken), new { installed = true, name = "Fritz Test", permissions = "manage_notifications" });
                    userClient = new FacebookClient((string)(userResult["access_token"]));
                    userId = userResult["id"];
                }

                try
                {
                    DateTime currentDateLocal = DateTime.Now;
                    DateTime currentDate = currentDateLocal.ToUniversalTime();
                    //DateTime currentDate = DateTime.Now.ToUniversalTime();
                    foreach (Objects.Option option in options.Where(x => x.Active))
                    {
                        switch ((FacebookOptionId)option.OptionId)
                        {
                            case FacebookOptionId.NewNotification:

                                DateTime ePoch = new DateTime(1970, 1, 1, 0, 0, 0);
                                // Unix timestamp is seconds past epoch

                                var unixTimestampLastAccessed = DateTimeConvertor.ToUnixTime(option.LastAccessed);

                                //dynamic result = userClient.Get("fql", new { q = "SELECT author_id, body, source FROM message" });
                                dynamic result = userClient.Get("fql", new { q = "SELECT title_text, updated_time FROM notification WHERE recipient_id = " + userId });

                                if (result["data"].Count > 0)
                                {
                                    int index = 0;
                                    foreach (dynamic data in result["data"])
                                    {
                                        if (data["updated_time"] > unixTimestampLastAccessed)
                                        {
                                            var newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, (int)option.Gestures[0], "New Facebook notification: " + data["title_text"], null, currentDateLocal);
                                            option.LastAccessed = currentDate;
                                            Console.WriteLine("Setting last {0}", option.LastAccessed);

                                            notifications.Add(newMessageNotification);
                                        }
                                        index++;
                                    }
                                }
                                break;
                        }
                    }
                }
                catch (System.Net.WebException wex)
                {
                    Console.WriteLine("Facebook did not recognize the credentials. Response from Facebook: " + wex.Message);
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
