using Microsoft.AspNetCore.Components;

namespace svaerke.github.io.Components {
    public partial class Coin
    {
        [Inject]
        Blazored.LocalStorage.ISyncLocalStorageService localStorage {get; set;}

        [Parameter]
        public CurrencyModel CurrencyModel {get; set;}

        private double currentCount = 0;

        private double baseSize = 7.5;
        private void IncrementUnit()
        {
            this.currentCount ++;
            
            var total = localStorage.GetItem<double>("counterTotal");
            localStorage.SetItem<double>("counterTotal", total + CurrencyModel.Amount);
        }

        private void DecrementUnit()
        {
            if (this.currentCount >= 1)
                this.currentCount --;
            
            var total = localStorage.GetItem<double>("counterTotal");
            var value = total - CurrencyModel.Amount;
            if (value < 0) value = 0;

            localStorage.SetItem<double>("counterTotal", value);
        }

        private string GetCoinSize() {
            return (baseSize * 2) * CurrencyModel.Size + "rem";
        }

        private string GetCoinCenter() {
            return (((baseSize * 2) * CurrencyModel.Size) / 2) - 1 + "rem";
        }
    }
}
