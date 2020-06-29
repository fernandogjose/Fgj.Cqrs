import React, { Component } from 'react';
import UserService from '../../services/user.service';
import Breadcrumb from '../share/breadcrumb.component';
import UserTable from './user-table.component';

export default class UserList extends Component {
    constructor(props) {
        super(props);

        this.getAll = this.getAll.bind(this);
        this.refreshList = this.refreshList.bind(this);
        this.delete = this.delete.bind(this);
        this.state = {
            loading: true,
            users: [],
            currentPage: 1,
            usersPerPage: 5,
        };
    }

    componentDidMount() {
        this.getAll();
    }

    getAll() {
        UserService.getAll()
            .then(response => {
                this.setState({
                    loading: false,
                    users: response.data.object
                });
            })
            .catch(exception => {
                console.log(exception);
                alert("Error in api")
                this.setState({ loading: false });
            });
    }

    refreshList() {
        this.setState({
            loading: true,
            users: [],
            currentPage: 1
        });
        this.getAll();
    }

    delete(guidUser, guidProfile) {
        UserService.delete(guidUser, guidProfile)
            .then(response => {
                this.refreshList();
            })
            .catch(exception => {
                console.log(exception);
                alert("Error in api")
            });
    }

    render() {
        const { loading, users, currentPage, usersPerPage } = this.state;
        const indexOfLastUser = currentPage * usersPerPage;
        const indexOfFirstUser = indexOfLastUser - usersPerPage;
        const currentUsers = [];
        const paginate = pageNum => this.setState({ currentPage: pageNum });
        const prevPage = () => this.setState({ currentPage: currentPage - 1 });
        const nextPage = () => this.setState({ currentPage: currentPage + 1 });

        for (let index = indexOfFirstUser; index < indexOfLastUser; index++) {
            if (users[index] !== undefined) {
                currentUsers.push(users[index]);
            }
        }

        return (
            <div>
                <Breadcrumb title="User List"></Breadcrumb>
                <UserTable loading={loading} users={currentUsers} usersPerPage={usersPerPage} usersTotal={users.length} paginate={paginate} prevPage={prevPage} nextPage={nextPage} currentPage={currentPage} userDelete={this.delete}></UserTable>
            </div>
        );
    }
}