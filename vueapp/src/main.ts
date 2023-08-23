import { createApp } from 'vue'
import router from './router'
import App from './App.vue'
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { createStore } from 'vuex'
import { createI18n } from 'vue-i18n'
import ru from './locales/ru.json';
import en from './locales/en.json';
import authModule from './modules/main/authModule';

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


const store = createStore({
    modules: {
        auth: authModule,
    },
    state() {
        return {
            preferredLocale: preferredLocale
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


app.use(router)
    .use(store)
    .use(i18n)
    .mount('#app');
