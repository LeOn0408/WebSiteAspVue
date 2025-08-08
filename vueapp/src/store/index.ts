// store/index.ts
import type { InjectionKey } from 'vue';
import { createStore, Store } from 'vuex';
import authModule from './modules/auth.module';
import userModule from './modules/user.module';

export interface AuthState {
    isLoggedIn: boolean;
    user: any | null;
}

export interface RootState {
    preferredLocale: 'ru' | 'en';
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
        auth: { isLoggedIn: false, user: null }
    } as State,
    mutations: {
        setPreferredLocale(state, locale: 'ru' | 'en') {
            state.preferredLocale = locale
        }
    }
});