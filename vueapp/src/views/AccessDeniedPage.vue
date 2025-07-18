<!--<template>
    В доступе отказано
    <div class="container">
        

        <Login></Login>
    </div>
</template>-->
<template>
    <div class="access-denied-container">
        <div class="access-denied-card">
            <div class="access-denied-icon">
                <svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" fill="currentColor" viewBox="0 0 16 16">
                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
                    <path d="M7.002 11a1 1 0 1 1 2 0 1 1 0 0 1-2 0zM7.1 4.995a.905.905 0 1 1 1.8 0l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 4.995z" />
                </svg>
            </div>

            <h1 class="access-denied-title">{{ $t('access_denied.title') }}</h1>
            <p class="access-denied-message">{{ $t('access_denied.message') }}</p>

            <div v-if="!isLoggedIn" class="access-denied-actions">
                <button type="button"
                        class="btn btn-secondary"
                        data-bs-toggle="modal"
                        data-bs-target="#modalWindow">
                    {{ $t('nav-menu.login') }}
                </button>
                <router-link to="/" class="btn btn-outline-secondary">
                    {{ $t('access_denied.go_home') }}
                </router-link>
            </div>
            <div v-else class="access-denied-actions">
                <router-link to="/admin" class="btn btn-primary">
                    {{ $t('access_denied.go_to_admin') }}
                </router-link>
                <button @click="logout" class="btn btn-outline-secondary">
                    {{ $t('access_denied.logout') }}
                </button>
            </div>
        </div>

        <Login></Login>
    </div>
</template>
<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    import { mapState, mapActions } from 'vuex';

    const Login = defineAsyncComponent(() =>
        import('@/components/modal/LoginModalComponent.vue')
    )

    export default defineComponent({
        components: {
            Login
        },

        data() {
            return {
                isLoggedIn: false,
            }
        },
        computed: {
            ...mapState(['isLoggedIn', 'user']),
        },
        methods: {
            ...mapActions('auth', {
                init: 'init'
            }),
        },
        created() {
            this.init().then(result => {
                if (result) {
                    this.isLoggedIn = this.$store.state.auth.isLoggedIn;
                }
            });

        }

    });
</script>

<style>
    .access-denied-container {
        display: flex;
        justify-content: center;
        align-items: center;
        min-height: 80vh;
        padding: 2rem;
        background-color: #f8f9fa;
    }

    .access-denied-card {
        background: white;
        border-radius: 12px;
        box-shadow: 0 8px 30px rgba(0, 0, 0, 0.12);
        padding: 3rem;
        text-align: center;
        max-width: 600px;
        width: 100%;
        transition: transform 0.3s ease;
    }

        .access-denied-card:hover {
            transform: translateY(-5px);
        }

    .access-denied-icon {
        margin-bottom: 1.5rem;
        color: #dc3545;
    }

        .access-denied-icon svg {
            width: 80px;
            height: 80px;
        }

    .access-denied-title {
        font-size: 2rem;
        font-weight: 700;
        margin-bottom: 1rem;
        color: #343a40;
    }

    .access-denied-message {
        font-size: 1.1rem;
        color: #6c757d;
        margin-bottom: 2rem;
        line-height: 1.6;
    }

    .access-denied-actions {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }

    @media (min-width: 576px) {
        .access-denied-actions {
            flex-direction: row;
            justify-content: center;
        }
    }

    .btn {
        padding: 0.75rem 1.5rem;
        border-radius: 8px;
        font-weight: 500;
        transition: all 0.2s ease;
    }

    .btn-primary {
        background-color: #0d6efd;
        border-color: #0d6efd;
    }

        .btn-primary:hover {
            background-color: #0b5ed7;
            border-color: #0a58ca;
        }

    .btn-outline-secondary {
        border-color: #dee2e6;
        color: #495057;
    }

        .btn-outline-secondary:hover {
            background-color: #f8f9fa;
            border-color: #dee2e6;
        }
</style>
