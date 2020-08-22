import React, { Component } from "react";
import "./BuyScene.css";

interface IState {
  total: number;
  price: number;
}

interface IProps {}

export class BuyScene extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);

    this.state = {
      total: JSON.parse(localStorage.getItem("total") || ""),
      price: 0
    };
  }

  componentDidMount() {
    this.FocusPurchase();
  }

  FocusPurchase = () => {
    let purchaseInput = document.getElementById("purchase") as HTMLInputElement;
    purchaseInput.focus();
  };

  SavePrice = () => {
    let purchaseInput = document.getElementById("purchase") as HTMLInputElement;
    let purchase = purchaseInput.value
      ? parseFloat(purchaseInput.value.replace(",", "."))
      : 0;
    this.setState({ price: purchase });
  };

  GetCoins = () => {
    let coins: any[] = [[], []];

    let highIndex = 0;
    let lowIndex = 1;
    let highAmount = this.state.total;
    let lowAmount = this.state.price;

    if (lowAmount > highAmount) {
      highAmount = this.state.price;
      lowAmount = this.state.total;
      highIndex = 1;
      lowIndex = 0;
    }

    let percentage = (lowAmount / highAmount) * 100;

    // let modulus = amount % 10;
    let max = 20;
    let i = max;
    let fraction = (max / 100) * percentage;

    while (i >= 0) {
      if (i <= fraction) {
        coins[lowIndex].push(<li key={"one_" + i} />);
      }

      coins[highIndex].push(<li key={"two_" + i} />);
      i--;
    }

    // if (modulus % 10 !== 0) {
    //   result.unshift(<li className="andABit" />);
    // }
    return (
      <div className="coinStack">
        <ol>{coins[0].map((item: any) => item)}</ol>
        <ol className="price">{coins[1].map((item: any) => item)}</ol>
      </div>
    );
  };

  render() {
    return (
      <div id="buyScene">
        <a href="/" className="close">
          X
        </a>
        {this.GetCoins()}
        <div
          id="footer"
          className={this.state.total >= this.state.price ? "" : "error"}
        >
          <span id="userIcon" aria-label="user icon" role="img">
            👸 {this.state.total} kr
          </span>
          <span id="result">
            {/* {this.state.total >= this.state.price ? "Ja" : "Nej"} */}
          </span>
          <input
            type="text"
            name="purchase"
            id="purchase"
            onKeyUp={this.SavePrice}
          />
          <span
            id="purchaseIcon"
            aria-label="input purchase price"
            role="img"
            onClick={this.FocusPurchase}
          >
            🛒
          </span>
        </div>
      </div>
    );
  }
}

export default BuyScene;
