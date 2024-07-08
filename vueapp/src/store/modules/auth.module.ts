import { Helper } from '@/lib/helper';
import axios from 'axios';
import { type authenticatedUser } from './authenticatedUser'

export default {
    state: {
        //user: {},
    },
    mutations: {
        login(state: any, user: authenticatedUser) {
            localStorage.setItem('user', JSON.stringify(user))
        }
    },
    actions: {
        async login(context: any,
            user: { username: string, password: string }) {

            const hashPass: string = await Helper.sha256(user.password);
            try {
                const result = await axios.post("/api/authenticate", {
                    hashPass,
                    username: user.username
                });
                context.commit('login', result.data)
                return true;
            }

            catch (error:any) {
                return { error: error.message }
            }
        }

    }
};

