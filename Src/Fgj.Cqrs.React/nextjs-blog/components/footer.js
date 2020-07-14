import React, { Component } from 'react';

class Footer extends Component {
    render() {
        return (
            <footer className="footer">
                <div className="container">
                    <div className="row">
                        <div className="col-12 text-center">
                            <p>Criado por Fernando José</p>
                            <p>fernandogjose@gmail.com</p>
                            <p>
                                <a href="https://github.com/fernandogjose" target="_blank" rel="noreferrer">GitHub</a> |
                                <a href="https://www.linkedin.com/in/fernando-jos%C3%A9-701027158/" target="_blank" rel="noreferrer">LinkedIn</a>
                            </p>
                        </div>
                    </div>
                </div>
            </footer>
        )
    }
}

export default Footer