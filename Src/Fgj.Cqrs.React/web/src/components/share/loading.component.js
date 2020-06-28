import React, { Component } from 'react'

export class Loading extends Component {
    render() {
        return (
            <div className="container margin-top-10">
                <div className="row">
                    <div className="col-md-12">
                        <span>Loading...</span>
                    </div>
                </div>
            </div>
        )
    }
}

export default Loading