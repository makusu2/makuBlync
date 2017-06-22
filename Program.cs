using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlyncLightTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            //Application.Run(form);
            while (true)
            {
                form.BlankTicket = !form.BlankTicket;
            }
        }
    }
}
