using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FritzNotifier.Objects
{
    public class Notification
    {
        public Notification(string applicationName, int associatedGesture, string text, string speech) : this(applicationName, associatedGesture, text, speech, System.DateTime.Now) {}

        public Notification(string applicationName, int associatedGesture, string text, string speech, DateTime notificationTime)
        {
            this.ApplicationName = applicationName;
            this.AssociatedGesture = associatedGesture;
            this.Text = text;
            this.Speech = speech;
            this.NotificationTime = notificationTime;
        }

        /// <summary>
        /// Application that 
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gesture when this notification plays or replays.  0 for no gesture.
        /// </summary>
        public int AssociatedGesture { get; set; }

        /// <summary>
        /// Text to display in notification area when this runs.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Speech the robot will say aloud when this notification plays or replays.
        /// </summary>
        public string Speech { get; set; }

        /// <summary>
        /// When this notification originally occurred
        /// </summary>
        public DateTime NotificationTime { get; set; }
    }
}
