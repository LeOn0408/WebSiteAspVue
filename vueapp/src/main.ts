import { createApp } from 'vue'
import router from './router'
import App from './App.vue'
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap-icons/font/bootstrap-icons.css";
import 'font-awesome/css/font-awesome.min.css';
import { createI18n } from 'vue-i18n'
import ru from './locales/ru.json';
import en from './locales/en.json';
import { Logger } from './lib/services/Logger';
import store, { key } from './store';

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





const app = createApp(App);

app.use(store, key);

router.beforeEach(async (to, from, next) => {
    await store.dispatch('auth/init')

    const isAuthenticated = store.state.auth.isLoggedIn
    
    if (to.matched.some(record => record.meta.requiresAuth)) {
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
