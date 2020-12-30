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
            ResetUnit();
            storage.OnChange -= ResetUnit;
        }

        public void Dispose()
        {
            storage.OnChange -= ResetUnit;
        }

        private void ResetUnit()
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

        private double Getwidth() {
            return (baseSize * 2) * CurrencyModel.Size;
        }

        private double GetHeight() {
            double result = 0;
            switch (CurrencyModel.Type)
            {
                case CurrencyType.Note:
                    result = ((baseSize * 2) * CurrencyModel.Size) * CurrencyModel.AspectRatio;
                    break;
                default:
                    result = this.Getwidth();
                    break;
            }
            return result;
        }

        private double GetCoinCenter() {
            return ((this.GetHeight()) / 2) - 1;
        }
    }
}
