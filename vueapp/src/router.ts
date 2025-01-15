import { createRouter, createWebHistory } from 'vue-router'
import Home from '@/views/HomePage.vue'
import Admin from '@/views/AdminPage.vue'
import AboutPage from '@/views/About.vue';
import ArticlePage from '@/views/blog/ArticlePage.vue'; // Страница статьи

export default createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: Home,
        },
        {
            path: '/admin',
            component: Admin
        },
        {
            path: '/article/:id',
            name: 'ArticlePage',
            component: ArticlePage,
            props: true, // Передача параметра id как prop
        },
        {
            path: '/about',
            name: 'AboutPage',
            component: AboutPage,
        },
        //{
        //    path: '/contact',
        //    component: () => import('@/views/Contact.vue'),
        //},
    ],
})