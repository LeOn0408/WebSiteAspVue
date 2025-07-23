import { Helper } from '@/lib/helper';
import { type AxiosInstance } from "axios";
import { createAxios } from "../../lib/factory";
import { type authenticatedUser } from './authenticatedUser'

export default {
    namespaced: true,
    state: {
        isLoggedIn: false,
        user:null
    },
    mutations: {
        login(state: any, user: authenticatedUser) {
            state.isLoggedIn = true;
            state.user = user.user;
            localStorage.setItem('user', JSON.stringify(user.user))
            localStorage.setItem('token', user.jwtToken)
        },
        logout(state: any) {
            state.isLoggedIn = false;
            state.user = null;
            localStorage.removeItem('user');
            localStorage.removeItem('token');
        }
        
    },
    actions: {
        async init(context: any,) {
            const token = localStorage.getItem('token');
            const userRaw = localStorage.getItem('user');

            if (token && userRaw) {
                const axios: AxiosInstance = createAxios();

                try {
                    await axios.get('/api/validate');
                    const user = JSON.parse(userRaw);
                    context.commit('login', { user, jwtToken: token })
                    return true;
                }

                catch (error: any) {
                    context.commit('logout')
                    return { error: error.message }

                };
            }
            return false;
        },
        async login(context: any,
            user: { username: string, password: string }) {

            const hashPass: string = await Helper.sha256(user.password);
            try {
                const axios: AxiosInstance = createAxios();
                const result = await axios.post("/api/authenticate", {
                    hashPass,
                    username: user.username
                });
                context.commit('login', result.data)
                return true;
            }

            catch (error: any) {
                context.commit('logout')
                return { error: error.message }

            }
        },
        async logout(context: any)
        {
            context.commit('logout')
        }

    }
};

