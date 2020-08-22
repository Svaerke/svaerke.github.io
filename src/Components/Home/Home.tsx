import React, { Component } from "react";
import "./Home.css";

interface IState {
  total: number;
}
interface IProps {}

export class Home extends Component<IProps, IState> {
  constructor(props: {}) {
    super(props);

    this.state = { total: JSON.parse(localStorage.getItem("total") || "") };
  }
  render() {
    return (
      <div id="homeScene">
        <div className="sceneLinks">
          <a className="sceneLink" href="/count">
            <span aria-label="Count your coins" role="img">
              👛
            </span>
            Tæl
          </a>
          <a className="sceneLink" href="/buy">
            <span aria-label="check a price" role="img">
              🛒
            </span>
            køb
          </a>
        </div>
        <div id="footer">
          <span id="result">
            <span aria-label="user icon" role="img">
              👸 {this.state.total} kr
            </span>
          </span>
        </div>
      </div>
    );
  }
}

export default Home;
