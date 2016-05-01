using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frenchFries
{
    class Program
    {
        private static bool canExit = false;
        static void Main(string[] args)
        {
            string inputName = "", inputMount = "";
            people p = new people();
            Console.Write("please input who is going to eat French Fries:");
            inputName = Console.ReadLine();
            Console.Write("please input how many French Fries {0} wants to eat:", inputName);
            inputMount = Console.ReadLine();
            int num = int.Parse(inputMount);
            p.name = inputName;
            p.eating(num);
            p.f.nothingToEat += F_nothingToEat;
            while(!canExit)
            {
                ;
            }
        }

        private static void F_nothingToEat()
        {
            canExit = true;
        }
    }
}
