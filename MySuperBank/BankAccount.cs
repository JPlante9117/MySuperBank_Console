using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public List<string> Owners = new List<string>();
        private List<Transaction> allTransactions = new List<Transaction>();
        private decimal Balance {
            get {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        
        private static int accountNumberSeed = 1234567890;

        public BankAccount(string name)
        {
            Owners.Add(name);
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
        public string ListOwners()
        {
            string owners = Owners[0];
            
            if(Owners.Count > 1)
            {
                for (int i = 1; i < Owners.Count; i++)
                {
                    owners += ", " + Owners[i];
                }
            }
            
            return owners;
        }
        public void MakeDeposit(decimal depositAmt, DateTime date, string note)
        {

            Balance += depositAmt;
            Console.WriteLine($"{date} -- NEW BAL {Balance} -- {note}");
        }
        public void MakeWithdrawal(decimal withdrawalAmt, DateTime date, string note)
        {
            if(Balance - withdrawalAmt < 0)
            {
                Console.WriteLine("OVERDRAFT PROTECTION: CANNOT WITHDRAW FUNDS");
            } else
            {
                Balance -= withdrawalAmt;
                Console.WriteLine($"{date} -- NEW BAL {Balance} -- {note}");

            }
        }
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
