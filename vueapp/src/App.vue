<template>
    <div class="app-layout">
        <!-- Fixed Header -->
        <header class="app-header">
            <Navigation class="nav-container" />
            <AdminPanel class="admin-panel" />
        </header>

        <!-- Main Content -->
        <main class="app-main">
            <div class="main-container">
                <!-- Main Content Area -->
                <div class="content-area">
                    <div class="content-wrapper">
                        <router-view v-slot="{ Component }">
                            <transition name="page-fade" mode="out-in">
                                <component :is="Component" />
                            </transition>
                        </router-view>
                    </div>
                </div>
            </div>
        </main>

        <!-- Footer -->
        <Footer class="app-footer" />
    </div>
</template>

<script lang="ts">
    import { defineComponent } from "vue";
    import Navigation from "./components/NavigationComponent.vue";
    import AdminPanel from "./components/AdminPanelComponent.vue";
    import Footer from "./components/Footer.vue";

    export default defineComponent({
        name: 'AppLayout',
        components: {
            Navigation,
            AdminPanel,
            Footer
        },
    });
</script>

<style scoped>
    .app-layout {
        min-height: 100vh;
        display: flex;
        flex-direction: column;
        background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 50%, #ffffff 100%);
        position: relative;
    }

        .app-layout::before {
            content: '';
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: radial-gradient(circle at 20% 80%, rgba(120, 119, 198, 0.03) 0%, transparent 50%), radial-gradient(circle at 80% 20%, rgba(255, 119, 198, 0.03) 0%, transparent 50%), radial-gradient(circle at 40% 40%, rgba(120, 219, 255, 0.02) 0%, transparent 50%);
            pointer-events: none;
            z-index: 0;
        }

    .app-header {
        position: sticky;
        top: 0;
        z-index: 1000;
        background: rgba(255, 255, 255, 0.95);
        backdrop-filter: blur(20px);
        border-bottom: 1px solid rgba(255, 255, 255, 0.2);
        box-shadow: 0 2px 30px rgba(0, 0, 0, 0.08);
    }

    .nav-container {
        position: relative;
        z-index: 2;
    }

    .admin-panel {
        position: absolute;
        top: 100%;
        left: 0;
        right: 0;
        z-index: 1;
        background: rgba(255, 255, 255, 0.98);
        backdrop-filter: blur(20px);
        border-bottom: 1px solid rgba(0, 0, 0, 0.1);
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
    }

    .app-main {
        flex: 1;
        position: relative;
        z-index: 1;
        padding: 2rem 0;
    }

    .main-container {
        max-width: 1200px;
        margin: 0 auto;
        padding: 0 1.5rem;
    }

    .content-area {
        position: relative;
        width: 100%;
    }

    .content-wrapper {
        background: rgba(255, 255, 255, 0.8);
        backdrop-filter: blur(10px);
        border-radius: 20px;
        border: 1px solid rgba(255, 255, 255, 0.3);
        box-shadow: 0 8px 32px rgba(0, 0, 0, 0.08), inset 0 1px 0 rgba(255, 255, 255, 0.6);
        overflow: hidden;
        transition: all 0.3s ease;
    }

        .content-wrapper:hover {
            box-shadow: 0 12px 40px rgba(0, 0, 0, 0.12), inset 0 1px 0 rgba(255, 255, 255, 0.8);
            transform: translateY(-2px);
        }

    .app-footer {
        margin-top: auto;
        background: rgba(255, 255, 255, 0.9);
        backdrop-filter: blur(10px);
        border-top: 1px solid rgba(255, 255, 255, 0.3);
        box-shadow: 0 -4px 20px rgba(0, 0, 0, 0.05);
    }

    /* Page Transitions */
    .page-fade-enter-active,
    .page-fade-leave-active {
        transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
    }

    .page-fade-enter-from {
        opacity: 0;
        transform: translateY(10px);
    }

    .page-fade-leave-to {
        opacity: 0;
        transform: translateY(-10px);
    }

    /* Responsive Design */
    @media (max-width: 768px) {
        .app-main {
            padding: 1rem 0;
        }

        .main-container {
            padding: 0 1rem;
        }

        .content-wrapper {
            border-radius: 16px;
            margin: 0 0.5rem;
        }

            .content-wrapper:hover {
                transform: none;
            }
    }

    @media (max-width: 480px) {
        .app-main {
            padding: 0.5rem 0;
        }

        .main-container {
            padding: 0 0.5rem;
        }

        .content-wrapper {
            border-radius: 12px;
            margin: 0;
        }
    }

    /* Loading States */
    .content-wrapper.loading {
        position: relative;
        overflow: hidden;
    }

        .content-wrapper.loading::after {
            content: '';
            position: absolute;
            top: 0;
            left: -100%;
            width: 100%;
            height: 100%;
            background: linear-gradient( 90deg, transparent, rgba(255, 255, 255, 0.6), transparent );
            animation: loading-shimmer 1.5s infinite;
        }

    @keyframes loading-shimmer {
        0% {
            left: -100%;
        }

        100% {
            left: 100%;
        }
    }

    /* Print Styles */
    @media print {
        .app-header,
        .app-footer {
            display: none;
        }

        .app-main {
            padding: 0;
        }

        .main-container {
            padding: 0;
        }

        .content-wrapper {
            background: white;
            box-shadow: none;
            border: none;
            border-radius: 0;
        }
    }
</style>

<style>
    /* Global scroll behavior */
    html {
        scroll-behavior: smooth;
    }

    /* Focus styles for accessibility */
    *:focus {
        outline: 2px solid #667eea;
        outline-offset: 2px;
    }

    /* Selection styles */
    ::selection {
        background: rgba(102, 126, 234, 0.2);
        color: inherit;
    }

    ::-moz-selection {
        background: rgba(102, 126, 234, 0.2);
        color: inherit;
    }
</style>