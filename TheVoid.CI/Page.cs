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

    }
    public class Pattern
    {
        private Dictionary<int,bool> list = new Dictionary<int,bool>();
        public int Length = 8;
        public int MaxSteps
        {
            get
            {
                int result = Length;
                foreach (int steps in list.Keys)
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
            if(list.Keys.Contains(step))
            {
                return list[step];
            }
            else { 
                return false; 
            }
        }
        public void WriteStep(int step, bool value)
        {
            if (list.Keys.Contains(step))
            {
                list[step] = value;
            }
            else
            {
                list.Add(step, value);
            }
        }
    }
}
