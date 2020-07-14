import React, { Component } from 'react';
import Head from 'next/head';

class HeadTag extends Component {
    render() {
        const { title } = this.props;

        return (
            <Head>
                <title>{title}</title>
                <link rel="icon" href="/images/favicon.ico" />
                <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossOrigin="anonymous"></link>
            </Head>
        )
    }
}

export default HeadTag;