import HeadTag from "./headtag";
import Header from "./header";
import Footer from "./footer";

function Layout({ children }) {
    const { title } = this.props;

    return <div>
        <HeadTag></HeadTag>
        <Header></Header>
        <p>{title}</p>
        {children}
        <Footer></Footer>
    </div>
}

export default Layout