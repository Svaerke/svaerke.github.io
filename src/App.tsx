import React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import CounterScene from "./Components/CounterScene/CounterScene";
import BuyScene from "./Components/BuyScene/BuyScene";
import Home from "./Components/Home/Home";
import "./App.css";

function CustomRouter() {
  return (
    <Router>
      <Route exact path="/" component={Home} />
      <Route path="/count" component={CounterScene} />
      <Route path="/buy" component={BuyScene} />
    </Router>
  );
}

export default CustomRouter;
