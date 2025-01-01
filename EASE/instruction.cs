using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASE
{
    internal class instruction
    {
        private static void PrintHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");
        }

        private static void PrintFooter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WaitForKeyPress()
        {
            Console.WriteLine("\tPress any key to continue.............");
            Console.ReadKey();
            Console.Clear();
        }

        public static void playNumSequenceRecall()
        {
            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tThe game shows a sequence of number for a");
            Console.WriteLine("\tdefinite period of time. \n");
            Console.WriteLine("\t    Example : ");
            Console.WriteLine("\t\tThe given number is : 7\n");
            PrintFooter();
            Console.WriteLine("\t\tTime remaining : 3 seconds\n");
            WaitForKeyPress();

            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t    Example : ");
            Console.WriteLine("\t\tThe given number is : ?\n");
            PrintFooter();
            Console.WriteLine("\t\tWhat was the number ? : (answer)\n");
            WaitForKeyPress();
        }

        public static void playGuessNum()
        {
            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tThe game produces a random positive integer");
            Console.WriteLine("\tthe number may vary depending on the difficulty\n");
            Console.WriteLine("\t    Example : ");
            Console.WriteLine("\t\tThe number is : 47\n");
            PrintFooter();
            WaitForKeyPress();

            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t    Example : (47) ");
            Console.WriteLine("\t\tGuess a number between 1-100\n");
            PrintFooter();
            Console.WriteLine("\t    Enter your guess : 75 (User answer)\n");
            WaitForKeyPress();

            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t    Example : (47) ");
            Console.WriteLine("\t\t      75 is higher!\n");
            Console.WriteLine("\tNow the user knows that the random number is");
            Console.WriteLine("\tbelow 75\n");
            PrintFooter();
            WaitForKeyPress();
        }

        public static void playRepeatPattern()
        {
            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tThe game shows a sequence of symbols for a");
            Console.WriteLine("\tdefinite period of time. \n");
            Console.WriteLine("\t    Example : ");
            Console.WriteLine("\t\tFinal output string : #@#\n");
            PrintFooter();
            Console.WriteLine("\t\tTime remaining : 3 seconds\n");
            WaitForKeyPress();

            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t    Example : ");
            Console.WriteLine("\t\tFinal output string : ?\n");
            PrintFooter();
            Console.WriteLine("\t\tWhat was the answer ? : (answer)\n");
            WaitForKeyPress();
        }

        public static void playMathify()
        {
            PrintHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tThe game creates a random mathematical equation\n");
            Console.WriteLine("\t    Example : ");
            Console.WriteLine("\t\t3 + 3 X 4");
            PrintFooter();
            Console.WriteLine("\t\tWhat's the answer? : \n");
            WaitForKeyPress();
        }
    }
}
