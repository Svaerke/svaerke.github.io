using Microsoft.AspNetCore.Components;

namespace svaerke.github.io.Components {
    public partial class Currency
    {
        [Parameter]
        public string Id {get; set; }

        [Parameter]
        public string ImageUrl {get; set; }

        [Parameter]
        public double Size {get; set; }

        [Parameter]
        public double Amount {get; set; }

        private double currentCount = 0;

        private int baseSize = 10;
        private void IncrementUnit()
        {
            this.currentCount += Amount;
        }

        private void DecrementUnit()
        {
            if (this.currentCount >= Amount)
                this.currentCount -= Amount;
        }

        private string GetCoinSize() {
            return (baseSize * 2) * Size + "rem";
        }

        private string GetCoinRight() {
            return (baseSize * Size) - 0.5 + "rem";
        }
    }
}
