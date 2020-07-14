import React, { Component } from 'react';

class Header extends Component {
    render() {
        return (
            <header>
                <section id="header-nav" className="header">
                    <div className="container">
                        <nav className="navbar navbar-expand-lg navbar-dark">
                            {/* Logo */}
                            <a className="navbar-brand" href="#"><img src="/header/logo.png" className="img-fluid" alt="Projeto fullstack" /></a>

                            {/* Hamburguer */}
                            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                                <span className="navbar-toggler-icon"></span>
                            </button>

                            {/* Menu */}
                            <div className="collapse navbar-collapse justify-content-between" id="navbarNavAltMarkup">
                                <div className="navbar-nav">
                                    <a className="nav-item nav-link" href="#">Home</a>
                                    <a className="nav-item nav-link" href="#">React</a>
                                    <a className="nav-item nav-link" href="#">Angular</a>
                                    <a className="nav-item nav-link" href="#">Net Core</a>
                                    <a className="nav-item nav-link" href="#">Contato</a>
                                </div>
                            </div>
                        </nav>
                    </div>
                </section>

                <section id="header-title" className="title">
                    <div className="container">
                        <div className="row">
                            <div className="col-12 col-md-8 text-white">
                                <h1 className="text-left">ReactJS, Next.js, Angular, Net Core, DDD, CQRS, Mediator, Bootstrap, API Rest, MongoDB, SQL Server, Teste Integrado com Selenium, Teste de Unidade com XUnit, Service Bus, Kafka</h1>
                                <p className="lead ">Bem vindo ao projeto fullstack, blog voltado para programadores sem frescura</p>
                            </div>
                            <div className="col-12 col-md-4 text-center avatar-img">
                                <img src="/header/avatar.png" alt="Fernando José" className="img-fluid" />
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