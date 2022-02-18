using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Console;

namespace Menu_Selection
{
    public class Program
    {
        // Method to process a valid string and attempt to declare a Breakfast, Lunch, or Dinner object
        public static string ParseUserText(string input)
        {
            // Declare variables to be used to parse the user's text
            string mealName;
            int orderedItem;
            IMeal meal;
            Dictionary<int, int> itemsDict = new Dictionary<int, int>();
            Regex mealNameRg = new Regex(@"^(Breakfast|Lunch|Dinner)");
            Regex mealItemsRg = new Regex(@"[1-4]");

            // Parse the user's input & store the numbers into the itemsDict dictionary
            mealName = mealNameRg.Match(input).Value;
            foreach (Match match in mealItemsRg.Matches(input))
            {
                orderedItem = int.Parse(match.Value);
                if (itemsDict.ContainsKey(orderedItem))
                    itemsDict[orderedItem] += 1;
                else
                    itemsDict.Add(orderedItem, 1);
            }

            // Debug print statements to check the meal name
            // WriteLine($"meal name: {mealName}");
            // foreach (KeyValuePair<int, int> kvp in itemsDict)
            //     WriteLine($"item: {kvp.Key} --> count: {kvp.Value}");

            // Attempt to instantiate the meal object according to the meal name
            try
            {
                if (mealName.Equals("Breakfast"))
                {
                    meal = new Breakfast(itemsDict);
                }
                else if (mealName.Equals("Lunch"))
                {
                    meal = new Lunch(itemsDict);
                }
                else if (mealName.Equals("Dinner"))
                {
                    meal = new Dinner(itemsDict);
                }
                else
                {
                    return "Invalid meal: only Breakfast, Lunch, and Dinner are accepted.";
                }

                return meal.PrintOrderString();
            }
            // Catch the error thrown if instantiation of Breakfast, Lunch, or Dinner is unsuccessful
            catch (InvalidOrderException e)
            {
                return e.Message;
            }
        }

        // Method to validate user input
        public static bool ValidateInput(string input)
        {
            Regex mealRg = new Regex(@"^(Breakfast|Lunch)\s*([123]{1}($|,[123]{1})+)?$|^(Dinner)\s*([1234]{1}($|,[1234]{1})+)?$");
            return mealRg.IsMatch(input);
        }

        // Main method of the program
        public static void Main(string[] args)
        {
            // Declare the variables to be used in Main driver portion of the program
            string userInput, programOutput;
           
            // Prompt user for input
            Write("\n  Enter your order, starting with the name of the meal\n  (Breakfast, Lunch, or Dinner) followed by the dish(es)\n  to be ordered (separated by commas): \n\n");
            userInput = ReadLine();
            //correctInput = ValidateInput(userInput);

            // Repeat the prompt until valid input is entered
            while (!ValidateInput(userInput))
            {
                Write("\n  The user input was not in the correct format. Please try again: \n\n");
                userInput = ReadLine();
            }

            // Parse the user's input using the ParseUserText() method
            programOutput = ParseUserText(userInput);

            // Print the final output to the console
            WriteLine(programOutput);

            // Pause the program until the user presses enter
            ReadLine();

        }
    }
}
