using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Menu_Selection
{
    class Meal: IMeal
    {
        public List<string> Main { get; } = new List<string>();
        public List<string> Side { get; } = new List<string>();
        public List<string> Drink { get; } = new List<string>();
        public List<string> Dessert { get; } = new List<string>();

        public string PrintOrderString()
        {
            // Start by adding the main dish
            // There can only be one main dish per meal
            // The side, drink, and dessert must be added subsequently
            string printable = this.Main.ToArray()[0] + ", ";

            // Initialize the dictionary to be filled with course names and their counts
            Dictionary<string, int> courseDict = new Dictionary<string, int>();
            
            // Combine the remaining courses into an array of lists (of strings)
            List<string>[] courses = { this.Side, this.Drink, this.Dessert };

            // Finish accumulating strings on the final printable string
            foreach (List<string> course in courses)
            {
                // Accumulate the amount of courses in each meal 
                foreach (string side in course)
                {
                    if (courseDict.ContainsKey(side))
                        courseDict[side] += 1;
                    else
                        courseDict.Add(side, 1);
                }

                // Add the courses to the final string accounting for the count
                foreach (KeyValuePair<string, int> kvp in courseDict)
                {
                    if (kvp.Value == 1)
                        printable += $"{kvp.Key}, ";
                    if (kvp.Value > 1)
                        printable += $"{kvp.Key}({kvp.Value}), ";
                }

                // Clear the dictionary after each iteration
                courseDict.Clear();
            }

            // Get rid of the final space and comma
            printable = printable[0..(printable.Length - 2)];

            // Print the final string to console
            return printable;
        }
        public void AddMain(string val)
        {
            Main.Add(val);
        }
        public void AddSide(string val)
        {
            Side.Add(val);
        }
        public void AddDrink(string val)
        {
            Drink.Add(val);
        }
        public void AddDessert(string val)
        {
            Dessert.Add(val);
        }
    }
}
