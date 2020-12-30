using System;
using Microsoft.AspNetCore.Components;
using svaerke.github.io.Models;
using svaerke.github.io.Services;

namespace svaerke.github.io.Components {
    public partial class Coin
    {
        [Inject]
        ICurrencyStorageService storage {get; set;}
        
        [Parameter]
        public CurrencyModel CurrencyModel {get; set;}

        private int count {get; set;}

        private double baseSize = 7.5;
        
        protected override void OnInitialized()
        {
            this.count = storage.GetCurrencyCount(CurrencyModel);
        }
        private void IncrementUnit()
        {
            count ++;
            storage.StoreCurrencyCount(CurrencyModel, count);
        }

        private void DecrementUnit()
        {
            if (count >= 1)
            {
                count --;
                storage.StoreCurrencyCount(CurrencyModel, count);
            }
        }

        private string GetCoinSize() {
            return (baseSize * 2) * CurrencyModel.Size + "rem";
        }

        private string GetCoinCenter() {
            return (((baseSize * 2) * CurrencyModel.Size) / 2) - 1 + "rem";
        }
    }
}
