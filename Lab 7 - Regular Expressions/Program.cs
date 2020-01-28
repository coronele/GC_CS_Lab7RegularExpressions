using System;
using System.Text.RegularExpressions;

namespace Lab_7___Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowTitle("Regular Expressions Lab");
            GetSomeInfo();
        }

        public static void GetSomeInfo()
        {
            string name = GetName(GetUserInput("Please type in a name"));

            string emailAddress = GetEmailAddress(GetUserInput("Please type in an email address"));

            string phoneNum = GetPhoneNum(GetUserInput("Please enter your phone number ex. 888-888-8888"));
            
            string birthDate = GetDate(GetUserInput("Please enter your birth date ex. dd/mm/yyyy"));
            
            string stringHTML = GetHTML(GetUserInput("Please enter a string containing HTML tags"));
        }

        public static string GetName(string inputName)
        {
            if (IsNameCorrect(inputName))
            {
                return inputName;
            }
            else
            {
                SetOutputColor();
                Console.WriteLine("Your name must start with a capital letter and may be up to 30 characters long\n\n");
                inputName = GetName(GetUserInput("Please type in a name"));
                return inputName;
            }
        }

        public static string GetEmailAddress(string inputName)
        {
            if (IsEmailCorrect(inputName))
            {
                return inputName;
            }
            else
            {
                SetOutputColor();
                Console.WriteLine("This is not a valid email address.\n");
                inputName = GetEmailAddress(GetUserInput("Please type in your email address: "));
                return inputName;
            }
        }

        public static string GetPhoneNum(string inputName)
        {
            if (IsPhoneNumCorrect(inputName))
            {
                return inputName;
            }
            else
            {
                SetOutputColor();
                Console.WriteLine("This is not a valid phone number. ex: 888-888-1234\n");
                inputName = GetPhoneNum(GetUserInput("Please type in your phone number: "));
                return inputName;
            }
        }

        public static string GetDate(string inputName)
        {
            if (IsDateCorrect(inputName))
            {
                return inputName;
            }
            else
            {
                SetOutputColor();
                Console.WriteLine("This is not a valid date. ex: dd/mm/yyyy\n");
                inputName = GetDate(GetUserInput("Please type in your birth date: "));
                return inputName;
            }
        }

        public static string GetHTML(string inputName)
        {
            if (IsHTMLElement(inputName))
            {
                return inputName;
            }
            else
            {
                SetOutputColor();
                Console.WriteLine("This does not contain proper HTML tags \n\n");
                inputName = GetHTML(GetUserInput("Please enter a string with HTML tags"));
                return inputName;
            }
        }


        public static bool IsNameCorrect(string checkString)
        {
            // Check if first letter is caps
            if (Regex.IsMatch(checkString, @"\b([A-Z])([a-z]){0,29}\b"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsEmailCorrect(string checkString)
        {
            // Criteria:
            // 1) username is alphanumeric and between 5 and 30 characters followed by @
            // 2) mail server is alphanumeric and between 5 and 10 characters followed by "."
            // 3) domain is alphanumeric and either 2 or 3 characters
            if (Regex.IsMatch(checkString, @"\b([A-z0-9]){5,30}@([A-z0-9]){5,10}.([A-z0-9]){2,3}\b"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPhoneNumCorrect(string checkString)
        {
            // Check if digits formatted as such 888-888-8888
            if (Regex.IsMatch(checkString, @"\b\d{3}-\d{3}-\d{4}\b"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDateCorrect(string checkString)
        {
            // Check if formatted correctly and valid
            string dayPart, monthPart, yearPart;
            
            if (Regex.IsMatch(checkString, @"\b\d{2}\/\d{2}\/\d{4}\b"))
            {
                string [] dateParts = checkString.Split('/');
                dayPart = dateParts[0];
                monthPart = dateParts[1];
                yearPart = dateParts[2];

                try
                {
                    DateTime buildDate = DateTime.Parse($"{monthPart}/{dayPart}/{yearPart}");
                }
                catch
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsHTMLElement(string checkString)
        {
            // Check if text is in this format <HTMLTAG> any text </HTMLTAG>
            if (Regex.IsMatch(checkString, @"<(.{1,})>.{1,}<\/\1>"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetUserInput(string message)
        {
            // Allows for program prompt and user input (string)
            SetOutputColor();
            Console.WriteLine(message);
            SetInputColor();
            string input = Console.ReadLine();
            return input;
        }

        public static void ShowTitle(string title)
        {
            // This method simply shows the title
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{title} \n\n");
        }

        public static void SetInputColor()
        {
            // Method for setting colors for user inputted text
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void SetOutputColor()
        {
            // Method for setting colors for default display text
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
