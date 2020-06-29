import React, { Component } from "react";
import { Link } from 'react-router-dom';
import UserService from "../../services/user.service";
import Breadcrumb from '../share/breadcrumb.component';

export default class UserForm extends Component {
    constructor(props) {
        super(props);
        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeEmail = this.onChangeEmail.bind(this);
        this.onChangeIdType = this.onChangeIdType.bind(this);
        this.onChangeAvatar = this.onChangeAvatar.bind(this);
        this.onChangeCpfCnpj = this.onChangeCpfCnpj.bind(this);
        this.onChangeAddress = this.onChangeAddress.bind(this);
        this.save = this.save.bind(this);

        this.state = {
            guidUser: "",
            guidProfile: "",
            name: "",
            email: "",
            idType: "",
            avatar: "",
            cpfCnpj: "",
            address: "",
            loading: false,
            errors: []
        };
    }

    onChangeName(e) {
        this.setState({
            name: e.target.value
        });
    }

    onChangeEmail(e) {
        this.setState({
            email: e.target.value
        });
    }

    onChangeIdType(e) {
        this.setState({
            idType: e.target.value
        });
    }

    onChangeAvatar(e) {
        this.setState({
            avatar: e.target.value
        });
    }

    onChangeCpfCnpj(e) {
        this.setState({
            cpfCnpj: e.target.value
        });
    }

    onChangeAddress(e) {
        this.setState({
            address: e.target.value
        });
    }

    isValid() {
        let errors = [];
        if (this.state.name === '') {
            errors.push('Name is required');
        }

        if (this.state.email === '') {
            errors.push('E-mail is required');
        }

        if (this.state.idType === '') {
            errors.push('Type is required');
        }

        if (this.state.cpfCnpj === '') {
            errors.push('Document is required');
        }
        this.setState({ errors: errors });

        return errors.length === 0
    }

    save() {
        if (!this.isValid()) {
            return;
        }

        var data = {
            guidUser: this.state.guidUser,
            guidProfile: this.state.guidProfile,
            name: this.state.name,
            email: this.state.email,
            idType: this.state.idType,
            avatar: this.state.avatar,
            cpfCnpj: this.state.cpfCnpj,
            address: this.state.address
        };

        this.setState({ loading: true });
        if (this.state.guidUser === '' || this.state.guidProfile === '') {
            this.create(data);
        } else {
            this.update(data);
        }
    }

    create(data) {
        UserService.create(data)
            .then(response => {
                alert(response.data.object);
                this.setState({ loading: false });
                this.props.history.push("/users");
            })
            .catch(exception => {
                let errors = [];

                if (exception.response.data.object === undefined) {
                    errors.push(exception.response.data.title);
                }
                else {
                    errors = exception.response.data.object;
                }

                this.setState({
                    errors: errors,
                    loading: false
                });
            });
    }

    update(data) {
        UserService.update(data)
            .then(response => {
                alert(response.data.object);
                this.setState({ loading: false });
                this.props.history.push("/users");
            })
            .catch(exception => {
                let errors = [];

                if (exception.response.data.object === undefined) {
                    errors.push(exception.response.data.title);
                }
                else {
                    errors = exception.response.data.object;
                }

                this.setState({
                    errors: errors,
                    loading: false
                });
            });
    }

    render() {
        const { name, email, idType, avatar, cpfCnpj, address, loading, errors } = this.state;

        return (
            <div>
                <Breadcrumb title="User Form"></Breadcrumb>
                <div className="container margin-top-10">
                    <div className="row">
                        <div className="col-md-12">

                            {/* Name / E-mail */}
                            <div className="form-row">
                                <div className="form-group col-md-6">
                                    <label htmlFor="name">Name</label>
                                    <input type="text" className="form-control" id="name" name="name" required maxLength="100" value={name} onChange={this.onChangeName} />
                                </div>
                                <div className="form-group col-md-6">
                                    <label htmlFor="email">E-mail</label>
                                    <input type="text" className="form-control" id="email" name="email" required maxLength="150" value={email} onChange={this.onChangeEmail} />
                                </div>
                            </div>

                            {/* Type / CpfCnpj / Avatar */}
                            <div className="form-row">
                                <div className="form-group col-md-4">
                                    <label htmlFor="idType">Type</label>
                                    <select className="form-control" id="idType" name="idType" required value={idType} onChange={this.onChangeIdType}>
                                        <option value="">Select One</option>
                                        <option value="1">Personal</option>
                                        <option value="2">Professional</option>
                                    </select>
                                </div>
                                <div className="form-group col-md-4">
                                    <label htmlFor="cpfCnpj">Document</label>
                                    <input type="text" className="form-control" id="cpfCnpj" name="cpfCnpj" required maxLength="30" value={cpfCnpj} onChange={this.onChangeCpfCnpj} />
                                </div>
                                <div className="form-group col-md-4">
                                    <label htmlFor="avatar">Avatar</label>
                                    <input type="text" className="form-control" id="avatar" name="avatar" maxLength="50" value={avatar} onChange={this.onChangeAvatar} />
                                </div>
                            </div>

                            {/* Address */}
                            <div className="form-group">
                                <label htmlFor="address">Address</label>
                                <input type="text" className="form-control" id="address" name="address" maxLength="200" value={address} onChange={this.onChangeAddress} />
                            </div>

                            {/* Salvar e Cancelar */}
                            {loading
                                ? <button className="btn btn-success">Saving...</button>
                                : <button onClick={this.save} className="btn btn-success">Save</button>
                            }
                            &nbsp;<Link to={"/users"} className="btn btn-warning">Cancel</Link>

                            {/* Erros */}
                            {errors && errors.length > 0
                                ? <div className="alert alert-danger margin-top-10" role="alert">
                                    {errors.map((error, index) => (
                                        <div key={index}>{error}</div>
                                    ))}
                                </div>
                                : ''
                            }
                        </div>
                    </div>
                </div>
            </div >
        );
    }
}