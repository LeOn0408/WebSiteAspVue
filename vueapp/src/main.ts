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
import articleModule from './store/modules/article.module'
import { createAxios } from './lib/factory';


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
        article: articleModule
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


app.use(router)
    .use(store)
    .use(i18n)
    .mount('#app');
