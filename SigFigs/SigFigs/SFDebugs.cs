using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigFigs.SigFigs;

namespace SigFigs
{
    class SFDebugs
    {
        static void Main(string[] args)
        {
            //Test 1
            SigFig x = int.MaxValue;
            Console.WriteLine("Base Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x + x;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 2
            x = short.MaxValue;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x + x;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 3
            x = new SigFig( long.MaxValue);
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x + x;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 4
            x = int.MaxValue;
            SigFig neg = int.MinValue;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            Console.WriteLine("Base Negative Num: " + neg.ToString());
            Console.WriteLine("Base Negative Num: " + neg.ToString(true));
            x = x + neg;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press ENTER to continue...");
            Console.Read();
        }
    }
}
