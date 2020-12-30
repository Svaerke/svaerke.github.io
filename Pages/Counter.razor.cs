using System;
using Microsoft.AspNetCore.Components;
using svaerke.github.io.Models;
using svaerke.github.io.Services;

namespace svaerke.github.io.Pages {
    public partial class Counter : IDisposable
    {
        [Inject]
        ICurrencyStorageService storage {get; set;}
        
        protected override void OnInitialized()
        {
            storage.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            storage.OnChange -= StateHasChanged;
        }

        private CurrencyModel[] currencyModels = new CurrencyModel[] {
            new CurrencyModel {
                Id = "pointFive",
                Denomination = 0.5,
                ImageUrl="https://en.numista.com/catalogue/photos/danemark/g915.jpg",
                Size=0.298611111111111
            },
            new CurrencyModel {
                Id="one",
                Denomination=1,
                ImageUrl="https://en.numista.com/catalogue/photos/danemark/g798.jpg",
                Size=0.279861111111111
            },
            new CurrencyModel {
                Id = "two",
                Denomination = 2.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g796.jpg",
                Size = 0.340277777777778
            },
            new CurrencyModel {
                Id = "five",
                Denomination = 5.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g1429.jpg",
                Size = 0.395833333333333
            },
            new CurrencyModel {
                Id = "ten",
                Denomination = 10.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g790.jpg",
                Size  = 0.324305555555556
            },
            new CurrencyModel {
                Id = "twenty",
                Denomination = 20.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g788.jpg",
                Size = 0.375
            },
            new CurrencyModel {
                Id = "fifty",
                Denomination = 50.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/5e97325f3e5b51.81312186-original.jpg",
                Size = 0.9,
                Type = CurrencyType.Note,
                AspectRatio = 0.576
            },
            new CurrencyModel {
                Id = "onehundred",
                Denomination = 100.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/5e973333b98811.27588858-original.jpg",
                Size = 1,
                Type = CurrencyType.Note,
                AspectRatio = 0.533
            },
            new CurrencyModel {
                Id = "twohundred",
                Denomination = 200.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/5e9eb3dc4759f7.72456052-original.jpg",
                Size = 1.1,
                Type = CurrencyType.Note,
                AspectRatio = 0.4965517241
            },
            new CurrencyModel {
                Id = "fivehundred",
                Denomination = 500.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/5e9eb6d31dc562.98596921-original.jpg",
                Size = 1.2,
                Type = CurrencyType.Note,
                AspectRatio = 0.464516129
            },
            new CurrencyModel {
                Id = "oneThousand",
                Denomination = 1000.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/5e9eb8fec56899.36903072-original.jpg",
                Size = 1.3,
                Type = CurrencyType.Note,
                AspectRatio = 0.4363636364
            }
        };
    }
}
