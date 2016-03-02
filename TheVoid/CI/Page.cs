using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVoid.CI
{
    public class Page
    {
  
        public Pattern Pattern = new Pattern() { Length = 16 };
        public int Note;
        public int Vel = 90;
        public APC.LED led = APC.LED.Green;
        public bool Solo = false;
        public bool Mute = false;

    }
    public class Pattern
    {
        private Dictionary<int, bool> _steps = new Dictionary<int, bool>();
        public int Length = 8;
        public int MaxSteps
        {
            get
            {
                int result = Length;
                foreach (int steps in this._steps.Keys)
                {
                    if (steps > result)
                    {
                        result = steps;
                    }
                }
                return result;

            }

        }
        public bool RecallStep(int step)
        {
            if (_steps.Keys.Contains(step))
            {
                return _steps[step];
            }
            else
            {
                return false;
            }
        }
        public void WriteStep(int step, bool value)
        {
            if (_steps.Keys.Contains(step))
            {
                _steps[step] = value;
            }
            else
            {
                _steps.Add(step, value);
            }
        }
    public bool[] Steps
        {
            get
            {
                List<bool> x = new List<bool>();

                for (int i = 0; i <= Length; i++)
                {
                    x.Add(RecallStep(i));
                }

                return x.ToArray();
            }
            set { 
                    int i= 0;

                    foreach (var x in value)
                    {
                        if (RecallStep(i)!= x)
                        {
                            WriteStep(i,x);
                        }
                        i++;
                    }
            }
      
     }

        public void Clear()
        {
            _steps.Clear();
        }
    }
}
