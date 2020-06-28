import React, { Component } from 'react'

export class Breadcrumb extends Component {
    render() {
        const { title } = this.props;

        return (
            <div className="title">
                <div className="container">
                    <div className="row">
                        <div className="col">{title}</div>
                    </div>
                </div>
            </div>
        )
    }
}

export default Breadcrumb