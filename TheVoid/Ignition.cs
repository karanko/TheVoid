using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TheVoid
{
    public class Ignition
    {
   

        public Ignition()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Enabled = false;
        //    aTimer.Interval = 500;
            aTimer.Elapsed += new ElapsedEventHandler(tick);
            this.bpm = 125;
        }
        private System.Timers.Timer aTimer;
        public int ticks = 0;
        //public object thisthing;
        public int beats = 4;
        public int bars = 4;
        public int steps
        {
            get
            {
                return beats;// *bars;
            }
        }
        public int step
        {
            get { return Convert.ToInt16(ticks%this.steps); }
          //  set { aTimer.Interval = Convert.ToInt16(value); }
        }
        public DateTime LastTick;
        public double milliseconds
        {
            get { return Convert.ToInt16(aTimer.Interval); }
            set { aTimer.Interval = Convert.ToInt16(value) ; }
        }

        public void Addeventhandler(ElapsedEventHandler x)
        {
            aTimer.Elapsed += x;
       }
        public double bpm
        {
            get { return Convert.ToInt16( 60000 /( aTimer.Interval *steps)); }
            set { aTimer.Interval = Convert.ToInt16((60000 / value) /steps); }
        }
        public bool running
        {
            get { Thread.CurrentThread.Priority = ThreadPriority.Highest; return aTimer.Enabled; }
            set { aTimer.Enabled = value ;  Thread.CurrentThread.Priority = ThreadPriority.Normal;}
        }

        public void Start()
        {
            aTimer.Enabled = true;
        }
        public void Stop()
        {
            aTimer.Enabled = false;
            ticks = 0;
        }
        private void tick(object source, ElapsedEventArgs e)
        {
            LastTick = e.SignalTime;
            ticks++;

        //    new Thread(this.thisthing).Start();
        }
    }
}
