import { createApp } from 'vue'
import router from './router'
import App from './App.vue'
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap-icons/font/bootstrap-icons.css";
import 'font-awesome/css/font-awesome.min.css';
import { createStore } from 'vuex'
import { createI18n } from 'vue-i18n'
import ru from './locales/ru.json';
import en from './locales/en.json';
import authModule from './store/modules/auth.module';
import userModule from './store/modules/user.module'
import { createAxios } from './lib/factory';
import { Logger } from './lib/services/Logger';

//TODO:Implement localization
const localeFromStorage = localStorage.getItem('userLocale');
const browserLocale = navigator.language.split('-')[0];

const preferredLocale = localeFromStorage || browserLocale;

const i18n = createI18n({
    locale: preferredLocale || 'en',
    messages: {
        ru: ru,
        en:en,
    },
    globalInjection: true,
})


const instance = createAxios();

const store = createStore({
    modules: {
        auth: authModule,
        user: userModule,
    },
    state() {
        return {
            preferredLocale: preferredLocale,
            axios: instance
        };
    },
    mutations: {
    },
    actions: {
    },
    getters: {
    }
});
const app = createApp(App);


router.beforeEach(async (to, from, next) => {
    await store.dispatch('auth/init')

    const isAuthenticated = store.state.auth.isLoggedIn
    
    if (to.matched.some(record => record.meta.requiresAuth)) {
        console.log(isAuthenticated);
        if (!isAuthenticated) {
            next({
                name: 'AccessDeniedPage',
                query: { redirect: encodeURIComponent(to.fullPath) }
            })
        } else {
            next()
        }
    } else {
        next()
    }
})

app.use(router)
    .use(store)
    .use(i18n)
    .provide('logger', new Logger())
    .mount('#app');
