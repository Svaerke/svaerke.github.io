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
                Size=0.65 
            },
            new CurrencyModel {
                Id="one",
                Denomination=1,
                ImageUrl="https://en.numista.com/catalogue/photos/danemark/g798.jpg",
                Size=0.6
            },
            new CurrencyModel {
                Id = "two",
                Denomination = 2.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g796.jpg",
                Size = 0.75
            },
            new CurrencyModel {
                Id = "five",
                Denomination = 5.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g1429.jpg",
                Size = 1
            },
            new CurrencyModel {
                Id = "ten",
                Denomination = 10.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g790.jpg",
                Size  = 0.7
            },
            new CurrencyModel {
                Id = "twenty",
                Denomination = 20.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g788.jpg",
                Size = 0.9
            }
        };
    }
}
