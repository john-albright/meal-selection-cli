using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Selection
{
    class Lunch: Meal
    {
        public Lunch(Dictionary<int, int> items)
        {
            // Initialize string to become error message if the order is incorrect
            List<string> errors = new List<string>();
            bool validOrder = true;

            foreach (KeyValuePair<int, int> item in items)
            {
                if (item.Key == 1)
                {
                    for (int i = 0; i < item.Value; i++)
                        AddMain("Sandwich");
                }
                if (item.Key == 2)
                {
                    for (int i = 0; i < item.Value; i++)
                        AddSide("Chips");
                }
                if (item.Key == 3)
                {
                    for (int i = 0; i < item.Value; i++)
                        AddDrink("Soda");
                }
            }

            // Get totals of each course
            int totalMain = this.Main.ToArray().Length;
            int totalSide = this.Side.ToArray().Length;
            int totalDrink = this.Drink.ToArray().Length;

            // Add water if no soda is ordered
            // Modify totalDrink if updated
            if (totalDrink == 0)
            {
                AddDrink("Water");
                totalDrink = this.Drink.ToArray().Length;
            }

            // Lunch can only have 1 main dish
            if (totalMain == 0)
            {
                errors.Add("main is missing");
                validOrder = false;
            }
            if (totalMain > 1)
            {
                errors.Add("sandwich cannot be ordered more than once");
                validOrder = false;
            }
            if (totalSide == 0)
            {
                errors.Add("side is missing");
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

        // Desserts cannot be ordered for lunch
        new public void AddDessert(string val)
        {
            return;
        }
    }
}
