using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Blynclight;

namespace BlyncLightTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Light form = new Light();
        }
    }
    public partial class Light
    {
        private BlynclightController makuController = new BlynclightController();
        public Light()
        {
            makuController.InitBlyncDevices();
            this.InfLoop();
        }

        public void InfLoop()
        {
            Random rnd = new Random();
            int[] steps = { 0, 0, 0 };
            byte[] vals = { 120, 120, 120 };
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    steps[i] = steps[i] + 1;
                    vals[i] = (byte)(255 * Math.Pow((Math.Abs(Math.Sin(i + steps[i] * (i + 1) * Math.PI / 1800))), 2));
                }
                makuController.TurnOnRGBLights(0, vals[0], vals[1], vals[2]);
            }

        }
        private bool blankTicket = false;
        public bool BlankTicket
        {
            get{return this.blankTicket;}
            set
            {
                this.blankTicket = value;
                if (value)
                {
                    makuController.TurnOnRedLight(0);
                }
                else
                {
                    makuController.TurnOnGreenLight(0);
                }
            }
        }
    }
}
