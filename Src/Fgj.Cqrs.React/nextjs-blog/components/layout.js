import HeadTag from "./headtag";
import Header from "./header";
import Footer from "./footer";

function Layout({ children, title }) {
    return <div>
        <HeadTag title={title}></HeadTag>
        <Header></Header>
        {children}
        <Footer></Footer>
    </div>
}

export default Layout