import { sha256 } from '@/lib/helper';
import axios from 'axios';
import { authenticatedUser } from './authenticatedUser'

export default {
    state: {
        user: {},
    },
    mutations: {
        login(state: any, user: authenticatedUser) {
            state.user = {
                name: user.username,
                email: user.email
            };
            localStorage.setItem('token', user.jwtToken)
            localStorage.setItem('ref-token', user.refreshToken)
            console.log(user);
        }
    },
    actions: {
        login(context: any,
            user: { username: string, password: string }) {

            sha256(user.password).then(
                result => {

                    axios.post("/api/user/authenticate", {
                        hashPass: result,
                        username: user.username
                    }).then(
                        result => context.commit('login', result.data),
                        error => {
                            return false
                        }
                    )

                },
                error => {
                    return false
                }
            )
            //context.commit('login', new Promise((resolve, reject) => {
            //    sha256(user.password).then(
            //        result => {
                        
            //            axios.post("/api/user/authenticate", {
            //                hashPass: result,
            //                username: user.username
            //            }).then(
            //                result => resolve(result),
            //                error => reject(error)
            //            )
                        
            //        },
            //        error => reject(error)
            //    )
            //}));
        }

    }
};

