<template>
    <nav class="navbar">
        <div class="nav-container">
            <!-- Логотип -->
            <router-link to="/" class="brand">
                <div class="brand-logo">
                    <img src="../assets/images/logo2.png" alt="Logo">
                </div>
                <span class="brand-text">aparshukov</span>
            </router-link>

            <!-- Навигация -->
            <div class="nav-menu">
                <div class="nav-links">
                    <router-link v-for="item in navItems"
                                 :key="item.to"
                                 :to="item.to"
                                 class="nav-link"
                                 :class="{ 'active': isActive(item.to) }">
                        <span class="nav-text">{{ $t(item.text) }}</span>
                        <span class="nav-indicator"></span>
                    </router-link>
                </div>

                <!-- Дополнительные элементы -->
                <div class="nav-actions" v-if="false">
                    <button class="login-btn">
                        {{ $t('nav-menu.login') }}
                    </button>
                </div>
            </div>

            <!-- Mobile Toggle -->
            <button class="mobile-toggle" @click="toggleMobileMenu">
                <span></span>
                <span></span>
                <span></span>
            </button>
        </div>
    </nav>
</template>

<script lang="ts">
    import { defineComponent, computed } from 'vue';
    import { useRoute } from 'vue-router';

    export default defineComponent({
        name: 'AppNavbar',
        setup() {
            const route = useRoute();

            const isActive = (path: string) => route.path === path;

            const navItems = computed(() => [
                { to: '/', text: 'nav-menu.main' },
                { to: '/blog', text: 'nav-menu.blog' },
                { to: '/about', text: 'nav-menu.about' }
            ]);

            const toggleMobileMenu = () => {
                // Логика для мобильного меню
                document.querySelector('.nav-menu')?.classList.toggle('active');
            };

            return { isActive, navItems, toggleMobileMenu };
        },
    });
</script>

<style scoped>
    .navbar {
        background: rgba(255, 255, 255, 0.95);
        backdrop-filter: blur(20px);
        border-bottom: 1px solid rgba(255, 255, 255, 0.2);
        box-shadow: 0 2px 30px rgba(0, 0, 0, 0.1);
        position: sticky;
        top: 0;
        z-index: 1000;
    }

    .nav-container {
        max-width: 1200px;
        margin: 0 auto;
        padding: 0 1.5rem;
        display: flex;
        align-items: center;
        justify-content: space-between;
        height: 70px;
    }

    .brand {
        display: flex;
        align-items: center;
        gap: 0.75rem;
        text-decoration: none;
        color: inherit;
        transition: transform 0.3s ease;
    }

        .brand:hover {
            transform: translateY(-1px);
        }

    .brand-logo {
        width: 40px;
        height: 40px;
        border-radius: 10px;
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        display: flex;
        align-items: center;
        justify-content: center;
        overflow: hidden;
    }

        .brand-logo img {
            width: 24px;
            height: 24px;
            filter: brightness(0) invert(1);
        }

    .brand-text {
        font-size: 1.25rem;
        font-weight: 800;
        background: linear-gradient(135deg, #2c3e50 0%, #3498db 100%);
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        background-clip: text;
    }

    .nav-menu {
        display: flex;
        align-items: center;
        margin-left: 10px;
        gap: 2rem;
    }

    .nav-links {
        display: flex;
        gap: 0.5rem;
    }

    .nav-link {
        position: relative;
        padding: 0.75rem 1.25rem;
        text-decoration: none;
        color: #2c3e50;
        font-weight: 500;
        border-radius: 12px;
        transition: all 0.3s ease;
        overflow: hidden;
    }

        .nav-link::before {
            content: '';
            position: absolute;
            top: 0;
            left: -100%;
            width: 100%;
            height: 100%;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            opacity: 0.1;
            transition: left 0.3s ease;
        }

        .nav-link:hover::before {
            left: 0;
        }

        .nav-link:hover {
            color: #667eea;
        }

        .nav-link.active {
            color: #667eea;
            background: rgba(102, 126, 234, 0.1);
        }

    .nav-indicator {
        position: absolute;
        bottom: 0;
        left: 50%;
        transform: translateX(-50%);
        width: 0;
        height: 2px;
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        transition: width 0.3s ease;
        border-radius: 1px;
    }

    .nav-link.active .nav-indicator {
        width: 20px;
    }

    .login-btn {
        padding: 0.5rem 1.5rem;
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        color: white;
        border: none;
        border-radius: 25px;
        font-weight: 500;
        transition: all 0.3s ease;
        cursor: pointer;
    }

        .login-btn:hover {
            transform: translateY(-1px);
            box-shadow: 0 5px 15px rgba(102, 126, 234, 0.3);
        }

    .mobile-toggle {
        display: none;
        flex-direction: column;
        gap: 4px;
        background: none;
        border: none;
        cursor: pointer;
        padding: 0.5rem;
    }

        .mobile-toggle span {
            width: 20px;
            height: 2px;
            background: #2c3e50;
            transition: all 0.3s ease;
            border-radius: 1px;
        }

    /* Адаптивность */
    @media (max-width: 768px) {
        .nav-container {
            padding: 0 1rem;
        }

        .mobile-toggle {
            display: flex;
        }

        .nav-menu {
            position: fixed;
            top: 70px;
            left: 0;
            width: 100%;
            background: white;
            flex-direction: column;
            padding: 1rem;
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.1);
            transform: translateY(-100%);
            opacity: 0;
            visibility: hidden;
            transition: all 0.3s ease;
        }

            .nav-menu.active {
                transform: translateY(0);
                opacity: 1;
                visibility: visible;
            }

        .nav-links {
            flex-direction: column;
            width: 100%;
        }

        .nav-link {
            padding: 1rem;
            border-radius: 8px;
            justify-content: center;
        }

        .brand-text {
            font-size: 1.1rem;
        }
    }

    @media (max-width: 480px) {
        .nav-container {
            height: 60px;
        }

        .brand-logo {
            width: 35px;
            height: 35px;
        }

            .brand-logo img {
                width: 20px;
                height: 20px;
            }
    }
</style>