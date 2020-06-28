import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import avatar from './assets/avatar.png';

import UserList from "./components/user/user-list.component";

class App extends Component {
  render() {
    return (
      <Router>
        <header class="bg-primary text-white text-center">
          <div class="container">
            <img class="img-fluid img-avatar" src={avatar} alt="Fernando José" />

            <div class="row">
              <div class="col">
                <h1>Fernando José</h1>
              </div>
            </div>

            <div class="row">
              <div class="col">
                <h2>Full Stack - Arquiteto - Net Core - React</h2>
              </div>
            </div>
          </div>
        </header>

        <Switch>
          <Route exact path={["/", "/users"]} component={UserList} />
        </Switch>
      </Router>
    );
  }
}

export default App;
