import axios from 'axios'

axios.interceptors.response.use(response => {
    return response;
}, error => {
    return error.response;
});

export default axios;
