import React, { Component } from 'react';
import HeadTag from "./headtag";
import Header from "./header";
import Footer from "./footer";
import Breadcrumb from './breadcrumb';

class Layout extends Component {
    render() {
        const { children, title } = this.props;

        return <div>
            <HeadTag title={title}></HeadTag>
            <Header></Header>

            <main>
                <Breadcrumb></Breadcrumb>
                {children}
            </main>

            <Footer></Footer>
        </div>
    }
}

export default Layout