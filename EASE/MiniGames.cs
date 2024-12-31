using System;
using System.Linq;

namespace EASE
{
    internal class MiniGames
    {
        //playNumSequenceRecall
        public static void playNumSequenceRecall()
        {
            try
            {
                Console.Clear();
                bool playingNumSequenceRecall = true;

                while (playingNumSequenceRecall)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t\t1 : PLAY");
                    Console.WriteLine("\t\t2 : INSTRUCTIONS");
                    Console.WriteLine("\t\t3 : RETURN TO MINIGAMES MENU\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tEnter the number of your choice : ");

                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int numSequenceChoice) || numSequenceChoice < 1 || numSequenceChoice > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t      Input must be between 1-3");
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue;
                    }

                    switch (numSequenceChoice)
                    {
                        case 1:
                            NumberSequencePlayDifficulty();
                            break;
                        case 2:
                            Console.WriteLine("\tINSTRUCTIONS");
                            Console.WriteLine("\tPress any key to return...");
                            Console.ReadKey();
                            break;
                        case 3:
                            playingNumSequenceRecall = false; // Exit the loop and return to Minigames Menu
                            break;
                    }
                }

                Console.Clear(); // Clear the screen before returning
            }
            catch (Exception ex)
            {
                Program.errormessage();
            }
        }
        private static void NumberSequencePlayDifficulty()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\tPick Difficulty");
                Console.WriteLine("\t\t1 : Easy");
                Console.WriteLine("\t\t2 : Intermediate");
                Console.WriteLine("\t\t3 : Hard");
                Console.WriteLine("\t\t4 : Insane\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t-----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tEnter the number of your choice : ");
                int difficulty = Convert.ToInt16(Console.ReadLine());
                int difficultytimer = 0;
                switch (difficulty)
                {
                    case 1: difficultytimer = 8; break;
                    case 2: difficultytimer = 6; break;
                    case 3: difficultytimer = 4; break;
                    case 4: difficultytimer = 2; break;
                    default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\t      Input must be between 1-4"); Thread.Sleep(2000); NumberSequencePlayDifficulty(); break;
                }
                Console.Clear();
                NumberSequencePlay(difficultytimer);
            }
            catch (Exception ex)
            {
                Program.errormessage(); NumberSequencePlayDifficulty();
            }
        }
        private static void NumberSequencePlay(int difficultytimer)
        {
            try
            {
                Random random = new Random();
                bool playing = true;
                int min = 1; int max = 10;
                while (playing)
                {
                    int numguess = random.Next(min, max);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\tThe given number is : {numguess}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int seconds = difficultytimer; seconds > 0; seconds--)
                    {
                        Console.Write($"\r\t\tTime Remaining: {seconds}");
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\tThe given number is : ?\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t\tWhat was the number : ");
                    int answer = Convert.ToInt32(Console.ReadLine());
                    if (answer == numguess) { Console.WriteLine("You Are Correct"); Console.Clear(); min = min * 10; max = max * 10; }
                    if (answer != numguess)
                    {
                        numSequenceRecallTryAgain(numguess, min, max);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.errormessage(); NumberSequencePlay(difficultytimer);
            }
        }
        public static void numSequenceRecallTryAgain(int numguess, int min, int max)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t    You Are Incorrect");
                Console.WriteLine("\t\tThe correct answer was : " + numguess);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t-----------------------------------------");
                Console.WriteLine("\t-----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t       Would you like to try Again ?");
                Console.WriteLine("\t               Y : Yes");
                Console.WriteLine("\t               N : No");
                Console.WriteLine("\t       D : Pick A different Difficulty\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t\t\t: ");
                char response = Console.ReadLine().ToUpper().FirstOrDefault();

                if (response == 'Y')
                {
                    Console.Clear();
                    min = 1;
                    max = 10;
                    // Call your main method for Number Sequence Recall here
                }
                else if (response == 'N')
                {
                    Program.thanksforplaying();
                }
                else if (response == 'D')
                {
                    NumberSequencePlayDifficulty();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t      Input must be Y, N, or D only");
                    Thread.Sleep(2000);
                    numSequenceRecallTryAgain(numguess, min, max);
                }
            }
            catch (Exception ex)
            {
                Program.errormessage();
            }
        }

        //playGuessNum
        public static void playGuessNum()
        {
            try
            {
                Console.Clear();
                bool playingGuessNum = true;

                while (playingGuessNum)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t\t1 : PLAY");
                    Console.WriteLine("\t\t2 : INSTRUCTIONS");
                    Console.WriteLine("\t\t3 : RETURN TO MINIGAMES MENU\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tEnter the number of your choice : ");

                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int numSequenceChoice) || numSequenceChoice < 1 || numSequenceChoice > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t      Input must be between 1-3");
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue;
                    }

                    switch (numSequenceChoice)
                    {
                        case 1:
                            guessNumDifficulty();
                            break;
                        case 2:
                            Console.WriteLine("INSTRUCTIONS");
                            Console.WriteLine("Press any key to return...");
                            Console.ReadKey();
                            break;
                        case 3:
                            playingGuessNum = false; // Exit the loop and return to the Minigames Menu
                            break;
                    }
                }

                Console.Clear(); // Clear the screen before returning
            }
            catch (Exception)
            {
                Program.errormessage();
            }
        }
        public static void guessNumDifficulty()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\tPick Difficulty");
                Console.WriteLine("\t\t1 : Easy");
                Console.WriteLine("\t\t2 : Intermediate");
                Console.WriteLine("\t\t3 : Hard");
                Console.WriteLine("\t\t4 : Insane\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tEnter the number of your choice : ");
                int difficulty = Convert.ToInt16(Console.ReadLine());
                int maxnum = 0; int numberOfTries = 0;
                switch (difficulty)
                {
                    case 1: maxnum = 100; break;
                    case 2: maxnum = 200; break;
                    case 3: maxnum = 500; break;
                    case 4: maxnum = 1000; break;
                    default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\t      Input must be between 1-4"); Thread.Sleep(2000); guessNumDifficulty(); break;
                }
                Random random = new Random(); int numGuess = random.Next(1, maxnum);
                guessNumPlaying(maxnum, numberOfTries, numGuess);
            }
            catch (Exception ex)
            {
                Program.errormessage(); guessNumDifficulty();
            }
        }
        public static void guessNumPlaying(int maxnum, int numberOfTries, int numGuess)
        {
            try
            {
                int answer = 0;
                while (answer != numGuess)
                {
                    Console.Clear();
                    numberOfTries++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\tGuess a Number between 1-{maxnum}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t\tEnter your guess : "); answer = Convert.ToInt32(Console.ReadLine());
                    if (answer > maxnum || answer < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\t      Input must be between 1-{maxnum}"); Thread.Sleep(2000);
                        numberOfTries--;
                        guessNumPlaying(maxnum, numberOfTries, numGuess);
                        break;
                    }
                    if (answer < numGuess)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t------------------------------------------");
                        Console.WriteLine("\t------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\t\t\t{answer} is LOWER\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t------------------------------------------");
                        Console.WriteLine("\t------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (answer > numGuess)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t------------------------------------------");
                        Console.WriteLine("\t------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\t\t\t{answer} is HIGHER\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t------------------------------------------");
                        Console.WriteLine("\t------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (answer == numGuess)
                    {
                        guessNumTryAgain(answer, numberOfTries, maxnum, numGuess);
                    }
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                Program.errormessage(); guessNumPlaying(maxnum, numberOfTries, numGuess);
            }
        }
        public static void guessNumTryAgain(int answer, int numberOfTries, int maxnum, int numGuess)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\tCONGRATULATIONS {answer} WAS THE CORRECT ANSWER\n");
                Console.WriteLine($"\tIt took you {numberOfTries} tries");
                Console.WriteLine("\tto get the correct number");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t-----------------------------------------");
                Console.WriteLine("\t-----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\tWould you like to try Again ?");
                Console.WriteLine("\t\tY : Yes");
                Console.WriteLine("\t\tN : No");
                Console.WriteLine("\t\tD : Pick A different Difficulty\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t\t\t: ");
                char response = Console.ReadLine().ToUpper().FirstOrDefault();

                if (response == 'Y')
                {
                    answer = 0;
                    numberOfTries = 0;
                    guessNumPlaying(maxnum, numberOfTries, numGuess);
                }
                else if (response == 'N')
                {
                    Program.thanksforplaying();
                }
                else if (response == 'D')
                {
                    guessNumDifficulty();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t      Input must be Y, N, or D Only");
                    Thread.Sleep(2000);
                    guessNumTryAgain(answer, numberOfTries, maxnum, numGuess);
                }
            }
            catch (Exception ex)
            {
                Program.errormessage();
            }
        }

        //playRepeatPattern
        public static void playRepeatPattern()
        {
            Console.Clear();
            bool playingRepeatPattern = true;

            while (playingRepeatPattern)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t\t1 : PLAY");
                    Console.WriteLine("\t\t2 : INSTRUCTIONS");
                    Console.WriteLine("\t\t3 : RETURN TO MINIGAMES MENU\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t\tChoose between 1-3 : ");

                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int numSequenceChoice) || numSequenceChoice < 1 || numSequenceChoice > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t      Input must be between 1-3");
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue;
                    }

                    switch (numSequenceChoice)
                    {
                        case 1:
                            repeatPatternDiffculty();
                            break;
                        case 2:
                            Console.WriteLine("INSTRUCTIONS");
                            Console.WriteLine("Press any key to return...");
                            Console.ReadKey();
                            break;
                        case 3:
                            playingRepeatPattern = false; // Exit the loop to return to Minigames Menu
                            break;
                    }
                }
                catch (Exception)
                {
                    Program.errormessage();
                }
            }

            Console.Clear(); // Clear the screen before returning to the previous menu
        }
        public static void repeatPatternDiffculty()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\tPick Difficulty");
                Console.WriteLine("\t\t1 : Easy");
                Console.WriteLine("\t\t2 : Intermediate");
                Console.WriteLine("\t\t3 : Hard");
                Console.WriteLine("\t\t4 : Insane\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tEnter the number of your choice : ");
                int timer = 0; int difficulty = Convert.ToInt16(Console.ReadLine());

                switch (difficulty)
                {
                    case 1: timer = 8; break;
                    case 2: timer = 6; break;
                    case 3: timer = 4; break;
                    case 4: timer = 2; break;
                    default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\t      Input must be between 1-4"); Thread.Sleep(2000); repeatPatternDiffculty(); return;

                }
                playingRepeatPattern(timer);
            }
            catch (Exception ex)
            {
                Program.errormessage(); repeatPatternDiffculty();
            }
        }
        public static void playingRepeatPattern(int timer)
        {
            Random random = new Random();
            bool playing = true; string print = ""; int length = 0; string answer = "";
            while (playing)
            {
                Console.Clear();
                length++;
                for (int i = 0; i < length; i++)
                {
                    int num = random.Next(1, 6);
                    char characterToPrint = ' ';
                    switch (num)
                    {
                        case 1: characterToPrint = '*'; break;
                        case 2: characterToPrint = '@'; break;
                        case 3: characterToPrint = '#'; break;
                        case 4: characterToPrint = '$'; break;
                        case 5: characterToPrint = '%'; break;

                    }
                    print += characterToPrint;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n\t\tFinal output string: {print}\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                for (int seconds = timer; seconds > 0; seconds--)
                {
                    Console.Write($"\r\t\tTime Remaining: {seconds}");
                    Thread.Sleep(1000);
                }
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n\t\tFinal output string: ?\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t\tWhat was the answer : ");
                    Thread.Sleep(1000);
                    answer = Console.ReadLine();
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Input Cannot be Nothing"); Thread.Sleep(2000);
                }

                if (answer == print) { playing = true; }
                if (answer != print)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t{answer} WAS INCORRECT\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t-----------------------------------------");
                    Console.WriteLine("\t-----------------------------------------\n");
                    repeatPatternTryAgain(length, timer);
                }
            }
        }
        public static void repeatPatternTryAgain(int length, int timer)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t       Would you like to try Again ?");
                Console.WriteLine("\t               Y : Yes");
                Console.WriteLine("\t               N : No");
                Console.WriteLine("\t       D : Pick A different Difficulty\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t\t\t: ");
                char response = Console.ReadLine().ToUpper().FirstOrDefault();

                if (response == 'Y')
                {
                    Console.Clear();
                    playingRepeatPattern(timer);
                }
                else if (response == 'N')
                {
                    Program.thanksforplaying();
                }
                else if (response == 'D')
                {
                    repeatPatternDiffculty();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t      Input must be Y, N, or D Only");
                    Thread.Sleep(2000);
                    repeatPatternTryAgain(length, timer);
                }
            }
            catch (Exception ex)
            {
                Program.errormessage();
            }
        }

        //playMathify
        public static void playMathify()
        {
            Console.Clear();
            bool playingMathify = true;

            while (playingMathify)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t\t1 : PLAY");
                    Console.WriteLine("\t\t2 : INSTRUCTIONS");
                    Console.WriteLine("\t\t3 : RETURN TO MINIGAMES MENU\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tEnter the number of your choice: ");

                    string input = Console.ReadLine();

                    // Validate input
                    if (!int.TryParse(input, out int numSequenceChoice) || numSequenceChoice < 1 || numSequenceChoice > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t      Input must be between 1-3");
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue; // Prompt again without recursion
                    }

                    switch (numSequenceChoice)
                    {
                        case 1:
                            mathifyDifficulty(); // Call the gameplay difficulty method
                            break;
                        case 2:
                            Console.WriteLine("INSTRUCTIONS");
                            Console.WriteLine("Press any key to return...");
                            Console.ReadKey();
                            break;
                        case 3:
                            playingMathify = false; // Exit the loop to return to Minigames Menu
                            break;
                    }
                }
                catch (Exception)
                {
                    Program.errormessage(); // Display error message
                }
            }

            Console.Clear(); // Clear the screen before returning to the Minigames Menu
        }
        public static void mathifyDifficulty()
        {
            Console.Clear();
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\tPick Difficulty");
                Console.WriteLine("\t\t1 : Easy");
                Console.WriteLine("\t\t2 : Intermediate");
                Console.WriteLine("\t\t3 : Hard");
                Console.WriteLine("\t\t4 : Insane\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t-----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tEnter the number of your choice : ");
                int difficulty = Convert.ToInt16(Console.ReadLine());
                switch (difficulty)
                {
                    case 1: mathifyEasy(); break;
                    case 2: mathifyIntermediate(); break;
                    case 3: mathifyHard(); break;
                    case 4: mathifyInsane(); break;
                    default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\t      Input must be between 1-4"); Thread.Sleep(2000); mathifyDifficulty(); break;
                }

            }
            catch (Exception ex)
            {
                Program.errormessage(); playMathify();
            }
        }
        public static void mathifyEasy()
        {

            Console.Clear();
            try
            {
                Random random = new Random(); int maxnum = 5; int userAns = 0; int answer = 0;
                while (answer == userAns)
                {
                    answer = 0;
                    int num1 = random.Next(1, maxnum);
                    int num2 = random.Next(1, maxnum);

                    char operation1st = 'a';
                    int operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation1st = '+'; break;
                        case 2: operation1st = '-'; break;
                        case 3: operation1st = 'X'; break;
                        case 4: operation1st = '/'; break;
                    }

                    // first round of  operations
                    if (operation1st == '+') { answer = num1 + num2; }
                    if (num1 < num2 && operation1st == '-') { operation1st = '+'; answer = num1 + num2; }
                    if (operation1st == '-') { answer = num1 - num2; }
                    if (operation1st == 'X') { answer = num1 * num2; }
                    if (num1 % num2 != 0 && operation1st == '/') { operation1st = 'X'; answer = num1 * num2; }
                    if (operation1st == '/') { answer = num1 / num2; }


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t\t{num1} {operation1st} {num2}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tWhat is the answer ? : ");
                    userAns = Convert.ToInt32(Console.ReadLine());

                    if (answer == userAns) { correct(); }
                    if (answer != userAns) { mathifyTryAgain(answer); }

                    maxnum += 5;
                }

            }
            catch (Exception ex)
            {
                Program.errormessage(); mathifyEasy();
            }
        }
        public static void mathifyIntermediate()
        {
            Console.Clear();
            try
            {
                Random random = new Random(); int maxnum = 5; int userAns = 0; int answer = 0;
                while (answer == userAns)
                {
                    answer = 0;
                    int num1 = random.Next(1, maxnum);
                    int num2 = random.Next(1, maxnum);
                    int num3 = random.Next(1, maxnum);
                    char operation1st = 'a'; char operation2nd = 'a';
                    int operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation1st = '+'; break;
                        case 2: operation1st = '-'; break;
                        case 3: operation1st = 'X'; break;
                        case 4: operation1st = '/'; break;
                    }
                    operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation2nd = '+'; break;
                        case 2: operation2nd = '-'; break;
                        case 3: operation2nd = 'X'; break;
                        case 4: operation2nd = '/'; break;
                    }
                    // first round of  operations
                    if (operation1st == '+') { answer = num1 + num2; }
                    if (num1 < num2 && operation1st == '-') { operation1st = '+'; answer = num1 + num2; }
                    if (operation1st == '-') { answer = num1 - num2; }
                    if (operation1st == 'X') { answer = num1 * num2; }
                    if (num1 % num2 != 0 && operation1st == '/') { operation1st = 'X'; answer = num1 * num2; }
                    if (operation1st == '/') { answer = num1 / num2; }

                    // second round of  operations
                    if (operation2nd == '+') { answer = answer + num3; }
                    if (answer < num3 && operation2nd == '-') { operation2nd = '+'; answer = answer + num3; }
                    if (operation2nd == '-') { answer = answer - num3; }
                    if (operation2nd == 'X') { answer = answer * num3; }
                    if (answer % num3 != 0 && operation2nd == '/') { operation2nd = 'X'; answer = answer * num3; }
                    if (operation2nd == '/') { answer = answer / num3; }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t\t{num1} {operation1st} {num2} {operation2nd} {num3}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tWhat is the answer ? : ");
                    userAns = Convert.ToInt32(Console.ReadLine());

                    if (answer == userAns) { correct(); }
                    if (answer != userAns) { mathifyTryAgain(answer); }

                    maxnum += 5;
                }

            }
            catch (Exception ex)
            {
                Program.errormessage(); mathifyIntermediate();
            }
        }
        public static void mathifyHard()
        {
            Console.Clear();
            try
            {
                Random random = new Random(); int maxnum = 5; int userAns = 0; int answer = 0;
                while (answer == userAns)
                {
                    answer = 0;
                    int num1 = random.Next(1, maxnum);
                    int num2 = random.Next(1, maxnum);
                    int num3 = random.Next(1, maxnum);
                    int num4 = random.Next(1, maxnum);
                    char operation1st = 'a'; char operation2nd = 'a'; char operation3rd = 'a';
                    int operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation1st = '+'; break;
                        case 2: operation1st = '-'; break;
                        case 3: operation1st = 'X'; break;
                        case 4: operation1st = '/'; break;
                    }
                    operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation2nd = '+'; break;
                        case 2: operation2nd = '-'; break;
                        case 3: operation2nd = 'X'; break;
                        case 4: operation2nd = '/'; break;
                    }
                    operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation3rd = '+'; break;
                        case 2: operation3rd = '-'; break;
                        case 3: operation3rd = 'X'; break;
                        case 4: operation3rd = '/'; break;
                    }
                    // first round of  operations
                    if (operation1st == '+') { answer = num1 + num2; }
                    if (num1 < num2 && operation1st == '-') { operation1st = '+'; answer = num1 + num2; }
                    if (operation1st == '-') { answer = num1 - num2; }
                    if (operation1st == 'X') { answer = num1 * num2; }
                    if (num1 % num2 != 0 && operation1st == '/') { operation1st = 'X'; answer = num1 * num2; }
                    if (operation1st == '/') { answer = num1 / num2; }

                    // second round of  operations
                    if (operation2nd == '+') { answer = answer + num3; }
                    if (answer < num3 && operation2nd == '-') { operation2nd = '+'; answer = answer + num3; }
                    if (operation2nd == '-') { answer = answer - num3; }
                    if (operation2nd == 'X') { answer = answer * num3; }
                    if (answer % num3 != 0 && operation2nd == '/') { operation2nd = 'X'; answer = answer * num3; }
                    if (operation2nd == '/') { answer = answer / num3; }

                    // third round of  operations
                    if (operation3rd == '+') { answer = answer + num4; }
                    if (answer < num4 && operation3rd == '-') { operation3rd = '+'; answer = answer + num4; }
                    if (operation3rd == '-') { answer = answer - num4; }
                    if (operation3rd == 'X') { answer = answer * num4; }
                    if (answer % num4 != 0 && operation3rd == '/') { operation3rd = 'X'; answer = answer * num4; }
                    if (operation3rd == '/') { answer = answer / num4; }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t\t{num1} {operation1st} {num2} {operation2nd} {num3} {operation3rd} {num4}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tWhat is the answer ? : ");
                    userAns = Convert.ToInt32(Console.ReadLine());

                    if (answer == userAns) { correct(); }
                    if (answer != userAns) { mathifyTryAgain(answer); }

                    maxnum += 5;
                }

            }
            catch (Exception ex)
            {
                Program.errormessage(); mathifyHard();
            }
        }
        public static void mathifyInsane()
        {
            Console.Clear();
            try
            {
                Random random = new Random(); int maxnum = 5; int userAns = 0; int answer = 0;
                while (answer == userAns)
                {
                    answer = 0;
                    int num1 = random.Next(1, maxnum);
                    int num2 = random.Next(1, maxnum);
                    int num3 = random.Next(1, maxnum);
                    int num4 = random.Next(1, maxnum);
                    int num5 = random.Next(1, maxnum);
                    char operation1st = 'a'; char operation2nd = 'a'; char operation3rd = 'a'; char operation4th = 'a';
                    int operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation1st = '+'; break;
                        case 2: operation1st = '-'; break;
                        case 3: operation1st = 'X'; break;
                        case 4: operation1st = '/'; break;
                    }
                    operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation2nd = '+'; break;
                        case 2: operation2nd = '-'; break;
                        case 3: operation2nd = 'X'; break;
                        case 4: operation2nd = '/'; break;
                    }
                    operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation3rd = '+'; break;
                        case 2: operation3rd = '-'; break;
                        case 3: operation3rd = 'X'; break;
                        case 4: operation3rd = '/'; break;
                    }
                    operationRandom = random.Next(1, 5);
                    switch (operationRandom)
                    {
                        case 1: operation4th = '+'; break;
                        case 2: operation4th = '-'; break;
                        case 3: operation4th = 'X'; break;
                        case 4: operation4th = '/'; break;
                    }
                    // first round of  operations
                    if (operation1st == '+') { answer = num1 + num2; }
                    if (num1 < num2 && operation1st == '-') { operation1st = '+'; answer = num1 + num2; }
                    if (operation1st == '-') { answer = num1 - num2; }
                    if (operation1st == 'X') { answer = num1 * num2; }
                    if (num1 % num2 != 0 && operation1st == '/') { operation1st = 'X'; answer = num1 * num2; }
                    if (operation1st == '/') { answer = num1 / num2; }

                    // second round of  operations
                    if (operation2nd == '+') { answer = answer + num3; }
                    if (answer < num3 && operation2nd == '-') { operation2nd = '+'; answer = answer + num3; }
                    if (operation2nd == '-') { answer = answer - num3; }
                    if (operation2nd == 'X') { answer = answer * num3; }
                    if (answer % num3 != 0 && operation2nd == '/') { operation2nd = 'X'; answer = answer * num3; }
                    if (operation2nd == '/') { answer = answer / num3; }

                    // third round of  operations
                    if (operation3rd == '+') { answer = answer + num4; }
                    if (answer < num4 && operation3rd == '-') { operation3rd = '+'; answer = answer + num4; }
                    if (operation3rd == '-') { answer = answer - num4; }
                    if (operation3rd == 'X') { answer = answer * num4; }
                    if (answer % num4 != 0 && operation3rd == '/') { operation3rd = 'X'; answer = answer * num4; }
                    if (operation3rd == '/') { answer = answer / num4; }

                    // fourth round of  operations
                    if (operation4th == '+') { answer = answer + num5; }
                    if (answer < num5 && operation4th == '-') { operation4th = '+'; answer = answer + num5; }
                    if (operation4th == '-') { answer = answer - num5; }
                    if (operation4th == 'X') { answer = answer * num5; }
                    if (answer % num5 != 0 && operation4th == '/') { operation4th = 'X'; answer = answer * num5; }
                    if (operation4th == '/') { answer = answer / num5; }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t{num1} {operation1st} {num2} {operation2nd} {num3} {operation3rd} {num4} {operation4th} {num5}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tWhat is the answer ? : ");
                    userAns = Convert.ToInt32(Console.ReadLine());

                    if (answer == userAns) { correct(); }
                    if (answer != userAns) { mathifyTryAgain(answer); }

                    maxnum += 5;
                }

            }
            catch (Exception ex)
            {
                Program.errormessage(); mathifyInsane();
            }
        }
        public static void correct()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t      You are Correct!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }
        public static void mathifyTryAgain(int answer)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t    You Are Incorrect");
                Console.WriteLine($"\t\tThe correct answer was : {answer}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t-----------------------------------------");
                Console.WriteLine("\t-----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t       Would you like to try Again ?");
                Console.WriteLine("\t               Y : Yes");
                Console.WriteLine("\t               N : No");
                Console.WriteLine("\t       D : Pick A different Difficulty\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t\t\t: ");
                char response = Console.ReadLine().ToUpper().FirstOrDefault();

                if (response == 'Y')
                {
                    Console.Clear();
                    // Call the main method for Mathify here to restart the game
                    return;
                }
                else if (response == 'N')
                {
                    Program.thanksforplaying();
                }
                else if (response == 'D')
                {
                    mathifyDifficulty();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t      Input must be Y, N, or D only");
                    Thread.Sleep(2000);
                    mathifyTryAgain(answer);
                }
            }
            catch (Exception ex)
            {
                Program.errormessage();
            }
        }

        //playPictureMatching
        public static void playPictureMatching()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t===============================");
                Console.WriteLine("\n\t       Picture Matching\n");
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\tWelcome to Picture Matching!");

                // Define a list of words
                string[] allCards = { "Apple", "Banana", "Cherry", "Orange", "Grape", "Lemon", "Peach", "Plum", "Pear", "Berry" };

                // Randomly select 4 unique cards (adjust this number for more cards)
                Random random = new Random();
                string[] selectedCards = allCards.OrderBy(x => random.Next()).Take(4).ToArray();

                // Duplicate and shuffle cards
                string[] cards = selectedCards.Concat(selectedCards).OrderBy(x => random.Next()).ToArray();
                bool[] matched = new bool[cards.Length];
                int attempts = 0;

                while (matched.Any(m => !m))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t===============================");
                    Console.WriteLine("\n\t       Picture Matching\n");
                    Console.WriteLine("\t===============================");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n\tHere are the cards:");

                    // Display the cards
                    for (int i = 0; i < cards.Length; i++)
                    {
                        if (matched[i])
                            Console.Write($"\t[{i + 1}: Matched] ");
                        else
                            Console.Write($"\t[{i + 1}: ?] ");
                    }
                    Console.WriteLine();

                    // Get user input for the first and second cards
                    int firstIndex = GetCardIndex(cards.Length, matched, "first");
                    int secondIndex = GetCardIndex(cards.Length, matched, "second", firstIndex);

                    // Check for a match
                    if (cards[firstIndex] == cards[secondIndex])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\tYou found a match: {cards[firstIndex]}!");
                        matched[firstIndex] = matched[secondIndex] = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tNot a match. Try again.");
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    attempts++;
                    Thread.Sleep(1500); // Delay for better user experience
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\tCongratulations! You matched all the cards in {attempts} attempts.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\tPress any key to return to the main menu...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tAn error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static int GetCardIndex(int length, bool[] matched, string prompt, int excludeIndex = -1)
        {
            while (true)
            {
                Console.Write($"\tEnter the number for the {prompt} card: ");
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    if (index < 1 || index > length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\tInvalid input! Please enter a number between 1 and {length}.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (matched[index - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\tThis card is already matched. Please select another card.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (index - 1 == excludeIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\tYou cannot choose the same card twice. Please select another card.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        return index - 1;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tInvalid input! Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        //playWordAssociation
        public static void playWordAssociation()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t===============================");
                Console.WriteLine("\n\t    Welcome to Word Association!\n");
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\tEnter a word related to the given word.");
                Console.WriteLine("\tType 'exit' to stop.");

                string[] words = { "Sun", "Moon", "Star", "Ocean", "Forest", "Mountain", "River", "Tree", "Flower", "Grass", "Bird", "Fish", "Sky", "Cloud", "Beach", "Island", "Desert", "Rain", "Snow", "Wind" };
                Random random = new Random();
                HashSet<string> usedWords = new HashSet<string>(); // Track used words to avoid repetition
                string currentWord = words[random.Next(words.Length)];

                while (true)
                {
                    Console.WriteLine("\n\tThe word is: " + currentWord);
                    Console.Write("\tYour word: ");
                    string userWord = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(userWord))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tInput cannot be empty. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    if (userWord.ToLower() == "exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\tThanks for playing Word Association!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }

                    // Validate user word (optional logic for real-world apps)
                    if (userWord.Equals(currentWord, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tTry not to repeat the same word. Think of a related word!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tGreat choice! Here's another word.");
                    Console.ForegroundColor = ConsoleColor.White;

                    // Update current word and ensure no repetition
                    do
                    {
                        currentWord = words[random.Next(words.Length)];
                    } while (usedWords.Contains(currentWord));

                    usedWords.Add(currentWord);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tAn unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tPlease restart the game.");
            }
        }

        //playFindTheDifference
        public static void playFindTheDifference()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t           Welcome to Find the Difference!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");

            // Define the pairs of words with differences
            string[] pairs =
            {
        "ABCDEF|ABCDXF",
        "123456|123X56",
        "HELLOO|HELLOX",
        "WINDOW|WINDOX",
        "PYTHON|PYTHXN",
        "GUITAR|GUITAX",
        "KITTEN|KITTEN",  // This will result in no difference
        "PLANET|PLXNET",
        "FRAMES|FRAMEY",
        "CANDLE|CANDLX",
        "MARKER|MARKKR",
        "BUTTON|BUTHON",
        "POCKET|POCKXT",
        "DANGER|DANGRR",
        "CIRCLE|CIRCXE",
        "TABLES|TABLX",
        "PLANET|PLXNXT",
        "ISLAND|ISLAXD",
        "LADDER|LADDRR",
        "BRIDGE|BRIXGE"
    };

            // Select 5 random pairs from the array
            Random random = new Random();
            var selectedPairs = pairs.OrderBy(x => random.Next()).Take(5).ToArray();

            // Loop through each selected pair and ask the user to find the difference
            foreach (var pair in selectedPairs)
            {
                string[] selectedPair = pair.Split('|');
                string image1 = selectedPair[0];
                string image2 = selectedPair[1];

                Console.WriteLine("\n*************************************************");
                Console.WriteLine($"\tImage 1: {image1}");
                Console.WriteLine($"\tImage 2: {image2}");
                Console.WriteLine("*************************************************");

                // Find the correct difference (first mismatch)
                char correctAnswer = '\0';
                for (int i = 0; i < Math.Min(image1.Length, image2.Length); i++)
                {
                    if (image1[i] != image2[i])
                    {
                        correctAnswer = image2[i];
                        break;
                    }
                }

                // If no difference found (e.g., identical strings)
                if (correctAnswer == '\0')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\tThere is no difference between the two images!");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine("\tCan you find the different character? Please enter your answer in CAPITAL LETTERS:");

                string userInput = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(userInput) || userInput.Length > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tInvalid input! Please enter a single character.");
                    Console.ResetColor();
                    continue;
                }

                char userAnswer = char.ToUpper(userInput[0]);

                if (userAnswer == correctAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tCorrect! Well done!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tSorry, that's not correct. The difference was '{correctAnswer}'.");
                }
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tThanks for playing Find the Difference!");
            Console.ResetColor();
        }

        //playTriviaQuiz
        public static void playTriviaQuiz()
        {
            bool playAgain;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t           Welcome to Trivia Quiz!");
                Console.ResetColor();
                Console.WriteLine("\tAnswer the following questions by typing the letter of your choice (e.g., A, B, C, or D).");
                Console.WriteLine("\tType 'EXIT' to quit the quiz at any time.\n");
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");

                var allQuestions = new List<Tuple<string, string[], string>>
        {
            new Tuple<string, string[], string>("What is the capital of France?", new[] { "A. Paris", "B. Rome", "C. Berlin", "D. Madrid" }, "A"),
            new Tuple<string, string[], string>("What is 5 + 7?", new[] { "A. 11", "B. 12", "C. 13", "D. 14" }, "B"),
            new Tuple<string, string[], string>("What color is the sky on a clear day?", new[] { "A. Blue", "B. Green", "C. Yellow", "D. Red" }, "A"),
            new Tuple<string, string[], string>("What is the largest planet in our solar system?", new[] { "A. Earth", "B. Jupiter", "C. Saturn", "D. Mars" }, "B"),
            new Tuple<string, string[], string>("Who wrote 'Romeo and Juliet'?", new[] { "A. Shakespeare", "B. Dickens", "C. Austen", "D. Rowling" }, "A"),
            new Tuple<string, string[], string>("What is the boiling point of water in Celsius?", new[] { "A. 90°C", "B. 100°C", "C. 110°C", "D. 120°C" }, "B"),
            new Tuple<string, string[], string>("What is the tallest mountain on Earth?", new[] { "A. Mount Everest", "B. K2", "C. Mount Kilimanjaro", "D. Mount Fuji" }, "A"),
            new Tuple<string, string[], string>("What is the smallest unit of life?", new[] { "A. Atom", "B. Cell", "C. Molecule", "D. Organism" }, "B"),
            new Tuple<string, string[], string>("What element does 'O' represent in the periodic table?", new[] { "A. Oxygen", "B. Osmium", "C. Ozone", "D. Oxide" }, "A"),
            new Tuple<string, string[], string>("What is the fastest land animal?", new[] { "A. Cheetah", "B. Lion", "C. Elephant", "D. Tiger" }, "A"),
            new Tuple<string, string[], string>("What year did the Titanic sink?", new[] { "A. 1905", "B. 1912", "C. 1920", "D. 1930" }, "B")
        };

                Random random = new Random();
                var selectedQuestions = allQuestions.OrderBy(x => random.Next()).Take(5).ToList();

                int score = 0;

                foreach (var question in selectedQuestions)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n\tQuestion: {question.Item1}");
                    Console.ResetColor();

                    var options = question.Item2.ToList();
                    var correctAnswer = question.Item3;
                    options = options.OrderBy(x => random.Next()).ToList(); // Shuffle options

                    foreach (var option in options)
                    {
                        Console.WriteLine($"\t{option}");
                    }

                    string answer;
                    do
                    {
                        Console.Write("\n\tYour answer: ");
                        answer = Console.ReadLine()?.Trim().ToUpper();

                        if (answer == "EXIT")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\tThanks for playing Trivia Quiz!");
                            Console.ResetColor();
                            return;
                        }

                        if (string.IsNullOrEmpty(answer) || !"ABCD".Contains(answer))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tInvalid input. Please enter A, B, C, or D.");
                            Console.ResetColor();
                        }
                        else
                        {
                            break;
                        }
                    } while (true);

                    var selectedOption = options.FirstOrDefault(x => x.StartsWith(answer));
                    if (selectedOption != null && selectedOption.StartsWith(correctAnswer))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\tCorrect!");
                        score++;
                    }
                    else
                    {
                        var correctOption = options.FirstOrDefault(x => x.StartsWith(correctAnswer));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\tWrong. The correct answer is {correctOption}");
                    }
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\tYou answered {score} out of {selectedQuestions.Count} questions correctly!");
                Console.WriteLine("\tThanks for playing Trivia Quiz!");
                Console.ResetColor();

                Console.WriteLine("\n\tWould you like to play again? (yes/no): ");
                string replayChoice = Console.ReadLine()?.Trim().ToLower();
                playAgain = replayChoice == "yes";
            } while (playAgain);
        }

        //playWordle
        public static void playWordle()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t           Welcome to Wordle!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\tGuess the 5-letter word!");
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");

                string[] wordBank = { "apple", "grape", "melon", "peach", "berry", "lemon", "cherry", "plum", "kiwi", "mango" };
                string targetWord = wordBank[new Random().Next(wordBank.Length)];

                int attempts = 6;

                while (attempts > 0)
                {
                    Console.Write($"\n\tYou have {attempts} attempts left. Enter your guess: ");
                    string guess = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrWhiteSpace(guess) || guess.Length != 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tPlease enter a valid 5-letter word.");
                        Console.ResetColor();
                        continue;
                    }

                    if (guess == targetWord)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\tCongratulations! You guessed the word!");
                        Console.ResetColor();
                        break;
                    }

                    string feedback = "\tFeedback: ";
                    for (int i = 0; i < 5; i++)
                    {
                        if (guess[i] == targetWord[i])
                        {
                            feedback += guess[i]; // Correct letter and position
                        }
                        else if (targetWord.Contains(guess[i]))
                        {
                            feedback += char.ToUpper(guess[i]); // Correct letter, wrong position
                        }
                        else
                        {
                            feedback += "_"; // Incorrect letter
                        }
                    }

                    Console.WriteLine(feedback);
                    attempts--;
                }

                if (attempts == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\tOut of attempts. The correct word was '{targetWord}'.");
                    Console.ResetColor();
                }

                Console.Write("\n\tWould you like to play again? (yes/no): ");
            } while (Console.ReadLine()?.Trim().ToLower() == "yes");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\tThanks for playing Wordle!");
            Console.ResetColor();
        }

    }
}
