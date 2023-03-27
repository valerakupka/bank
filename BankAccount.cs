using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class BankAccount
    {
        private List<Transaction> AllTransactions = new List<Transaction>();

        private static UInt32 accountNumberSeed = 23232323;
        public UInt32 Number { get; }
        public string Owner { get; set; } //Właściciel
        private decimal balance;

        public decimal Balance
        {
            get
            {
                decimal transactionSum = 0;
                foreach (var transaction in AllTransactions)
                {
                    transactionSum += transaction.Amount;
                }
                return transactionSum + balance;
            }
            set { balance = value; }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed++;
            Console.WriteLine($"Utworzono nowe kontro z saldem: {initialBalance} zł");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"Dokonano wpłąty o kwtocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");
            }

            Transaction deposit = new Transaction(amount, date, note);
            AllTransactions.Add(deposit);

        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"Dokonano wypłaty w kwocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wypłacić kwoty ujemnej lub równej zero");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Brak wystarczających środków na koncie");
            }
            Transaction withdraw = new Transaction(-amount, date, note);
            AllTransactions.Add(withdraw);
           
        }

        public void ListTransactionHistory()
        {
            foreach (var transaction in AllTransactions)
            {
                Console.WriteLine($"Data transakcji: {transaction.Date}, kwota: {transaction.Amount} zł, notatka: {transaction.Note}");
            }
           
        }

        public void DisplayInfo()
        {
            decimal stan_konta = this.Balance;
            string acc_owner = this.Owner;
            Console.WriteLine($"Stan konta: {stan_konta} zł");
            Console.WriteLine($"Właściciel: {acc_owner}");
        }

    }
}
