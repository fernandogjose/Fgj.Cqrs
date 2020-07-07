import { GetStaticProps } from "next"
import { BlogModel } from "../models/blog.model"
import BlogService from "../services/blog.service";

interface BlogProps {
    blogs: BlogModel[];
}

export default function Blog({ blogs }: BlogProps) {
    return <div>
        {blogs
            ? blogs.map(x => <div>{x.date.toDateString()} | {x.title}</div>)
            : "Nenhum registro foi encontrado"
        }
    </div>
}

export const getStaticProps: GetStaticProps = async () => {
    const blogs = BlogService.getAll();
    return { props: { blogs } };
}