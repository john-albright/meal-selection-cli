using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Selection
{
    class Dinner : Meal
    {
        public Dinner(Dictionary<int, int> items)
        {
            // Initialize string to become error message if the order is incorrect
            List<string> errors = new List<string>();
            bool validOrder = true;

            foreach (KeyValuePair<int, int> item in items)
            {
                if (item.Key == 1)
                {
                    for (int i = 0; i < item.Value; i++)
                        AddMain("Steak");
                }
                if (item.Key == 2)
                {
                    for (int i = 0; i < item.Value; i++)
                        AddSide("Potatoes");
                }
                if (item.Key == 3)
                {
                    for (int i = 0; i < item.Value; i++)
                        AddDrink("Wine");
                }
                if (item.Key == 4)
                {
                    for (int i = 0; i < item.Value; i++)
                        AddDessert("Cake");
                }
            }

            // Water is always included with dinner
            AddDrink("Water"); 

            // Get totals of each course
            int totalMain = this.Main.ToArray().Length;
            int totalSide = this.Side.ToArray().Length;
            int totalDrink = this.Drink.ToArray().Length;
            int totalDessert = this.Dessert.ToArray().Length;

            // Dinner can only have 1 side dish, 1 main dish, and 1 dessert
            if (totalMain == 0)
            {
                errors.Add("main is missing");
                validOrder = false;
            }
            if (totalMain > 1)
            {
                errors.Add("steak cannot be ordered more than once");
                validOrder = false;
            }
            if (totalSide == 0)
            {
                errors.Add("side is missing");
                validOrder = false;
            }
            if (totalSide > 1)
            {
                errors.Add("potatoes cannot be ordered more than once");
                validOrder = false;
            }
            if (totalDessert == 0)
            {
                errors.Add("dessert is missing");
                validOrder = false;
            }
            if (totalDessert > 1)
            {
                errors.Add("dessert cannot be ordered more than once");
                validOrder = false;
            }

            // Throw an error if the order is invalid
            if (!validOrder)
            {
                string errorStatement = "Unable to process: ";
                foreach (string error in errors)
                {
                    errorStatement += error + ", ";
                }

                // Capitalize the letter of the first error and cut the comma and space at the end of the list
                errorStatement = errorStatement[0..19] + errorStatement[19].ToString().ToUpper() + errorStatement[20..(errorStatement.Length - 2)];

                throw new InvalidOrderException(errorStatement);
            }
        }
    }
}
