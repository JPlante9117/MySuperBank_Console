using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; set; }
        public string Owner { get; set; }
        private decimal Balance { get; set; }

        private static int accountNumberSeed = 1234567890;

        public BankAccount(string name, decimal initialBalance)
        {
            Balance = initialBalance;
            Owner = name;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
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
