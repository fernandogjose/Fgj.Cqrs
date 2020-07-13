import React, { Component } from 'react';

class Header extends Component {
    render() {
        return (
            <header>
                <section id="header-nav" className="header">
                    <div className="container">
                        <div className="row py-3">
                            <div className="col-6 col-md-2">
                                <img src="/images/logo.png" className="img-fluid" alt="Projeto fullstack"></img>
                            </div>
                            <div className="col-12 col-md-10 text-right">
                                <nav>
                                    <ul>
                                        <li><a href="/">Home</a></li>
                                        <li><a href="/">React</a></li>
                                        <li><a href="/">Contato</a></li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                    </div>
                </section>

                <section id="header-title" className="title">
                    <div className="container">
                        <div className="row">
                            <div className="col-12 col-md-8 text-white">
                                <h1 className="">ReactJS, Next.js, Angular, Net Core, DDD, CQRS, Mediator, Bootstrap, API Rest, MongoDB, SQL Server, Teste Integrado com Selenium, Teste de Unidade com XUnit</h1>
                                <p className="lead ">Bem vindo ao projeto fullstack, blog voltado para programadores sem frescura</p>
                            </div>
                            <div className="col-12 col-md-4 text-center avatar-img">
                                <img src="/images/avatar.png" alt="Fernando José" className="img-fluid"></img>
                                <p className="autor">Arquiteto | Fernando José | FullStack</p>
                            </div>
                        </div>
                    </div>
                </section>
            </header>
        )
    }
}

export default Header