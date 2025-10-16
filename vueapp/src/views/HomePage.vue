<template>
    <div class="home-page">
        <!-- home Section -->
        <section class="home-section text-center">
            <div class="container">
                <div class="home-content">
                    <h1 class="home-title animate-fade-in">
                        {{ $t('home.welcome') }}
                    </h1>
                    <p class="home-subtitle animate-fade-in-delayed">
                        {{ $t('home.description') }}
                    </p>
                </div>
            </div>
        </section>

        <!-- News Section -->
        <section class="news-section">
            <div class="container">
                <div class="section-header">
                    <h2 class="section-title">
                        <i class="bi bi-newspaper"></i>
                        <router-link to="/blog" class="section-link">
                            {{ $t('home.news') }}
                        </router-link>
                    </h2>
                    <div class="section-divider"></div>
                </div>

                <NewsList />
            </div>
        </section>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue'
    import NewsList from '@/components/home/NewsList.vue'

    export default defineComponent({
        name: 'HomePage',
        components: {
            NewsList
        }
    })
</script>

<style scoped>
    .home-page {
        min-height: 100vh;
        background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
    }

    .home-section {
        padding: 6rem 0 4rem;
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        color: white;
        position: relative;
        overflow: hidden;
    }

        .home-section::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            /*background: url('@/assets/images/home-pattern.svg') center/cover;*/
            opacity: 0.1;
        }

    .home-content {
        position: relative;
        z-index: 2;
    }

    .home-title {
        font-size: 3.5rem;
        font-weight: 800;
        margin-bottom: 1rem;
        background: linear-gradient(135deg, #ffffff 0%, #f8f9fa 100%);
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        background-clip: text;
    }

    .home-subtitle {
        font-size: 1.25rem;
        opacity: 0.9;
        max-width: 600px;
        margin: 0 auto;
    }

    .news-section {
        padding: 4rem 0;
    }

    .section-header {
        text-align: center;
        margin-bottom: 3rem;
    }

    .section-title {
        font-size: 2.5rem;
        font-weight: 700;
        color: #2c3e50;
        display: inline-flex;
        align-items: center;
        gap: 0.75rem;
        margin-bottom: 1rem;
    }

    .section-link {
        color: inherit;
        text-decoration: none;
        transition: all 0.3s ease;
        position: relative;
    }

        .section-link::after {
            content: '';
            position: absolute;
            bottom: -4px;
            left: 0;
            width: 0;
            height: 3px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            transition: width 0.3s ease;
            border-radius: 2px;
        }

        .section-link:hover {
            color: #667eea;
            text-decoration: none;
        }

            .section-link:hover::after {
                width: 100%;
            }

    .section-divider {
        width: 80px;
        height: 4px;
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        margin: 0 auto;
        border-radius: 2px;
    }

    /* Анимации */
    @keyframes fadeIn {
        from {
            opacity: 0;
            transform: translateY(30px);
        }

        to {
            opacity: 1;
            transform: translateY(0);
        }
    }

    .animate-fade-in {
        animation: fadeIn 0.8s ease-out;
    }

    .animate-fade-in-delayed {
        animation: fadeIn 0.8s ease-out 0.3s both;
    }

    /* Адаптивность */
    @media (max-width: 768px) {
        .home-section {
            padding: 4rem 0 3rem;
        }

        .home-title {
            font-size: 2.5rem;
        }

        .home-subtitle {
            font-size: 1.1rem;
            padding: 0 1rem;
        }

        .section-title {
            font-size: 2rem;
        }

        .news-section {
            padding: 3rem 0;
        }
    }

    @media (max-width: 576px) {
        .home-title {
            font-size: 2rem;
        }

        .section-title {
            font-size: 1.75rem;
        }
    }
</style>