//#define additionTests
#define divisionTests
//#define logicTests
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
            SigFig x, neg;
#if additionTests
            //Test 1: addition
            x = int.MaxValue;
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
            neg = int.MinValue;
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
#endif
#if divisionTests
            //Test 6: %
            x = 14;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x % 3;
            Console.WriteLine("Num after remainder: " + x.ToString());
            Console.WriteLine("Num after remainder: " + x.ToString(true));
            x = long.MaxValue;
            Console.WriteLine("long Base Num: " + x.ToString());
            Console.WriteLine("long Base Num: " + x.ToString(true));
            x = x % 2;
            Console.WriteLine("long Num after remainder: " + x.ToString());
            Console.WriteLine("long Num after remainder: " + x.ToString(true));

            //Test: /
            x = int.MaxValue;
            x += (x + x + x + x + x);
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x.Divide(x);
            Console.WriteLine("Num after division: " + x.ToString());
            Console.WriteLine("Num after division: " + x.ToString(true));
#endif
#if logicTests
            //Test 7: == !=
            x = 500;
            neg = 501;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            if(x == neg)
                Console.WriteLine("Yay!");
            if (x != neg)
                Console.WriteLine("Nay!");
            neg--;
            if (x == neg)
                Console.WriteLine("Yay!");
            if (x != neg)
                Console.WriteLine("Nay!");

            //Test: > < <= >=
            x = 501;
            neg = 500;
            Console.WriteLine("\nBase Num x: " + x.ToString());
            Console.WriteLine("Base Num neg: " + neg.ToString());
            if (x > neg)
                Console.WriteLine("> yes");
            else Console.WriteLine("> no");
            if (x < neg)
                Console.WriteLine("< yes");
            else Console.WriteLine("< no");
            if (x <= neg)
                Console.WriteLine("<= yes");
            else Console.WriteLine("<= no");
            if (x >= neg)
                Console.WriteLine(">= yes");
            else Console.WriteLine(">= no");
#endif
            //Test: -
            x = int.MaxValue;
            x += x + x + x + x + x + x;
            Console.WriteLine("\nBase Num: " + x.ToString());
            Console.WriteLine("Base Num: " + x.ToString(true));
            x = x - 1000000000;
            Console.WriteLine("Num after subtraction: " + x.ToString());
            Console.WriteLine("Num after subtraction: " + x.ToString(true));

            //Final loop Test
            x = 2;
            neg = 2;
            int p1 = Console.CursorLeft;
            int p2 = Console.CursorTop;
            while(true)
            {
                Console.SetCursorPosition(p1, p2);
                Console.WriteLine("\nIncremented number: " + x + "                                         ");
                x += (x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x + x);
                Console.WriteLine("Decremented number: " + neg + "                                         ");
                neg = neg - 10000;
                Console.Write("Press ENTER to continue...");
                Console.Read();
            }
        }
    }
}
