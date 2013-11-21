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
            var newMessageOption = new Objects.Option((int)FacebookOptionId.NewNotification, null, null); // id 2 is the direct message notification option for Twitter

            var options = new List<Objects.Option>(1);
            options.Add(newMessageOption);

            return options;
        }

        FacebookClient appClient = null;
        FacebookClient userClient = null;
        string userId = null;

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
                    DateTime currentDate = DateTime.Now;
                    foreach (Objects.Option option in options.Where(x => x.Active))
                    {
                        switch ((FacebookOptionId)option.OptionId)
                        {
                            case FacebookOptionId.NewNotification:

                                DateTime ePoch = new DateTime(1970, 1, 1, 0, 0, 0);
                                //var unixTimestampLastAccessed = System.Convert.ToInt64((option.LastAccessed - ePoch).TotalSeconds);
                                var unixTimestampLastAccessed = System.Convert.ToInt64((DateTime.Now.AddDays(-10) - ePoch).TotalSeconds);

                                //dynamic result = userClient.Get("fql", new { q = "SELECT author_id, body, source FROM message" });
                                dynamic result = userClient.Get("fql", new { q = "SELECT title_text, updated_time FROM notification WHERE recipient_id = " + userId });

                                if (result["data"].Count > 0)
                                {
                                    if (result["data"]["updated_time"] > unixTimestampLastAccessed.ToString())
                                    {

                                        var newMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, 0, "New Facebook notification.", result["data"]["title_text"], currentDate);
                                        option.LastAccessed = currentDate;
                                        notifications.Add(newMessageNotification);
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
    }
}
