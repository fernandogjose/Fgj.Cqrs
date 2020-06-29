import React, { Component } from 'react'
import { Link } from 'react-router-dom';
import Loading from '../share/loading.component';

export class UserTable extends Component {
    render() {
        const { loading, users, usersPerPage, usersTotal, paginate, prevPage, nextPage, currentPage, userDelete } = this.props;
        const pageNumbers = [];

        if (loading) {
            return (
                <Loading></Loading>
            );
        }

        const pagesTotal = Math.ceil(usersTotal / usersPerPage);
        for (let i = 1; i <= pagesTotal; i++) {
            pageNumbers.push(i);
        }

        return (
            <div className="container margin-top-10">
                <table className="table">

                    {/* Head */}
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>E-mail</th>
                            <th>Type</th>
                            <th>CpfCnpj</th>
                            <th><Link to={"/user-create"} className="btn btn-sm btn-primary">Create</Link></th>
                        </tr>
                    </thead>

                    {/* List */}
                    <tbody>
                        {users && users.map((user, index) => (
                            <tr key={index}>
                                <td>{user.name}</td>
                                <td>{user.email}</td>
                                <td>{user.type}</td>
                                <td>{user.cpfCnpj}</td>
                                <td>
                                    <Link to={"/user-edit/" + user.guidUser} className="btn btn-sm btn-success">Edit</Link>&nbsp;
                                    <button className="btn btn-sm btn-danger" onClick={() => userDelete(user.guidUser, user.guidProfile)}>Delete</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>

                    {/* Pagination */}
                    <tfoot>
                        <tr>
                            <td colSpan="5">
                                <nav>
                                    <ul className="pagination justify-content-center">
                                        <li className="page-item">
                                            {
                                                currentPage === 1
                                                    ? <button className="page-link">Previous</button>
                                                    : <button className="page-link" onClick={() => prevPage()}>Previous</button>
                                            }
                                        </li>

                                        {
                                            pageNumbers.map(num => (
                                                <li className="page-item" key={num}>
                                                    <button onClick={() => paginate(num)} className="page-link">{num}</button>
                                                </li>
                                            ))
                                        }

                                        <li className="page-item">
                                            {
                                                currentPage === pagesTotal
                                                    ? <button className="page-link">Next</button>
                                                    : <button className="page-link" onClick={() => nextPage()}>Next</button>
                                            }
                                        </li>
                                    </ul>
                                </nav>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        )
    }
}

export default UserTable