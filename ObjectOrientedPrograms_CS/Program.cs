using System;
using ObjectOrientedPrograms_CS.DeckofCards;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DECK OF CARDS PROBLEM");
            Cards obj = new Cards();
            obj.Suffle();
            Console.ReadLine();
        }
    }
}
