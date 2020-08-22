import React, { Component } from "react";
import { IUnitCount } from "../../Interfaces/IUnitCount.Interface";
import config from "../../config";
import { ICurrency } from "../../Interfaces/ICurrency.Interface";
import update from "immutability-helper";
import "./CounterScene.css";

interface IState {
  total: number;
  storedUnits: IUnitCount;
  units: IUnitCount;
}

interface IProps {}

enum UpdateAction {
  Add,
  Subtract
}

export class CounterScene extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    var unitsFromStorage = localStorage.getItem("units") || "{}";
    var unitsFromStorageParsed = JSON.parse(unitsFromStorage) as IUnitCount;

    if (Object.keys(unitsFromStorageParsed).length === 0) {
      config.currency.forEach(function(unit) {
        unitsFromStorageParsed[unit.id] = {
          amount: unit.amount,
          count: 0
        };
      });
    }

    this.state = {
      total: JSON.parse(localStorage.getItem("total") || ""),
      storedUnits: unitsFromStorageParsed,
      units: unitsFromStorageParsed
    };
  }

  // FindUnitCount = (unitId: string) => {
  //   if (!this.state.Units) return 0;

  //   var count = this.state.Units.find(function(unitCount: IUnitCount) {
  //     return unitCount.id === unitId;
  //   });

  //   return count ? count : 0;
  // };

  IncrementUnit = (event: React.MouseEvent<HTMLElement>) => {
    this.UpdateCount(event.target as HTMLElement, UpdateAction.Add);
  };

  DecrementUnit = (event: React.MouseEvent<HTMLElement>) => {
    this.UpdateCount(event.target as HTMLElement, UpdateAction.Subtract);
  };

  SaveCount = () => {
    localStorage.setItem("units", JSON.stringify(this.state.units));
    localStorage.setItem("total", JSON.stringify(this.state.total));
  };

  UpdateCount = (eventTarget: HTMLElement, action: UpdateAction) => {
    var wrapper = (eventTarget as HTMLElement).closest(
      ".coinWrapper"
    ) as HTMLElement;

    var unitId = wrapper.id;
    var count = this.state.units[unitId] ? this.state.units[unitId].count : 0;

    var updatedCount = count;
    if (action === UpdateAction.Add) {
      updatedCount++;
    } else {
      updatedCount--;
    }

    if (updatedCount <= 0) {
      updatedCount = 0;
    }
    this.setState(
      {
        units: update(this.state.units, {
          [unitId]: { count: { $set: updatedCount } }
        })
      },
      () => this.UpdateTotal()
    );
  };

  UpdateTotal = () => {
    var total = this.GetTotal();
    this.setState({ total: total });
  };

  GetTotal = () => {
    var total = 0;
    for (const unit in this.state.units) {
      if (this.state.units.hasOwnProperty(unit)) {
        total += this.state.units[unit].amount * this.state.units[unit].count;
      }
    }
    return total;
  };

  render() {
    return (
      <div id="counterScene">
        <a href="/" className="close">
          X
        </a>
        <ol id="coins">
          {config.currency.map((unit: ICurrency) => (
            <li className="coinWrapper" id={unit.id} key={unit.id}>
              <span className="coinSubtract" onClick={this.DecrementUnit}>
                -
              </span>
              <span className="coinAdd" onClick={this.IncrementUnit}>
                +
              </span>
              <span
                className="count"
                style={{
                  visibility:
                    this.state.units[unit.id] &&
                    this.state.units[unit.id].count > 0
                      ? "visible"
                      : "hidden"
                }}
              >
                {this.state.units[unit.id]
                  ? this.state.units[unit.id].count
                  : 0}
              </span>
              <div
                className="coin"
                style={{
                  backgroundImage: "url(" + unit.imageUrl + ")",
                  width: this.GetCoinSize(unit.size) + "rem",
                  height: this.GetCoinSize(unit.size) + "rem",
                  right: this.GetCoinSize(unit.size) / 2 - 0.5 + "rem"
                }}
                onClick={this.IncrementUnit}
              />
            </li>
          ))}
        </ol>
        <div id="footer">
          <span id="result">
            <span aria-label="user icon" role="img">
              👸 {this.state.total} kr
            </span>
          </span>
          <button id="save" onClick={this.SaveCount}>
            <span aria-label="save" role="img">
              ✔️
            </span>
          </button>
        </div>
      </div>
    );
  }

  GetCoinSize(coinSize: number): number {
    return 10 * coinSize;
  }
}

export default CounterScene;
