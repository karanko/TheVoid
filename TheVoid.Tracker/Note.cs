using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid.Tracker
{
    public class Step
    {
        public int Note;
        public int Velocity = 100;
        public int Length;
        public bool Enabled = true;
    }

    public class Track
    {
        public Track()
        {
            Steps = new List<Step>();
            for(int i = 0;i < 32;i++)
            {
                Steps.Add(new Step() { Enabled = true, Note = ((i % 4) * 12) + 36, Velocity = 99, Length = 69 });
            }

        }
        public int Channel;
        public List<Step> Steps;
        public bool Mute = false;
        public bool Solo = false;

    }


}
