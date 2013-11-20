using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FritzNotifier.Objects
{
    public class Option
    {
        public Option(int optionId, List<int> gestures, List<int> numerics)
        {
            this.optionId = optionId;
            this.gestures = gestures;
            this.numerics = numerics;
        }

        public Option(int optionId, List<int> gestures, List<int> numerics, bool active)
        {
            this.optionId = optionId;
            this.gestures = gestures;
            this.numerics = numerics;
            this.Active = active;
        }

        /// <summary>
        /// Each notifier must make sure each option it creates has a unique OptionId within other options associated with the notifier
        /// </summary>
        public int OptionId { get { return optionId; } }
        private readonly int optionId;

        /// <summary>
        /// Whether or not the user has selected to use this particular notification
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gestures associated with this option.  Might have no gestures with a particular option, one gesture, or more than one gesture if gestures are set up conditionally based on which <see cref="Numerics"/> are entered.
        /// </summary>
        public List<int> Gestures { get { return gestures; } }
        private readonly List<int> gestures;

        /// <summary>
        /// Numeric values associated with this option.  Might have no numbers with a particular option, one number for a count or a time frame, or more than one number for some combinations of counts and time frames.
        /// </summary>
        public List<int> Numerics { get { return numerics; } }
        private readonly List<int> numerics;
    }
}
