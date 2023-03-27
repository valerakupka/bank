using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class Credit
    {
        private decimal credit_amount = 0;
        public void AddCredit(decimal credit, decimal amount)
        {
            if ((credit + amount) > 1000)
            {
                Console.WriteLine("Nie możesz mieć więcej kredytu niż 1000zł!");
            }
            else
            {
                Console.WriteLine($"Wziąłeś kredyt o sumie: {amount}");
                Console.WriteLine($"Łączna kwota kredytu: {credit}");
            }
        }
        public void PayForCredit(decimal credit, decimal amount)
        {
            Console.WriteLine($"Spłaciłeś: {amount}");
            Console.WriteLine($"Łączna pozostała kwota kredytu: {credit}");

        }
    }
}
