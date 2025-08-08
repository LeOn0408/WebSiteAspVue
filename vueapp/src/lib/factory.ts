import axios, { type AxiosInstance} from 'axios';
import { Helper } from './helper';


export function createAxios(): AxiosInstance {

    const instance = axios.create();
    instance.defaults.headers.post['Content-Type'] = 'application/json';
    instance.interceptors.request.use(config => {

        config.headers.Authorization = Helper.getAuthHeader();
        return config;
    });

    instance.interceptors.response.use(response => response, error => {
        if (error.response.status === 401) {
            const token = localStorage.getItem('token');
            const userRaw = localStorage.getItem('user');
            if (!token || !userRaw)
                return error;
            const refreshInstance = axios.create({ baseURL: "/api" });
            return new Promise((resolve, reject) => {
                refreshInstance
                    .post("/refresh-token")
                    .then((result) => {
                        localStorage.setItem('user', JSON.stringify(result.data.user));
                        localStorage.setItem('token', result.data.jwtToken);
                        error.config.headers.Authorization = `Bearer ${result.data.jwtToken}`;
                        resolve(instance.request(error.config));
                    }, reason => {
                        localStorage.removeItem('user');
                        reject(reason);
                    }
                    );
            });
        }

    });
    return instance;
}