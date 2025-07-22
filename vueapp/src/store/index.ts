// store/index.ts
import type { AxiosInstance } from 'axios';
import type { InjectionKey } from 'vue';
import { createStore, Store } from 'vuex';
import authModule from './modules/auth.module';
import userModule from './modules/user.module';
import { createAxios } from '../lib/factory';

export interface AuthState {
    isLoggedIn: boolean;
    user: any | null;
}

export interface RootState {
    preferredLocale: string;
    axios: AxiosInstance;
}

export interface State extends RootState {
    auth: AuthState;
}

export const key: InjectionKey<Store<State>> = Symbol();

export default createStore<State>({
    modules: {
        auth: authModule,
        user: userModule,
    },
    state: {
        preferredLocale: 'ru',
        axios: createAxios(),
        auth: { isLoggedIn: false, user: null }
    } as State,
});