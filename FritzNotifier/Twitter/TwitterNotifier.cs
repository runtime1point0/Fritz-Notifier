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
        internal enum TwitterOptionId
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

        //public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
        //{
        //    var notifications = new List<Objects.Notification>(options.Count);

        //    //if (options.Count(x => x.Active) > 0)
        //    {
        //        var auth = new LinqToTwitter.SingleUserAuthorizer
        //        {
        //            Credentials = new LinqToTwitter.SingleUserInMemoryCredentials
        //            {
        //                ConsumerKey = System.Configuration.ConfigurationManager.AppSettings.Get("consumerKey"),
        //                ConsumerSecret = System.Configuration.ConfigurationManager.AppSettings.Get("consumerSecret"),
        //                //AccessToken = "accessToken",
        //                //AccessTokenSecret = "accessTokenSecret"
        //                TwitterAccessToken = System.Configuration.ConfigurationManager.AppSettings.Get("accessToken"),
        //                TwitterAccessTokenSecret = System.Configuration.ConfigurationManager.AppSettings.Get("accessTokenSecret")
        //            }
        //        };

        //        auth.Authorize();

        //        using (var ctx = new LinqToTwitter.TwitterContext(auth))
        //        {


        //            //try
        //            //{
        //            //    //Account account = accounts.SingleOrDefault();
        //            //    Account account = ctx.Account.Single(acct => acct.Type == AccountType.VerifyCredentials && acct.SkipStatus == true);
        //            //    //var account = twitterCtx.Account
        //            //    //    .Where(t => t.Type == AccountType.VerifyCredentials)
        //            //    //    .FirstOrDefault(t => t.SkipStatus == true);
        //            //    User user = account.User;
        //            //    Status tweet = user.Status ?? new Status();
        //            //    Console.WriteLine("User (#" + user.Identifier.ID
        //            //                        + "): " + user.Identifier.ScreenName
        //            //                        + "\nTweet: " + tweet.Text
        //            //                        + "\nTweet ID: " + tweet.StatusID + "\n");

        //            //    Console.WriteLine("Account credentials are verified.");
        //            //}
        //            //catch (System.Net.WebException wex)
        //            //{
        //            //    Console.WriteLine("Twitter did not recognize the credentials. Response from Twitter: " + wex.Message);
        //            //}

        //            var testMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, "Test sender" + " sent message " + "message 1", "New message from " + "Test sender", DateTime.Now);
        //            var testSimpleMessage = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, "simple notification", null, DateTime.Now);

        //            notifications.Add(testMessageNotification);
        //            notifications.Add(testSimpleMessage);
        //            return notifications;

        //            try
        //            {
        //                DateTime currentDate = DateTime.Now;
        //                foreach (Objects.Option option in options.Where(x => x.Active))
        //                {
        //                    switch ((TwitterOptionId)option.OptionId)
        //                    {
        //                        case TwitterOptionId.TweetCount:
        //                            // if enough time has passed since we last accessed this
        //                            if ((currentDate - option.LastAccessed).TotalMinutes > option.Numerics[0])
        //                            {
        //                            int tweetCount =
        //                                (from tweet in ctx.Status
        //                                 where tweet.Type == StatusType.Home &&
        //                                 tweet.CreatedAt > option.LastAccessed
        //                                 select tweet).Count();

        //                                if (tweetCount > 0)
        //                                {
        //                                    var newTweetCountNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, tweetCount.ToString() + " new tweets.", tweetCount.ToString() + " new tweets.", currentDate);
        //                                        option.LastAccessed = currentDate;
        //                                        notifications.Add(newTweetCountNotification);
        //                                }
        //                            }
        //                            break;
        //                        case TwitterOptionId.DirectMessage:
        //                            var directMsgs =
        //                                (from dm in ctx.DirectMessage
        //                                 where dm.Type == DirectMessageType.SentTo &&
        //                                 dm.CreatedAt > option.LastAccessed
        //                                 select dm).ToList();
        //                            foreach (var directMsg in directMsgs)
        //                            {
        //                                // handle appropriately
        //                                var newDirectMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, directMsg.Sender.Name + " sent message " + directMsg.Text, "New message from " + directMsg.Sender.Name, currentDate);
        //                                notifications.Add(newDirectMessageNotification);
        //                                option.LastAccessed = currentDate;
        //                            }

        //                            break;
        //                    }
        //                }
        //            }
        //            catch (System.Net.WebException wex)
        //            {
        //                Console.WriteLine("Twitter did not recognize the credentials. Response from Twitter: " + wex.Message);
        //            }
        //        }
        //    }

        //    return notifications;
        //}

        System.Random sr = new System.Random();
        public List<Objects.Notification> TestForNotifications(List<Objects.Option> options)
        {
            var notifications = new List<Objects.Notification>(options.Count);

            if (options.Count(x => x.Active) > 0)
            {
                DateTime currentDate = DateTime.Now;
                foreach (Objects.Option option in options.Where(x => x.Active))
                {
                    switch ((TwitterOptionId)option.OptionId)
                    {
                        case TwitterOptionId.TweetCount:
                            // if enough time has passed since we last accessed this
                            if ((currentDate - option.LastAccessed).TotalMinutes > option.Numerics[0])
                            {
                                int tweetCount = sr.Next(51);

                                if (tweetCount > 0)
                                {
                                    var newTweetCountNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, tweetCount.ToString() + " new tweets.", tweetCount.ToString() + " new tweets.", currentDate);
                                    option.LastAccessed = currentDate;
                                    notifications.Add(newTweetCountNotification);
                                }
                            }
                            break;
                        case TwitterOptionId.DirectMessage:

                            int messageCount = sr.Next(3); // between 0 and 2 possible messages
                            for (int i = 0; i < messageCount; i++)
                            {
                                string name = string.Empty;

                                switch (sr.Next(3))
                                {
                                    case 0:
                                        name = "@coolperson1";
                                        break;
                                    case 1:
                                        name = "@myfriend";
                                        break;
                                    case 2:
                                        name = "@fritz020202";
                                        break;
                                }

                                string msg = string.Empty;

                                switch (sr.Next(3))
                                {
                                    case 0:
                                        msg = "Hello!  How are you?";
                                        break;
                                    case 1:
                                        msg = "Did you see the score of the game?";
                                        break;
                                    case 2:
                                        msg = "Call me please.";
                                        break;
                                }

                                var newDirectMessageNotification = new FritzNotifier.Objects.Notification(this.NotificationApplication, this.WebsiteOrProgramAddress, 0, name + " sent message " + msg, "New message from " + name, currentDate);
                                notifications.Add(newDirectMessageNotification);
                                option.LastAccessed = currentDate;
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
                DateTime defaultLastCheckedDate = currentDate.AddMilliseconds(-defaultPollingInterval);
                foreach (Objects.Option option in options.Where(x => x.Active))
                {
                    switch ((TwitterOptionId)option.OptionId)
                    {
                        case TwitterOptionId.TweetCount:
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
