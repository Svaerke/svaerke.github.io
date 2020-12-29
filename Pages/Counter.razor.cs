using svaerke.github.io.Components;

namespace svaerke.github.io.Pages {
    public partial class Counter
    {
        private CurrencyModel[] currencyModels = new CurrencyModel[] {
            new CurrencyModel {
                Id = "pointFive",
                Amount = 0.5,
                ImageUrl="https://en.numista.com/catalogue/photos/danemark/g915.jpg",
                Size=0.65 
            },
            new CurrencyModel {
                Id="one",
                Amount=1,
                ImageUrl="https://en.numista.com/catalogue/photos/danemark/g798.jpg",
                Size=0.6
            },
            new CurrencyModel {
                Id = "two",
                Amount = 2.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g796.jpg",
                Size = 0.75
            },
            new CurrencyModel {
                Id = "five",
                Amount = 5.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g1429.jpg",
                Size = 1
            },
            new CurrencyModel {
                Id = "ten",
                Amount = 10.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g790.jpg",
                Size  = 0.7
            },
            new CurrencyModel {
                Id = "twenty",
                Amount = 20.0,
                ImageUrl = "https://en.numista.com/catalogue/photos/danemark/g788.jpg",
                Size = 0.9
            }
        };
    }
}
