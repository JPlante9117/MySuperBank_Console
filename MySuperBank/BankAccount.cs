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

        public BankAccount(string name, decimal initialBal)
        {
            MakeDeposit(initialBal, DateTime.Now, "CREATING ACCOUNT...");
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
            if(depositAmt <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depositAmt), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(depositAmt, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal withdrawalAmt, DateTime date, string note)
        {
            if(withdrawalAmt <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(withdrawalAmt), "Amount of withdrawal must be positive");
            }
            if(Balance - withdrawalAmt < 0)
            {
                throw new InvalidOperationException("OVERDRAFT: Not enough funds");
            }
            var withdrawal = new Transaction(-withdrawalAmt, date, note);
            allTransactions.Add(withdrawal);
        }
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
