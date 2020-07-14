import React, { Component } from 'react';
import HeadTag from "./headtag";
import Header from "./header";
import Footer from "./footer";

class Layout extends Component {
    render() {
        const { children, title } = this.props;

        return <div>
            <HeadTag title={title}></HeadTag>
            <Header></Header>
            {children}
            <Footer></Footer>
        </div>
    }
}

export default Layout