import http from "../http-common";

class BlogService {
    private endPoint: string;

    constructor() {
        this.endPoint = "/user";
    }

    getAll() {
        // return http.get(this.endPoint)
        return fetch(`https://localhost:44306/api/blog`);
    }
}

export default new BlogService();