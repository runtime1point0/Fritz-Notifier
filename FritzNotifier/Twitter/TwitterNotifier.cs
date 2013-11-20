using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;

namespace FritzNotifier.Twitter
{
    // built in notifier for twitter
    class TwitterNotifier : Plugins.INotifier
    {
        private enum TwitterOptionId
        {
            TweetCount = 1,
            DirectMessage = 2,
        }

        public string NotificationApplication
        {
            get { return "Twitter"; }
        }

        public string WebsiteOrProgramAddress
        {
            get { return "http://www.twitter.com"; }
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

            //if (options.Count(x => x.Active) > 0)
            {
                var auth = new LinqToTwitter.SingleUserAuthorizer
                {
                    Credentials = new LinqToTwitter.SingleUserInMemoryCredentials
                    {
                        ConsumerKey = System.Configuration.ConfigurationManager.AppSettings.Get("consumerKey"),
                        ConsumerSecret = System.Configuration.ConfigurationManager.AppSettings.Get("consumerSecret"),
                        //AccessToken = "accessToken",
                        //AccessTokenSecret = "accessTokenSecret"
                        TwitterAccessToken = System.Configuration.ConfigurationManager.AppSettings.Get("accessToken"),
                        TwitterAccessTokenSecret = System.Configuration.ConfigurationManager.AppSettings.Get("accessTokenSecret")
                    }
                };

                auth.Authorize();

                using (var ctx = new LinqToTwitter.TwitterContext(auth))
                {


                    //try
                    //{
                    //    //Account account = accounts.SingleOrDefault();
                    //    Account account = ctx.Account.Single(acct => acct.Type == AccountType.VerifyCredentials && acct.SkipStatus == true);
                    //    //var account = twitterCtx.Account
                    //    //    .Where(t => t.Type == AccountType.VerifyCredentials)
                    //    //    .FirstOrDefault(t => t.SkipStatus == true);
                    //    User user = account.User;
                    //    Status tweet = user.Status ?? new Status();
                    //    Console.WriteLine("User (#" + user.Identifier.ID
                    //                        + "): " + user.Identifier.ScreenName
                    //                        + "\nTweet: " + tweet.Text
                    //                        + "\nTweet ID: " + tweet.StatusID + "\n");

                    //    Console.WriteLine("Account credentials are verified.");
                    //}
                    //catch (System.Net.WebException wex)
                    //{
                    //    Console.WriteLine("Twitter did not recognize the credentials. Response from Twitter: " + wex.Message);
                    //}


                    try
                    {
                        foreach (Objects.Option option in options/*.Where(x => x.Active)*/)
                        {
                            switch ((TwitterOptionId)option.OptionId)
                            {
                                case TwitterOptionId.TweetCount:
                                    //System.Windows.Forms.MessageBox.Show("Looking for Tweet Count");
                                    break;
                                case TwitterOptionId.DirectMessage:
                                    var directMsgs =
                                        (from dm in ctx.DirectMessage
                                         where dm.Type == DirectMessageType.Show &&
                                         dm.CreatedAt > option.LastAccessed
                                         select dm).ToList();
                                    foreach (var directMsg in directMsgs)
                                    {
                                        // handle appropriately
                                        var newNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, 0, directMsg.Sender.Name + " sent message " + directMsg.Text, null, DateTime.Now);
                                        notifications.Add(newNotification);
                                    }

                                    break;
                            }
                        }
                    }
                    catch (System.Net.WebException wex)
                    {
                        Console.WriteLine("Twitter did not recognize the credentials. Response from Twitter: " + wex.Message);
                    }
                }
            }

            return notifications;
        }
    }
}
