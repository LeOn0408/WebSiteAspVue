import axios, { AxiosInstance} from 'axios';
import { getAuthHeader } from './helper';


export function createAxios(): AxiosInstance {

    const instance = axios.create();
    instance.defaults.headers.post['Content-Type'] = 'application/json';
    instance.interceptors.request.use(config => {

        config.headers.Authorization = getAuthHeader();
        return config;
    });

    instance.interceptors.response.use(response => response, error => {
        if (error.response.status === 401) {
            const refreshInstance = axios.create({ baseURL: "/api" });
            return new Promise((resolve, reject) => {
                refreshInstance
                    .post("/refresh-token")
                    .then((result) => {
                        localStorage.setItem("user", JSON.stringify(result.data));
                        error.config.headers.Authorization = `Bearer ${result.data.jwtToken}`;
                        resolve(instance.request(error.config));
                    })
                    .catch((refreshError) => {
                        console.error(refreshError);
                        localStorage.removeItem('user');
                        //reject(refreshError);
                    });
            });
        }

    });
    return instance;
}