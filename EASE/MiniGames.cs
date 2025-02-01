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
                            instruction.playNumSequenceRecall();
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
                            instruction.playGuessNum();
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
                            instruction.playRepeatPattern();
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
                            instruction.playMathify();
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
            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t=======================================");
                    Console.WriteLine("\n\t           Picture Matching\n");
                    Console.WriteLine("\t=======================================");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\tWelcome to Picture Matching!");

                    string[] allCards = { "Apple", "Banana", "Cherry", "Orange", "Grape", "Lemon", "Peach", "Plum", "Pear", "Berry" };

                    Random random = new Random();
                    string[] selectedCards = allCards.OrderBy(x => random.Next()).Take(4).ToArray();

                    string[] cards = selectedCards.Concat(selectedCards).OrderBy(x => random.Next()).ToArray();
                    bool[] matched = new bool[cards.Length];
                    int attempts = 0;

                    while (matched.Any(m => !m))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t=======================================");
                        Console.WriteLine("\n\t           Picture Matching\n");
                        Console.WriteLine("\t=======================================");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\n\tHere are the cards:");

                        for (int i = 0; i < cards.Length; i++)
                        {
                            if (matched[i])
                                Console.Write($"\t[{i + 1}: Matched] ");
                            else
                                Console.Write($"\t[{i + 1}: ?] ");
                        }
                        Console.WriteLine("\n\n\tType 'exit' to stop and return to the main menu.");

                        int firstIndex = GetCardIndex(cards.Length, matched, "first");
                        if (firstIndex == -1) break;

                        int secondIndex = GetCardIndex(cards.Length, matched, "second", firstIndex);
                        if (secondIndex == -1) break;

                        Console.WriteLine($"\n\tCard {firstIndex + 1}: {cards[firstIndex]}");
                        Console.WriteLine($"\tCard {secondIndex + 1}: {cards[secondIndex]}");

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
                        Thread.Sleep(2000);
                    }

                    if (matched.All(m => m))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\tCongratulations! You matched all the cards in {attempts} attempts.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\tYou chose to exit. Returning to the main menu.");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tAn error occurred: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\n\tWould you like to play again? (yes/no): ");
            } while (Console.ReadLine()?.Trim().ToLower() == "yes");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tReturning to the main menu. Goodbye!");
            Console.ResetColor();
        }
        private static int GetCardIndex(int length, bool[] matched, string prompt, int excludeIndex = -1)
        {
            while (true)
            {
                Console.Write($"\tEnter the number for the {prompt} card: ");
                string input = Console.ReadLine()?.Trim();
                if (input?.ToLower() == "exit") return -1;

                if (int.TryParse(input, out int index) && index >= 1 && index <= length && !matched[index - 1] && index - 1 != excludeIndex)
                    return index - 1;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tInvalid input! Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //playWordAssociation
        public static void playWordAssociation()
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t=======================================");
                    Console.WriteLine("\n\t    Welcome to Word Association!\n");
                    Console.WriteLine("\t=======================================");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\tEnter a word related to the given word.");
                    Console.WriteLine("\tType 'EXIT' to stop and return to the main menu.");

                    string[] words = { "Sun", "Moon", "Star", "Ocean", "Forest", "Mountain", "River", "Tree", "Flower", "Grass", "Bird", "Fish", "Sky", "Cloud", "Beach", "Island", "Desert", "Rain", "Snow", "Wind" };
                    Random random = new Random();
                    HashSet<string> usedWords = new HashSet<string>();
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
                            Console.WriteLine("\n\tYou chose to exit. Returning to the main menu.");
                            Console.ForegroundColor = ConsoleColor.White;
                            return;
                        }

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
                }

                Console.WriteLine("\n\tWould you like to play again? (yes/no): ");
            } while (Console.ReadLine()?.Trim().ToLower() == "yes");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tReturning to the main menu. Goodbye!");
            Console.ResetColor();
        }

        //playFindTheDifference
        public static void playFindTheDifference()
        {
            do
            {
                try
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

                    // Hardcoded pairs with unique differing letters
                    string[] pairs = {
                "ABCDEF|ABCDGF", "123456|123759", "HELLOO|HELYOO", "WINDOW|WINDXZ",
                "PYTHON|PYTQON", "GUITAR|GUIZAR", "KITTEN|KITLEN", "PLANET|PLADNT",
                "FRAMES|FRAMES", "CANDLE|CANFLX", "MARKER|MARRER", "BUTTON|BUTTQN",
                "POCKET|POCJET", "DANGER|DANGXR", "CIRCLE|CIRPLE", "TABLES|TABCES",
                "PLANET|PLALET", "ISLAND|ISLXND", "LADDER|LADUER", "BRIDGE|BRIBGE",
                "GAMBLE|GAMXLE", "SUMMER|SUMXER", "FARMER|FARNER", "BORDER|BORDUR",
                "CARTER|CARTNR", "CLOUDS|CLNUDS", "BANNER|BANXER", "MIRROR|MIRRPR",
                "WHEELS|WHEEQS", "TUNNEL|TUNREL", "DINNER|DINVER", "FLOWER|FLQWER"
            };

                    Random random = new Random();
                    var selectedPairs = pairs.OrderBy(x => random.Next()).Take(5).ToArray();

                    foreach (var pair in selectedPairs)
                    {
                        string[] selectedPair = pair.Split('|');
                        string image1 = selectedPair[0];
                        string image2 = selectedPair[1];

                        Console.WriteLine("\n*************************************************");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\tImage 1: {image1}");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\tImage 2: {image2}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("\tType 'EXIT' to stop and return to the main menu.");

                        char correctAnswer = '\0';
                        for (int i = 0; i < Math.Min(image1.Length, image2.Length); i++)
                        {
                            if (image1[i] != image2[i])
                            {
                                correctAnswer = image2[i];
                                break;
                            }
                        }

                        if (correctAnswer == '\0')
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\tThere is no difference between the two images!");
                            Console.ResetColor();
                            continue;
                        }

                        Console.WriteLine("\tCan you find the different character? Please enter your answer in CAPITAL LETTERS:");
                        string userInput = Console.ReadLine()?.Trim();

                        if (userInput?.ToLower() == "exit")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\tYou chose to exit. Returning to the main menu.");
                            Console.ResetColor();
                            return;
                        }

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
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tAn unexpected error occurred: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\n\tWould you like to play again? (yes/no): ");
            } while (Console.ReadLine()?.Trim().ToLower() == "yes");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tReturning to the main menu. Goodbye!");
            Console.ResetColor();
        }

        //playTriviaQuiz
        public static void playTriviaQuiz()
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t==========================================");
                    Console.WriteLine("\n\t            WELCOME TO TRIVIA QUIZ        ");
                    Console.WriteLine("\t==========================================");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n\tInstructions:");
                    Console.WriteLine("\t- Answer by typing the letter of your choice (A, B, C, or D).");
                    Console.WriteLine("\t- Type 'EXIT' at any time to quit the quiz.\n");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\tLet's get started!");
                    Console.ResetColor();

                    var allQuestions = new List<Tuple<string, string[], string>>
            {
                new Tuple<string, string[], string>("What is the capital of France?", new[] { "Paris", "Rome", "Berlin", "Madrid" }, "Paris"),
                new Tuple<string, string[], string>("What is 5 + 7?", new[] { "11", "12", "13", "14" }, "12"),
                new Tuple<string, string[], string>("What color is the sky on a clear day?", new[] { "Blue", "Green", "Yellow", "Red" }, "Blue"),
                // Add more questions here...
            };

                    Random random = new Random();
                    var selectedQuestions = allQuestions.OrderBy(x => random.Next()).Take(5).ToList();
                    int score = 0;

                    foreach (var question in selectedQuestions)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\n\tQuestion: {question.Item1}");
                        Console.ResetColor();

                        var options = question.Item2.OrderBy(x => random.Next()).ToList();
                        char correctLetter = (char)('A' + options.IndexOf(question.Item3));

                        for (int i = 0; i < options.Count; i++)
                        {
                            Console.WriteLine($"\t{(char)('A' + i)}. {options[i]}");
                        }

                        string answer;
                        do
                        {
                            Console.Write("\n\tYour answer: ");
                            answer = Console.ReadLine()?.Trim().ToUpper();

                            if (answer == "EXIT")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n\tYou chose to exit. Returning to the main menu.");
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

                        if (answer[0] == correctLetter)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\tCorrect!");
                            score++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\tWrong. The correct answer was {correctLetter}. {question.Item3}");
                        }
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n\tYou answered {score} out of {selectedQuestions.Count} questions correctly!");
                    Console.WriteLine("\tThanks for playing Trivia Quiz!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tAn unexpected error occurred: " + ex.Message);
                    Console.ResetColor();
                }

                Console.WriteLine("\n\tWould you like to play again? (yes/no): ");
            } while (Console.ReadLine()?.Trim().ToLower() == "yes");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tReturning to the main menu. Goodbye!");
            Console.ResetColor();
        }

        //playWordle
        //playWordle
        public static void playWordle()
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t           Welcome to Wordle!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\tGreen: Correct Letter and Position");
                    Console.WriteLine("\n\tYellow: Correct Letter but Wrong Position");
                    Console.WriteLine("\n\tGray/Underscore (_): Wrong Letter and Wrong Position");
                    Console.WriteLine("\n\tGuess the 5-letter word!");
                    Console.WriteLine("\tType 'EXIT' to stop and return to the main menu.");
                    Console.WriteLine("\t------------------------------------------");
                    Console.WriteLine("\t------------------------------------------\n");

                    string[] wordBank = {
                "apple", "grape", "melon", "peach", "berry", "lemon", "cherry",
                "plumb", "kiwi", "mango", "brick", "flint", "stone", "cloud",
                "table", "chair", "trace", "spike", "storm", "field", "torch",
                "trail", "glass", "straw", "slice", "watch", "climb", "shelf"
            };

                    string targetWord = wordBank[new Random().Next(wordBank.Length)];
                    int attempts = 6;

                    while (attempts > 0)
                    {
                        Console.Write($"\n\tYou have {attempts} attempts left. Enter your guess: ");
                        string guess = Console.ReadLine()?.ToLower();

                        if (guess == "exit")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\tYou chose to exit. Returning to the main menu.");
                            Console.ResetColor();
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(guess) || guess.Length != 5 || !IsAllLetters(guess))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tInvalid input! Please enter a valid 5-letter word.");
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

                        Console.Write("\tFeedback: ");
                        for (int i = 0; i < 5; i++)
                        {
                            if (guess[i] == targetWord[i])
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(guess[i]);  // Correct letter and position
                            }
                            else if (targetWord.Contains(guess[i]))
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(guess[i]);  // Correct letter, wrong position
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("_");  // Incorrect letter
                            }
                        }
                        Console.ResetColor();
                        Console.WriteLine();

                        attempts--;
                    }

                    if (attempts == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n\tOut of attempts. The correct word was '{targetWord}'.");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tAn unexpected error occurred: " + ex.Message);
                    Console.ResetColor();
                }

                Console.Write("\n\tWould you like to play again? (yes/no): ");
            } while (Console.ReadLine()?.Trim().ToLower() == "yes");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tReturning to the main menu. Goodbye!");
            Console.ResetColor();
        }


        private static bool IsAllLetters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
