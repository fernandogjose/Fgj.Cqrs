import React, { Component } from 'react';

class Breadcrumb extends Component {
    render() {
        return (
            <section id="breadcrumb" className="breadcrumb">
                <div className="container">
                    <div className="row">
                        <nav>
                            <ul>
                                <li><a href="/">Home</a></li>
                                <li>
                                    <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-chevron-right" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M4.646 1.646a.5.5 0 0 1 .708 0l6 6a.5.5 0 0 1 0 .708l-6 6a.5.5 0 0 1-.708-.708L10.293 8 4.646 2.354a.5.5 0 0 1 0-.708z" />
                                    </svg>
                                </li>
                                <li><a href="/">Blog</a></li>
                                <li>
                                    <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-chevron-right" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M4.646 1.646a.5.5 0 0 1 .708 0l6 6a.5.5 0 0 1 0 .708l-6 6a.5.5 0 0 1-.708-.708L10.293 8 4.646 2.354a.5.5 0 0 1 0-.708z" />
                                    </svg>
                                </li>
                                <li>Criando um site com ReactJS e Next.js</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </section>
        )
    }
}

export default Breadcrumb