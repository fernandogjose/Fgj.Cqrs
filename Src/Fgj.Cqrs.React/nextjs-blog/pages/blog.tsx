function Blog({ blogs }) {
    return <div>Next stars: {blogs}</div>
}

Blog.getInitialProps = async () => {
    const res = await fetch('https://localhost:44306/api/blog');
    const json = await res.json();
    return { stars: json.object }
}

export default Blog;