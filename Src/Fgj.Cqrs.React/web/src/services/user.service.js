import http from "../http-common";

class UserService {
    constructor() {
        this.endPoint = "/user";
    }

    create(data) {
        return http.post(this.endPoint)
    }

    update(data) {
        return http.put(this.endPoint);
    }

    delete(guidUser, guidProfile) {
        return http.delete(`${this.endPoint}/${guidUser}/${guidProfile}`)
    }

    getAll() {
        return http.get(this.endPoint)
    }

    getByGuid(guid) {
        return http.get(`${this.endPoint}/${guid}`)
    }
}

export default new UserService();