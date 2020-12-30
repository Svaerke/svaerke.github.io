using svaerke.github.io.Models;
using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Linq;
using System;

namespace svaerke.github.io.Services
{
    public class CurrencyStorageService : ICurrencyStorageService
    {
        private const string storageKey = "CurrencyStorageService.Currencies";
        private ISyncLocalStorageService localStorage;
        private Dictionary<string, StoredCurrency> storedCurrencies { get; set; }

        public event Action OnChange;
        public double CurrencyTotal {get; private set; }

        public CurrencyStorageService(ISyncLocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            this.storedCurrencies = localStorage.GetItem<Dictionary<string, StoredCurrency>>(storageKey) ?? new Dictionary<string, StoredCurrency>();
            CurrencyTotal = this.GetCurrencyTotal();
        }

        public void StoreCurrencyCount(CurrencyModel currencyModel, int count)
        {
            if (string.IsNullOrWhiteSpace(currencyModel?.Id)) return;

            var storedCurrency = new StoredCurrency { CurrencyModel = currencyModel, Count = count };
            storedCurrencies[currencyModel.Id] = storedCurrency;
            
            localStorage.SetItem(storageKey, storedCurrencies);
            CurrencyTotal = this.GetCurrencyTotal();
            this.NotifyStateChanged();
        }

        public int GetCurrencyCount(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return 0;
            var model = storedCurrencies.FirstOrDefault(stored => stored.Key == id);

            return model.Value?.Count ?? 0;
        }

        public int GetCurrencyCount(CurrencyModel currencyModel)
        {
            return this.GetCurrencyCount(currencyModel?.Id);
        }

        public double GetCurrencyTotal()
        {
            double total = 0;

            foreach (var currencyModel in storedCurrencies)
            {
                var amount = currencyModel.Value.CurrencyModel.Denomination * currencyModel.Value.Count;
                total += amount;
            }

            return total;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}