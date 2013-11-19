using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FritzNotifier.Twitter
{
    // built in notifier for twitter
    class TwitterNotifier : Plugins.INotifier
    {
        public string NotificationApplication
        {
            get { return "Twitter"; }
        }

        public Plugins.OptionsControl CreateOptionsControl(List<Objects.Option> initialValues)
        {
            return new Twitter.TwitterOptionsControl(initialValues);
        }

        public List<Objects.Option> GetAllAvailableOptions()
        {
            var tweetCountNumerics = new List<int>(1);
            tweetCountNumerics.Add(10); // default to 10 minutes in between tweet count updates

            var tweetCountOption = new Objects.Option(1, null, tweetCountNumerics); // id 1 is the tweet count notification option for Twitter

            var directMessageOption = new Objects.Option(2, null, null); // id 2 is the direct message notification option for Twitter

            var options = new List<Objects.Option>(2);
            options.Add(tweetCountOption);
            options.Add(directMessageOption);

            return options;
        }

        public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
        {
            var notifications = new List<Objects.Notification>(options.Count);

            if (options.Count(x => x.Active) > 0)
            {
                var auth = new LinqToTwitter.SingleUserAuthorizer
                {
                    Credentials = new LinqToTwitter.SingleUserInMemoryCredentials
                    {
                        ConsumerKey = "consumerKey",
                        ConsumerSecret = "consumerSecret",
                        //AccessToken = "accessToken",
                        //AccessTokenSecret = "accessTokenSecret"
                        TwitterAccessToken = "accessToken",
                        TwitterAccessTokenSecret = "accessTokenSecret"
                    }
                };

                auth.Authorize();

                var ctx = new LinqToTwitter.TwitterContext(auth);


                //return auth;

                foreach (Objects.Option option in options.Where(x => x.Active))
                {
                    switch (option.OptionId)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                }
            }

            return notifications;
        }
    }
}
