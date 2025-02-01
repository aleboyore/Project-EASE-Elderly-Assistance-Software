using System;
using System.Linq;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EASE
{
    class Program
    {

        public static void Main(string[] args)
        {
            ShowWelcomeMessage();
            Thread.Sleep(3000);
            Console.Clear();
            DisplayMainMenu();
        }

        static void ShowWelcomeMessage()
        {
            string appName = @"

                                              
                                              
    ,---,.   ,---,       .--.--.       ,---,. 
  ,'  .' |  '  .' \     /  /    '.   ,'  .' | 
,---.'   | /  ;    '.  |  :  /`. / ,---.'   | 
|   |   .':  :       \ ;  |  |--`  |   |   .' 
:   :  |-,:  |   /\   \|  :  ;_    :   :  |-, 
:   |  ;/||  :  ' ;.   :\  \    `. :   |  ;/| 
|   :   .'|  |  ;/  \   \`----.   \|   :   .' 
|   |  |-,'  :  | \  \ ,'__ \  \  ||   |  |-, 
'   :  ;/||  |  '  '--' /  /`--'  /'   :  ;/| 
|   |    \|  :  :      '--'.     / |   |    \ 
|   :   .'|  | ,'        `--'---'  |   :   .' 
|   | ,'  `--''                    |   | ,'   
`----'                             `----'     
                                              
		";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(appName);
            Thread.Sleep(500);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            ShowLoadingAnimation();
        }

        static void ShowLoadingAnimation()
        {
            string[] loadingSymbols = { ".", "..", "..." };
            for (int i = 0; i < 3; i++)
            {
                foreach (var symbol in loadingSymbols)
                {
                    Console.Write("\r\t\tLoading{0}   ", symbol); // Add extra spaces to overwrite previous content
                    Thread.Sleep(500);
                }
            }
            Console.WriteLine();
        }

        static void DisplayMainMenu()
        {
            try
            {
                int choice;
                do
                {
                    //main interface
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t===============================");
                    Console.WriteLine("\n\t       Welcome to E.A.S.E\n");
                    Console.WriteLine("\t===============================");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\t1 : Contacts Management");
                    Console.WriteLine("\t2 : Medication Reminder System");
                    Console.WriteLine("\t3 : Health Tracker");
                    Console.WriteLine("\t4 : Mini-Games");
                    Console.WriteLine("\t5 : Exit Program");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t===============================");
                    Console.ForegroundColor = ConsoleColor.White;
                    //user input
                    choice = Validation.GetValidInteger("\n\tPlease enter the number of your choice : ") ?? 0;

                    switch (choice)
                    {
                        case 1:
                            ContactsManagement();
                            break;
                        case 2:
                            MedicationReminderSystem();
                            break;
                        case 3:
                            HealthTracker();
                            break;
                        case 4:
                            DisplayMiniGamesMenu();
                            break;
                        case 5:
                            exitmessage();
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("\n\tInvalid input! Please try again...");
                            Console.ReadKey();
                            break;
                    }

                } while (choice != 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void exitmessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t-----------------------------------------------");
            Console.WriteLine("\t-----------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("   ██████╗  ██████╗  ██████╗ ██████╗ ██████╗ ██╗   ██╗███████╗██╗ ");
            Console.WriteLine("  ██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝██╔════╝██║ ");
            Console.WriteLine("  ██║  ███╗██║   ██║██║   ██║██║  ██║██████╔╝ ╚████╔╝ █████╗  ██║ ");
            Console.WriteLine("  ██║   ██║██║   ██║██║   ██║██║  ██║██╔══██╗  ╚██╔╝  ██╔══╝  ╚═╝ ");
            Console.WriteLine("  ╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝██████╔╝   ██║   ███████╗██╗ ");
            Console.WriteLine("   ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝ ╚═════╝    ╚═╝   ╚══════╝╚═╝ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t-----------------------------------------------");
            Console.WriteLine("\t-----------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void thanksforplaying()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t     ╔╦╗╦ ╦╔═╗╔╗╔╦╔═╔═╗ ");
            Console.WriteLine("\t\t      ║ ╠═╣╠═╣║║║╠╩╗╚═╗");
            Console.WriteLine("\t\t      ╩ ╩ ╩╩ ╩╝╚╝╩ ╩╚═╝");
            Console.WriteLine("\t\t         ╔═╗╔═╗╦═╗");
            Console.WriteLine("\t\t         ╠╣ ║ ║╠╦╝ ");
            Console.WriteLine("\t\t         ╚  ╚═╝╩╚═");
            Console.WriteLine("\t\t     ╔═╗╦  ╔═╗╦ ╦╦╔╗╔╔═╗");
            Console.WriteLine("\t\t     ╠═╝║  ╠═╣╚╦╝║║║║║ ╦ ");
            Console.WriteLine("\t\t     ╩  ╩═╝╩ ╩ ╩ ╩╝╚╝╚═╝\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\t------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\tReturning to Mini-Games Menu");
            Console.Write("       ");
            for (int i = 0; i < 43; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            DisplayMiniGamesMenu(); // Return to the mini-games menu
        }
        public static void errormessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t  Something went wrong, Please try again");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }



        // ContactsManagement method in the Main
        public static void ContactsManagement()
        {
            ContactManager manager = new ContactManager();

            int choice;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t===============================");
                Console.WriteLine("\n\t    Contacts Management\n");
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\t1 : Add a Contact");
                Console.WriteLine("\t2 : View All Contacts");
                Console.WriteLine("\t3 : Search Contact");
                Console.WriteLine("\t4 : Update Contact");
                Console.WriteLine("\t5 : Delete Contact");
                Console.WriteLine("\t6 : Back to Main Menu");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                choice = Validation.GetValidInteger("\n\tPlease enter the number of your choice : ") ?? 0;

                switch (choice)
                {
                    case 1:
                        string name = Validation.GetValidString("\n\tEnter contact name: ");
                        string phoneNumber = Validation.GetValidPhoneNumber("\tEnter contact phone number (e.g., 09XXXXXXXXX): ");
                        string phoneCategory = Validation.GetValidCategory("\tEnter contact category (leave blank for Default): ", manager.GetPhoneCategories());

                        manager.AddContact(name, phoneNumber, phoneCategory);
                        break;

                    case 2:
                        Console.WriteLine("\n\tDo you want to filter contacts by category?");
                        Console.WriteLine("\t1 : Yes");
                        Console.WriteLine("\t2 : No (View All Contacts)");
                        int viewChoice = Validation.GetValidInteger("\tPlease enter the number of your choice : ") ?? 0;

                        if (viewChoice == 1)
                        {
                            string categoryToView = Validation.GetValidCategory("\n\tEnter the category to view: ", manager.GetPhoneCategories());
                            manager.ViewContacts(categoryToView);
                        }
                        else if (viewChoice == 2)
                        {
                            manager.ViewContacts();
                        }
                        else
                        {
                            Console.WriteLine("\n\tInvalid choice! Displaying all contacts by default.");
                            manager.ViewContacts();
                        }

                        Console.Write("\n\tPress any key to return");
                        Console.ReadKey();
                        break;

                    case 3:
                        string searchContact = Validation.GetValidString("\n\tEnter the name to search: ");

                        manager.SearchContact(searchContact);
                        Console.ReadKey();
                        break;

                    case 4:
                        string nameUpdate = Validation.GetValidString("\n\tEnter the name to update: ");

                        manager.UpdateContact(nameUpdate);
                        Console.ReadKey();
                        break;

                    case 5:
                        string nameDelete = Validation.GetValidString("\n\tEnter the name to delete: ");

                        manager.DeleteContact(nameDelete);
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\tReturning to Main Menu...");
                        return;

                    default:
                        Console.WriteLine("\n\tInvalid input! Please try again...");
                        Console.ReadKey();
                        break;
                }

            } while (true);
        }

        // MedicationReminderSystem method in the Main
        public static void MedicationReminderSystem()
        {
            MedicationManager medManager = new MedicationManager();
            int choice;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t===============================");
                Console.WriteLine("\n\tMedication Reminder System\n");
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\t1 : Add a Medication");
                Console.WriteLine("\t2 : View All Medications");
                Console.WriteLine("\t3 : Update Medication");
                Console.WriteLine("\t4 : Delete Medication");
                Console.WriteLine("\t5 : Display Daily Reminders");
                Console.WriteLine("\t6 : Back to Main Menu");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                choice = Validation.GetValidInteger("\n\tPlease enter the number of your choice : ") ?? 0;

                switch (choice)
                {
                    case 1:
                        string name = Validation.GetValidString("\n\tEnter medication name: ");
                        string dosage = Validation.GetNonEmptyString("\tEnter dosage (e.g., 500 mg, 10 mL, 2 tablets): ");
                        string time = Validation.GetValidTime("\tEnter time (HH:mm): ");
                        string notes = Validation.GetNonEmptyString("\tNotes: ");
                        medManager.AddMedication(name, dosage, time, notes);
                        break;

                    case 2:
                        medManager.ViewMedications();
                        Console.Write("\n\tPress any key to return");
                        Console.ReadKey();
                        break;

                    case 3:
                        string medToUpdate = Validation.GetValidString("\n\tEnter the medication name to update: ");
                        medManager.UpdateMedication(medToUpdate);
                        Console.ReadKey();
                        break;

                    case 4:
                        string medToDelete = Validation.GetValidString("\n\tEnter the medication name to delete: ");
                        medManager.DeleteMedication(medToDelete);
                        Console.ReadKey();
                        break;

                    case 5:
                        medManager.DisplayDailyReminders();
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\tReturning to Main Menu...");
                        return;

                    default:
                        Console.WriteLine("\n\tInvalid input! Please try again...");
                        Console.ReadKey();
                        break;
                }

            } while (true);
        }

        // HealthTracker method in the Main
        public static void HealthTracker()
        {
            HealthTracker healthManager = new HealthTracker();
            int choice;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t===============================");
                Console.WriteLine("\n\t        Health Tracker\n");
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\t1 : Add Health Data");
                Console.WriteLine("\t2 : View All Health Data");
                Console.WriteLine("\t3 : Calculate BMI");
                Console.WriteLine("\t4 : View Summary");
                Console.WriteLine("\t5 : Back to Main Menu");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t===============================");
                Console.ForegroundColor = ConsoleColor.White;

                choice = Validation.GetValidInteger("\n\tPlease enter the number of your choice : ") ?? 0;

                switch (choice)
                {
                    case 1:
                        string date = Validation.GetValidDate("\n\tEnter date (DD-MM-YYYY): ");
                        string time = Validation.GetValidTime("\tEnter time (HH:mm): ");
                        int? age = Validation.GetValidInteger("\tEnter age (or leave blank): ", true);  // Optional
                        double? height = Validation.GetValidDouble("\tEnter height (cm): ", false);  // Required
                        double? weight = Validation.GetValidDouble("\tEnter weight (kg): ", false);  // Required
                        string bloodPressure = Validation.GetNonEmptyString("\tEnter blood pressure (systolic/diastolic, e.g., 120/80) or leave blank: ", true);  // Optional
                        double? bloodSugar = Validation.GetValidDouble("\tEnter blood sugar level (mg/dL) or leave blank: ", true);  // Optional
                        int? heartRate = Validation.GetValidInteger("\tEnter heart rate (bpm) or leave blank: ", true);  // Optional
                        double? temperature = Validation.GetValidDouble("\tEnter temperature (°C) or leave blank: ", true);  // Optional

                        healthManager.AddRecord(date, time, age, bloodPressure, bloodSugar, height ?? 0.0, weight ?? 0.0, heartRate, temperature);
                        break;

                    case 2:
                        healthManager.ViewRecords();
                        Console.Write("\n\tPress any key to return");
                        Console.ReadKey();
                        break;

                    case 3:
                        healthManager.ViewBMIRecords();
                        Console.Write("\n\tPress any key to return");
                        Console.ReadKey();
                        break;

                    case 4:
                        healthManager.ViewSummary();
                        Console.Write("\n\tPress any key to return");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("\tReturning to Main Menu...");
                        return;

                    default:
                        Console.WriteLine("\n\tInvalid input! Please try again...");
                        Console.ReadKey();
                        break;
                }

            } while (true);
        }

        // MiniGames method in the Main
        public static void DisplayMiniGamesMenu()
        {
            bool playAgain;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\t       ███╗   ███╗██╗███╗   ██╗██╗");
                Console.WriteLine("\t       ████╗ ████║██║████╗  ██║██║");
                Console.WriteLine("\t       ██╔████╔██║██║██╔██╗ ██║██║");
                Console.WriteLine("\t       ██║╚██╔╝██║██║██║╚██╗██║██║");
                Console.WriteLine("\t       ██║ ╚═╝ ██║██║██║ ╚████║██║");
                Console.WriteLine("\t       ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═╝");
                Console.WriteLine("        ██████╗  █████╗ ███╗   ███╗███████╗███████╗ ");
                Console.WriteLine("       ██╔════╝ ██╔══██╗████╗ ████║██╔════╝██╔════╝ ");
                Console.WriteLine("       ██║  ███╗███████║██╔████╔██║█████╗  ███████╗ ");
                Console.WriteLine("       ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ╚════██║ ");
                Console.WriteLine("       ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗███████║ ");
                Console.WriteLine("        ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚══════╝ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t1 : Number Sequence Recall");
                Console.WriteLine("\t\t2 : Guess the Number");
                Console.WriteLine("\t\t3 : Repeat the Pattern");
                Console.WriteLine("\t\t4 : Mathify");
                Console.WriteLine("\t\t5 : Picture Matching");
                Console.WriteLine("\t\t6 : Word Association");
                Console.WriteLine("\t\t7 : Find the Difference");
                Console.WriteLine("\t\t8 : Trivia Quiz");
                Console.WriteLine("\t\t9 : Wordle");
                Console.WriteLine("\t\t10 : Exit\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t------------------------------------------");
                Console.WriteLine("\t------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\tEnter the number of your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                bool continuePlayingCurrentGame = true;

                while (continuePlayingCurrentGame)
                {
                    switch (choice)
                    {
                        case 1: MiniGames.playNumSequenceRecall(); break;
                        case 2: MiniGames.playGuessNum(); break;
                        case 3: MiniGames.playRepeatPattern(); break;
                        case 4: MiniGames.playMathify(); break;
                        case 5: MiniGames.playPictureMatching(); break;
                        case 6: MiniGames.playWordAssociation(); break;
                        case 7: MiniGames.playFindTheDifference(); break;
                        case 8: MiniGames.playTriviaQuiz(); break;
                        case 9: MiniGames.playWordle(); break;
                        case 10: exitmessage(); return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t      Input must be between 1 and 10");
                            Thread.Sleep(2000);
                            continuePlayingCurrentGame = false;
                            break;
                    }

                    // Prompt for switching games
                    Console.Write("\n\tDo you want to switch games? (y/n): ");
                    string switchResponse = Console.ReadLine()?.ToLower();

                    if (switchResponse == "y" || switchResponse == "yes")
                    {
                        continuePlayingCurrentGame = false; // Exit current game and switch
                    }
                    else if (switchResponse == "n" || switchResponse == "no")
                    {
                        // Stay in the current game
                        Console.WriteLine("\n\tResuming the current game...");
                    }
                    else
                    {
                        // Handle invalid input and continue prompting
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tInvalid input! Please enter 'y' or 'n'.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                playAgain = true; // Restart the main menu
            } while (playAgain);
        }
    }
}