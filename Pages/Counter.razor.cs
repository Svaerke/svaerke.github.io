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
                ImageUrl="/assets/images/Currency/50ore.jpeg",
                Size=0.298611111111111
            },
            new CurrencyModel {
                Id="one",
                Denomination=1,
                ImageUrl="/assets/images/Currency/1kr.jpeg",
                Size=0.279861111111111
            },
            new CurrencyModel {
                Id = "two",
                Denomination = 2.0,
                ImageUrl = "/assets/images/Currency/2kr.jpeg",
                Size = 0.340277777777778
            },
            new CurrencyModel {
                Id = "five",
                Denomination = 5.0,
                ImageUrl = "/assets/images/Currency/5kr.jpeg",
                Size = 0.395833333333333
            },
            new CurrencyModel {
                Id = "ten",
                Denomination = 10.0,
                ImageUrl = "/assets/images/Currency/10kr.jpeg",
                Size  = 0.324305555555556
            },
            new CurrencyModel {
                Id = "twenty",
                Denomination = 20.0,
                ImageUrl = "/assets/images/Currency/20kr.jpeg",
                Size = 0.375
            },
            new CurrencyModel {
                Id = "fifty",
                Denomination = 50.0,
                ImageUrl = "/assets/images/Currency/50kr.jpeg",
                Size = 0.9,
                Type = CurrencyType.Note,
                AspectRatio = 0.576
            },
            new CurrencyModel {
                Id = "onehundred",
                Denomination = 100.0,
                ImageUrl = "/assets/images/Currency/100kr.jpeg",
                Size = 1,
                Type = CurrencyType.Note,
                AspectRatio = 0.533
            },
            new CurrencyModel {
                Id = "twohundred",
                Denomination = 200.0,
                ImageUrl = "/assets/images/Currency/200kr.jpeg",
                Size = 1.1,
                Type = CurrencyType.Note,
                AspectRatio = 0.4965517241
            },
            new CurrencyModel {
                Id = "fivehundred",
                Denomination = 500.0,
                ImageUrl = "/assets/images/Currency/500kr.jpeg",
                Size = 1.2,
                Type = CurrencyType.Note,
                AspectRatio = 0.464516129
            },
            new CurrencyModel {
                Id = "oneThousand",
                Denomination = 1000.0,
                ImageUrl = "/assets/images/Currency/1000kr.jpeg",
                Size = 1.3,
                Type = CurrencyType.Note,
                AspectRatio = 0.4363636364
            }
        };
    }
}
