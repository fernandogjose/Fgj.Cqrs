import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import avatar from './assets/avatar.png';
import UserList from "./components/user/user-list.component";
import UserForm from "./components/user/user-form.component";

class App extends Component {
  render() {
    return (
      <Router>
        <header className="bg-primary text-white text-center">
          <div className="container">
            <img className="img-fluid img-avatar" src={avatar} alt="Fernando José" />

            <div className="row">
              <div className="col">
                <h1>Fernando José</h1>
              </div>
            </div>

            <div className="row">
              <div className="col">
                <h2>Full Stack - Net Core - React - Architecture</h2>
              </div>
            </div>
          </div>
        </header>

        <Switch>
          <Route exact path={["/", "/users"]} component={UserList} />
          <Route exact path="/users" component={UserList} />
          <Route exact path="/user-create" component={UserForm} />
        </Switch>
      </Router>
    );
  }
}

export default App;
