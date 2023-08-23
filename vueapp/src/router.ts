import { createRouter, createWebHistory } from 'vue-router'
import Home from '@/views/HomePage.vue'
import Admin from '@/views/AdminPage.vue'

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
        }
        //{
        //    path: '/about',
        //    component: () => import('@/views/About.vue'),
        //},
        //{
        //    path: '/contact',
        //    component: () => import('@/views/Contact.vue'),
        //},
    ],
})