using System;

namespace SimpleBankApp
{
    public class CurrencyService
    {
        public virtual decimal GetCurrencyRate(string currency)
        {
            // get currency data from database or api 
            return 4.08m;
        }
    }
}