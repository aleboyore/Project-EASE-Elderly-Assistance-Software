using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EASE
{
    public static class Validation
    {
        // nagva-validate ng user input na int
        public static int? GetValidInteger(string prompt, bool allowBlank = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (allowBlank && string.IsNullOrWhiteSpace(input))  // Allow blank input
                {
                    return null;  // Return null if blank
                }

                int validInput;
                if (int.TryParse(input, out validInput))
                {
                    return validInput;  // Return the parsed integer value
                }
                else
                {
                    Console.WriteLine("\tInvalid input! Please enter a valid number.");
                }
            }
        }

        // nagva-validate ng user input na string/name
        public static string GetValidString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\tInvalid input! Please enter a valid name.");
                }
            }
        }

        // nagva-validate ng phone numbers
        public static string GetValidPhoneNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, @"^(09|63|639)\d{9}$"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\tInvalid phone number. Please enter a valid phone number (e.g., 09123456789 or 639123456789).");
                }
            }
        }

        // nagva-validate ng date format in 24-hour format
        public static string GetValidTime(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Updated regex to accept single or double-digit hours and minutes
                if (Regex.IsMatch(input, @"^([0-9]|1[0-9]|2[0-3]):([0-9]|[0-5][0-9])$"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\tInvalid time format. Please enter a valid time in H:mm or HH:mm format.");
                }
            }
        }

        // nagva-validate ng null at null at white spaces
        public static string GetNonEmptyString(string prompt, bool allowBlank = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (allowBlank && string.IsNullOrWhiteSpace(input))  // Allow blank input
                {
                    return string.Empty;  // Return empty string if blank
                }

                if (!string.IsNullOrWhiteSpace(input))  // Ensures non-empty string
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\tInvalid input. Please enter a non-empty value.");
                }
            }
        }

        // nagva-validate ng mga double inputs
        public static double? GetValidDouble(string prompt, bool allowBlank = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (allowBlank && string.IsNullOrWhiteSpace(input))  // Allow blank input
                {
                    return null;  // Return null if blank
                }

                double validNumber;
                if (double.TryParse(input, out validNumber))
                {
                    return validNumber;  // Return the parsed double value
                }
                else
                {
                    Console.WriteLine("\tInvalid input. Please enter a valid number.");
                }
            }
        }

        // nagva-validate ng date
        public static string GetValidDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, @"^([1-9]|0[1-9]|[12][0-9]|3[01])-([1-9]|0[1-9]|1[0-2])-(\d{4})$"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\tInvalid date format. Please enter the date in DD-MM-YYYY or D-M-YYYY format.");
                }
            }
        }

        // nagva-validate ng category
        public static string GetValidCategory(string prompt, List<string> phoneCategories)
        {
            while (true)
            {
                Console.Write(prompt);
                string inputCategory = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(inputCategory))
                {
                    return "Default";
                }

                if (!phoneCategories.Any(contactList => contactList.Equals(inputCategory, StringComparison.OrdinalIgnoreCase)))
                {
                    phoneCategories.Add(inputCategory);
                    Console.WriteLine("\tCategory '{0}' has been added.", inputCategory);
                }
                return inputCategory;
            }
        }
    }
}
