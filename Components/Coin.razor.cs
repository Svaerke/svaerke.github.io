using Microsoft.AspNetCore.Components;

namespace svaerke.github.io.Components {
    public partial class Coin
    {
        [Parameter]
        public CurrencyModel CurrencyModel {get; set; }

        private double currentCount = 0;

        private double baseSize = 7.5;
        private void IncrementUnit()
        {
            this.currentCount ++;
        }

        private void DecrementUnit()
        {
            if (this.currentCount >= 1)
                this.currentCount --;
        }

        private string GetCoinSize() {
            return (baseSize * 2) * CurrencyModel.Size + "rem";
        }

        private string GetCoinCenter() {
            return (((baseSize * 2) * CurrencyModel.Size) / 2) - 1 + "rem";
        }
    }
}
