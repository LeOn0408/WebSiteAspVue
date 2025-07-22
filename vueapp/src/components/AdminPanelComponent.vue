<template>
    <div v-if="isLoggedIn" class="welcome-banner shadow-sm d-flex justify-content-between align-items-center px-4 py-2">
        <div class="welcome-text">
            👋 Добро пожаловать, <strong>{{ user.firstName }}</strong>!
        </div>
        <button @click="logout" class="btn btn-sm btn-outline-light">
            Выйти
        </button>
    </div>
</template>

<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    import { mapState, mapActions } from 'vuex';

    export default defineComponent({
        data() {
            return {
                name: '',
                /*isLoggedIn: *//*true*//*,*/
            }
        },
        methods: {
            ...mapActions('user', {
                user: 'getUser',
                admin: 'isAdmin',
            }),
            ...mapActions('auth', {
                init: 'init',
                logout: 'logout'
            }),
        },
        created() {
            this.init().then(result => {
                if (result) {
                }
            });
        },
        computed: {
            ...mapState('auth', ['isLoggedIn', 'user'])
        }
    });
</script>
<style>
    .welcome-banner {
        background: linear-gradient(90deg, #2c3e50, #34495e);
        color: #ffffff;
        font-size: 0.95rem;
        font-weight: 500;
        border-top-left-radius: 6px;
        border-top-right-radius: 6px;
        border-bottom-left-radius: 0;
        border-bottom-right-radius: 0;
        position: sticky;
        top: 0;
        z-index: 1050;
        max-width: 100%;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.25); /* тень снизу */
    }

        .welcome-banner .btn {
            transition: all 0.2s ease-in-out;
            white-space: nowrap;
        }

            .welcome-banner .btn:hover {
                background-color: #ecf0f1;
                color: #2c3e50;
            }

    /* Адаптация под мобильные устройства */
    @media (max-width: 576px) {
        .welcome-banner {
            flex-direction: column;
            align-items: flex-start;
            padding: 0.75rem;
            font-size: 0.9rem;
        }

        .welcome-text {
            margin-bottom: 0.5rem;
        }

        .welcome-banner .btn {
            width: 100%;
        }
    }

</style>