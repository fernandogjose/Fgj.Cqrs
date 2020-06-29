import axios from 'axios'

export default axios.create({
    baseURL: "https://localhost:44306/api",
    // baseURL: "https://fgj-cqrs-backend.azurewebsites.net/api",
    headers: {
        "Content-type": "application/json"
    }
});