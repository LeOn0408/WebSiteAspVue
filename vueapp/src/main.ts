import { createApp } from 'vue'
import router from './router'
import App from './App.vue'
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap-icons/font/bootstrap-icons.css";
import 'font-awesome/css/font-awesome.min.css';
import { i18n } from './i18n'
import { Logger } from './lib/services/Logger';
import store, { key } from './store';

store.commit('setPreferredLocale', i18n.global.locale.value as 'ru' | 'en')

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

createApp(App)
    .use(store)
    .use(router)
    .use(i18n)
    .provide('logger', new Logger())
    .mount('#app')
