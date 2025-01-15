<template>
    <nav class="navbar navbar-expand-lg shadow-sm">
        <div class="container-fluid">
            <!-- Логотип -->
            <a class="navbar-brand d-flex align-items-center" href="#">
                <img src="../assets/images/logo2.png" alt="Logo" width="40" height="30" class="d-inline-block align-middle me-2">
                <span class="fw-bold">aparshukov</span>
            </a>
            <!-- Кнопка для раскрытия меню на маленьких экранах -->
            <button class="navbar-toggler" type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNavAltMarkup"
                    aria-controls="navbarNavAltMarkup"
                    aria-expanded="false"
                    aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <!-- Основное меню -->
            <div class="collapse navbar-collapse justify-content-end" id="navbarNavAltMarkup">
                <div class="navbar-nav">
                    <router-link class="nav-link" :class="{ active: isActive('/') }" to="/">{{ $t('nav-menu.main') }}</router-link>
                    <router-link class="nav-link" :class="{ active: isActive('/projects') }" to="/projects">{{ $t('nav-menu.projects') }}</router-link>
                    <router-link class="nav-link" :class="{ active: isActive('/about') }" to="/about">{{ $t('nav-menu.about') }}</router-link>
                </div>
                <!-- Кнопка входа -->
                <div class="navbar-nav ms-3" v-if="false">
                    <button type="button" class="btn btn-outline-light btn-sm" data-bs-toggle="modal" data-bs-target="#modalWindow">
                        {{ $t('nav-menu.login') }}
                    </button>
                    <Login></Login>
                </div>
            </div>
        </div>
    </nav>
</template>

<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    import { useRoute } from 'vue-router';

    const Login = defineAsyncComponent(() =>
        import('./modal/LoginModalComponent.vue')
    );

    export default defineComponent({
        components: {
            Login
        },
        setup() {
            const route = useRoute();
            const isActive = (path: string) => route.path === path;

            return { isActive };
        },
    });
</script>

<style scoped>
    .navbar {
        background: linear-gradient(45deg, #2c3e50, #34495e);
        color: #ecf0f1;
    }

    .navbar-brand {
        font-size: 1.25rem;
        color: #f1f1f1;
        text-transform: uppercase;
    }

        .navbar-brand:hover {
            color: #d1d1d1;
            text-decoration: none;
        }

    .nav-link {
        color: #f1f1f1;
        font-weight: 500;
        transition: color 0.3s ease;
    }

        .nav-link:hover {
            color: #d1d1d1;
        }

        .nav-link.active {
            color: #ff6347 !important;
            font-weight: bold;
            border-bottom: 2px solid #ff6347;
            transition: all 0.3s ease;
        }

    .btn-outline-light {
        border-color: #f1f1f1;
        color: #f1f1f1;
        transition: all 0.3s ease;
    }

    .btn-outline-light:hover {
        background-color: #f1f1f1;
        color: #212529;
        border-color: #f1f1f1;
    }

    @media (max-width: 768px) {
        .navbar-brand {
            font-size: 1rem;
        }

        .nav-link {
            font-size: 0.875rem;
        }
    }
</style>
