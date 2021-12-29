using System;
using System.Diagnostics;

namespace SimpleBankApp
{
    public class SimpleBank
    {
        public decimal Balance { get; set; }
        private const decimal MaxDebitValue = -100m;
        private readonly CurrencyService _currencyService;
        
        public SimpleBank(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

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
        
        public decimal MakeCurrencyTransfer(string currency, decimal amount)
        {
            var curr = _currencyService.GetCurrencyRate(currency);
            return curr * amount;
        }
    }
}