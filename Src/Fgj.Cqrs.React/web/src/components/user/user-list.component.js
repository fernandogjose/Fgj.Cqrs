import React, { Component } from 'react';
import UserService from '../../services/user.service';
import { Link } from 'react-router-dom';

export default class UserList extends Component {
    constructor(props) {
        super(props);
        this.getAll = this.getAll.bind(this);
        this.refreshList = this.refreshList.bind(this);
        this.delete = this.delete.bind(this);

        this.state = {
            users: [],
            currentUser: null,
            currentIndex: -1,
        };

        this.getAll();
    }

    getAll() {
        UserService.getAll()
            .then(response => {
                this.setState({
                    users: response.data.object
                });
            })
            .catch(exception => {
                console.log(exception.message.object === undefined ? exception.message : exception.message.object);
            });
    }

    refreshList() {
        this.getAll();
        this.setState({
            currentUser: null,
            currentIndex: -1
        });
    }

    setActiveUser(user, index) {
        this.setState({
            currentUser: user,
            currentIndex: index
        });
    }

    delete() {
        UserService.delete()
            .then(response => {
                this.refreshList();
            })
            .catch(e => {
                console.log(e.object);
            });
    }

    render() {
        const { users, currentUser, currentIndex } = this.state;

        return (

            // <div className="title">
            //     <div className="container">
            //         <div className="row">
            //             <div className="col">Users</div>
            //         </div>
            //     </div>
            // </div>

            <div className="list row">
                <div className="col-md-12">
                    <h4>User List</h4>

                    <ul className="list-group">
                        {users && users.map((user, index) => (
                            <li className={"list-group-item " + (index === currentIndex ? "active" : "")} onClick={() => this.setActiveUser(user, index)} key={index}>
                                {user.name}
                            </li>
                        ))}
                    </ul>

                    <button className="m-3 btn btn-sm btn-danger" onClick={this.delete}>Delete</button>
                </div>
            </div>
        );
    }
}