using System;


namespace ProstyBank
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                playWithAccount();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Coś poszło nie tak: {e.Message}");
                Console.ReadKey();
            }
        }

        static public void playWithAccount()
        {
            // Wywoływanie wszystkich operacji na koncie
            DateTime localDate = DateTime.Now;
            Console.WriteLine("Wybierz opcje z menu:\n"+
                "1.Utworzyć konto w banku;\n" +
                "2.Wyjdź;\n");
            int select = Convert.ToInt32(Console.ReadLine());
            switch (select)
            {
                case 1:
                    
                    Console.WriteLine("Wpisz imię i nazwisko:");
                    string Owner = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Ile chcesz wpłacić na konto:");
                    decimal Balance = Convert.ToDecimal(Console.ReadLine());
                    BankAccount account = new BankAccount(Owner, Balance);
                    Credit credit = new Credit();
                    decimal wartosc_kredytu = 0;

                    Console.WriteLine("Wybierz opcje z menu:\n" +
                        "1.Wpłać pieniądzy;\n" +
                        "2.Wypłać pieniądzy;\n" +
                        "3.Historia transakcji;\n" +
                        "4.Informacja o koncie;\n" +
                        "5.Weź kredyt;\n" +
                        "6.Spłać kredyt;\n" +
                        "7.Wyjdź\n");
                    int select1 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (select1)
                    {
                        case 1:
                            Console.WriteLine("Ile chcesz wpłacić");
                            decimal kwota = Convert.ToDecimal(Console.ReadLine());
                            account.MakeDeposit(kwota, localDate, "wpłata");
                            
                            break;
                        case 2:
                            Console.WriteLine("Ile chcesz wypłacić:");
                            decimal kwota1 = Convert.ToDecimal(Console.ReadLine());
                            account.MakeWithdraw(kwota1, localDate, "wypłata");
                           
                            break;
                        case 3:
                            account.ListTransactionHistory();
                            break;
                        case 4:
                            account.DisplayInfo();
                            break;
                        case 5:
                            Console.WriteLine("Na jaką kwotę chcesz wziąć kredyt?");
                            decimal kwota3 = Convert.ToDecimal(Console.ReadLine());
                            wartosc_kredytu += kwota3;
                            credit.AddCredit(wartosc_kredytu, kwota3);
                            break;
                           
                        case 6:
                            Console.WriteLine("Na jaką kwotę chcesz spłacić kredyt?");
                            decimal kwota4 = Convert.ToDecimal(Console.ReadLine());

                            if (kwota4 > wartosc_kredytu)
                            {
                                wartosc_kredytu = 0;
                            }
                            else
                            {
                                wartosc_kredytu -= kwota4;

                            }
                            credit.PayForCredit(wartosc_kredytu, kwota4);
                            break;
                        case 7:
                            Console.WriteLine("Do zobaczenia!");
                            Console.ReadKey();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Do zobaczenia!");
                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }

    }
}

