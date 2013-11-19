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

        private readonly int optionId;
        public int OptionId { get { return optionId; } }

        public bool Active { get; set; }

        private readonly List<int> gestures;
        public List<int> Gestures { get { return gestures; } }

        private readonly List<int> numerics;
        public List<int> Numerics { get { return numerics; } }
    }
}
