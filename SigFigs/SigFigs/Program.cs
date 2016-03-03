using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigFigs.SigFigs;

namespace SigFigs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test 1
            SigFig x = 999999999999990;
            Console.WriteLine("Base Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x + x;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 2
            SigFig a = (short)1200;
            Console.WriteLine("\nBase Num: " + a.ToString());



            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press ENTER to continue...");
            Console.Read();
        }
    }
}
