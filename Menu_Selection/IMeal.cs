using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Menu_Selection
{
    interface IMeal
    {
        List<string> Main { get; }
        List<string> Side { get; }
        List<string> Drink { get; }
        List<string> Dessert { get; }
        string PrintOrderString();
        void AddMain(string val);
        void AddSide(string val);
        void AddDrink(string val);
        void AddDessert(string val);
    }
}
