using System;
using svaerke.github.io.Models;

namespace svaerke.github.io.Services
{
    public interface ICurrencyStorageService
    {
        public double CurrencyTotal {get; }
        public event Action OnChange;
         void StoreCurrencyCount(CurrencyModel currencyModel, int count);

         void ResetCurrencyCount();

         int GetCurrencyCount(string id);

         int GetCurrencyCount(CurrencyModel currencyModel);

         double GetCurrencyTotal();
    }
}