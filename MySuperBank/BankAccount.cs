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

        public BankAccount(string name, decimal initialBalance)
        {
            Balance = initialBalance;
            Owner = name;
            Number = "1023648501";
        }
        public void MakeDeposit(decimal depositAmt, DateTime date, string note)
        {

        }
        public void MakeWithdrawal(decimal withdrawalAmt, DateTime date, string note)
        {

        }
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
