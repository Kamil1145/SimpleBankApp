using System;

namespace SimpleBankApp
{
    public class SimpleBank
    {
        public decimal Balance { get; set; }
        private const decimal MaxDebitValue = -100m; 

        public decimal Deposit(decimal money)
        {
            return money < 0 
                ? throw new Exception($"A negative amount is not possible {money}")
                : Balance + money;
        }

        public object Debit(decimal money)
        {
            return Balance - money < MaxDebitValue 
                ? throw new Exception($"Deduction is exceeding the Debit: {Balance}")
                : Balance-money;
        }
    }
}