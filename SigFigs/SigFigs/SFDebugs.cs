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
            //Test 1: addition
            SigFig x = int.MaxValue;
            Console.WriteLine("Base Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x + x;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 2: short
            x = short.MaxValue;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x + x;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 3: long
            x = new SigFig( long.MaxValue);
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x + x;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 4: adding negatives
            x = int.MaxValue;
            SigFig neg = int.MinValue;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            Console.WriteLine("Base Negative Num: " + neg.ToString());
            Console.WriteLine("Base Negative Num: " + neg.ToString(true));
            x = x + neg;
            Console.WriteLine("Num after addition: " + x.ToString());
            Console.WriteLine("Num after addition: " + x.ToString(true));

            //Test 5:
            x = 999999998;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x++;
            Console.WriteLine("Num after ++: " + x.ToString());
            Console.WriteLine("Num after ++: " + x.ToString(true));
            x--;
            Console.WriteLine("Num after --: " + x.ToString());
            Console.WriteLine("Num after --: " + x.ToString(true));
            Console.WriteLine("ToString(int) test " + x.ToString(5));

            //Final loop Test
            x = 2;
            int p1 = Console.CursorLeft;
            int p2 = Console.CursorTop;
            while(true)
            {
                Console.SetCursorPosition(p1, p2);
                Console.WriteLine("\nIncremented number: " + x + "                                         ");
                x += (x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x);
                Console.Write("Press ENTER to continue...");
                Console.Read();
            }
        }
    }
}
