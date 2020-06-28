import axios from 'axios'

export default axios.create({
    baseURL: "https://localhost:44306/api",
    headers: {
        "Content-type": "application/json"
    }
});