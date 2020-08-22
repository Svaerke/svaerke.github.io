import { IConfig } from "./Interfaces/IConfig.Interface";

let config: IConfig = {
  currency: [
    {
      id: "pointFive",
      amount: 0.5,
      imageUrl: "https://en.numista.com/catalogue/photos/danemark/g915.jpg",
      size: 0.65
    },
    {
      id: "one",
      amount: 1.0,
      imageUrl: "https://en.numista.com/catalogue/photos/danemark/g798.jpg",
      size: 0.6
    },
    {
      id: "two",
      amount: 2.0,
      imageUrl: "https://en.numista.com/catalogue/photos/danemark/g796.jpg",
      size: 0.75
    },
    {
      id: "five",
      amount: 5.0,
      imageUrl: "https://en.numista.com/catalogue/photos/danemark/g1429.jpg",
      size: 1
    },
    {
      id: "ten",
      amount: 10.0,
      imageUrl: "https://en.numista.com/catalogue/photos/danemark/g790.jpg",
      size: 0.7
    },
    {
      id: "twenty",
      amount: 20.0,
      imageUrl: "https://en.numista.com/catalogue/photos/danemark/g788.jpg",
      size: 0.9
    }
  ]
};

export default config;
