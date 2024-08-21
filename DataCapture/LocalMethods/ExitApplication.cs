using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCapture.LocalMethods
{
    public class ExitApplication
    {
        public static void ExitApp()
        {
            Console.WriteLine("Press any key to close Client Data Capture: ");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}
