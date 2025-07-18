import { createRouter, createWebHistory } from 'vue-router'
import Home from '@/views/HomePage.vue'
import Admin from '@/views/AdminPage.vue'
import AboutPage from '@/views/About.vue';
import AccessDeniedPage from '@/views/AccessDeniedPage.vue'
import ArticlePage from '@/views/blog/ArticlePage.vue';
import BlogPage from '@/views/blog/BlogPage.vue';

export default createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: Home,
        },
        {
            path: '/admin',
            component: Admin,
            meta: { requiresAuth: true }
        },
        {
            path: '/blog',
            component: BlogPage,
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
        {
            path: '/401',
            name: 'AccessDeniedPage',
            component: AccessDeniedPage,
            meta: { requiresAuth: false, guestOnly: true } // Только для неавторизованных
        }
        //{
        //    path: '/contact',
        //    component: () => import('@/views/Contact.vue'),
        //},
    ],
})