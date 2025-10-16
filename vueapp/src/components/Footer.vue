<template>
    <footer class="footer">
        <div class="footer-container">
            <div class="footer-content">
                <!-- Левая часть -->
                <div class="footer-section">
                    <span class="footer-text">
                        © {{ currentYear }}.
                        <a href="https://aparshukov.ru" target="_blank" class="footer-link">
                            aparshukov.ru
                        </a>
                    </span>
                    <div class="footer-meta">
                        
                    </div>
                </div>

                <!-- Правая часть -->
                <div class="footer-section">
                    <div class="footer-controls">
                        <!-- Language Selector -->
                        <div class="language-selector">
                            <i class="bi bi-translate"></i>
                            <select class="language-select"
                                    @change="onChangeLang"
                                    v-model="preferredLocale">
                                <option value="ru">Русский</option>
                                <option value="en">English</option>
                            </select>
                            <i class="bi bi-chevron-down"></i>
                        </div>

                        <!-- Social Links -->
                        <a href="https://github.com/LeOn0408"
                           target="_blank"
                           class="social-link"
                           aria-label="GitHub">
                            <i class="bi bi-github"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </footer>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { mapState } from 'vuex';

    export default defineComponent({
        name: 'AppFooter',
        computed: {
            ...mapState(['preferredLocale']),
            currentYear(): number {
                return new Date().getFullYear();
            }
        },
        methods: {
            onChangeLang(event: Event) {
                const value = (event.target as HTMLSelectElement).value;
                localStorage.setItem('userLocale', value);
                location.reload();
            },
        },
    });
</script>

<style scoped>
    .footer {
        background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 50%, #f8f9fa 100%);
        color: #2c3e50;
        border-top: 1px solid rgba(0, 0, 0, 0.1);
        position: relative;
        overflow: hidden;
    }

        .footer::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: radial-gradient(circle at 20% 80%, rgba(26, 188, 156, 0.05) 0%, transparent 50%), radial-gradient(circle at 80% 20%, rgba(52, 152, 219, 0.05) 0%, transparent 50%);
            pointer-events: none;
        }

    .footer-container {
        max-width: 1200px;
        margin: 0 auto;
        padding: 0 1.5rem;
    }

    .footer-content {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 2rem 0;
        position: relative;
        z-index: 1;
    }

    .footer-section {
        display: flex;
        flex-direction: column;
        gap: 0.5rem;
    }

    .footer-text {
        font-size: 1rem;
        font-weight: 600;
        color: #2c3e50;
    }

    .footer-link {
        color: #667eea;
        text-decoration: none;
        font-weight: 700;
        transition: all 0.3s ease;
        position: relative;
    }

        .footer-link::after {
            content: '';
            position: absolute;
            bottom: -2px;
            left: 0;
            width: 0;
            height: 2px;
            background: #667eea;
            transition: width 0.3s ease;
            border-radius: 1px;
        }

        .footer-link:hover {
            color: #764ba2;
        }

            .footer-link:hover::after {
                width: 100%;
            }

    .footer-meta {
        font-size: 0.875rem;
        color: #6c757d;
        display: flex;
        align-items: center;
        gap: 0.25rem;
    }

        .footer-meta .bi-heart-fill {
            color: #e74c3c;
            font-size: 0.75rem;
        }

    .footer-controls {
        display: flex;
        align-items: center;
        gap: 1.5rem;
    }

    /* Language Selector */
    .language-selector {
        position: relative;
        display: flex;
        align-items: center;
        gap: 0.5rem;
        background: rgba(255, 255, 255, 0.8);
        backdrop-filter: blur(10px);
        border: 1px solid rgba(0, 0, 0, 0.1);
        border-radius: 12px;
        padding: 0.5rem 1rem;
        transition: all 0.3s ease;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
    }

        .language-selector:hover {
            background: rgba(255, 255, 255, 0.9);
            border-color: rgba(0, 0, 0, 0.2);
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
        }

        .language-selector .bi-translate {
            color: #667eea;
            font-size: 1rem;
        }

        .language-selector .bi-chevron-down {
            color: #6c757d;
            font-size: 0.875rem;
        }

    .language-select {
        background: transparent;
        border: none;
        color: #2c3e50;
        font-size: 0.875rem;
        font-weight: 600;
        cursor: pointer;
        appearance: none;
        padding: 0.25rem 0.5rem;
        min-width: 100px;
    }

        .language-select:focus {
            outline: none;
        }

        .language-select option {
            background: white;
            color: #2c3e50;
            border: none;
        }

    /* Social Links */
    .social-link {
        display: flex;
        align-items: center;
        justify-content: center;
        width: 44px;
        height: 44px;
        background: rgba(255, 255, 255, 0.8);
        backdrop-filter: blur(10px);
        border: 1px solid rgba(0, 0, 0, 0.1);
        border-radius: 12px;
        color: #2c3e50;
        text-decoration: none;
        transition: all 0.3s ease;
        position: relative;
        overflow: hidden;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
    }

        .social-link::before {
            content: '';
            position: absolute;
            top: 0;
            left: -100%;
            width: 100%;
            height: 100%;
            background: linear-gradient(90deg, transparent, rgba(102, 126, 234, 0.1), transparent);
            transition: left 0.5s ease;
        }

        .social-link:hover::before {
            left: 100%;
        }

        .social-link:hover {
            background: rgba(255, 255, 255, 0.9);
            border-color: rgba(102, 126, 234, 0.3);
            transform: translateY(-2px);
            box-shadow: 0 6px 16px rgba(0, 0, 0, 0.15);
        }

        .social-link .bi-github {
            font-size: 1.25rem;
            color: #2c3e50;
            transition: color 0.3s ease;
        }

        .social-link:hover .bi-github {
            color: #667eea;
        }

    /* Адаптивность */
    @media (max-width: 768px) {
        .footer-content {
            flex-direction: column;
            gap: 1.5rem;
            text-align: center;
            padding: 1.5rem 0;
        }

        .footer-section {
            align-items: center;
        }

        .footer-controls {
            flex-direction: column;
            gap: 1rem;
        }

        .language-selector {
            padding: 0.75rem 1rem;
        }

        .social-link {
            width: 52px;
            height: 52px;
        }

            .social-link .bi-github {
                font-size: 1.5rem;
            }
    }

    @media (max-width: 480px) {
        .footer-container {
            padding: 0 1rem;
        }

        .footer-text {
            font-size: 0.9rem;
        }

        .footer-meta {
            font-size: 0.8rem;
        }

        .language-select {
            min-width: 80px;
            font-size: 0.8rem;
        }
    }

    /* Анимации */
    @keyframes fadeInUp {
        from {
            opacity: 0;
            transform: translateY(20px);
        }

        to {
            opacity: 1;
            transform: translateY(0);
        }
    }

    .footer-content {
        animation: fadeInUp 0.6s ease-out;
    }

    /* Улучшенная доступность */
    @media (prefers-reduced-motion: reduce) {
        .footer-link::after,
        .social-link,
        .language-selector {
            transition: none;
        }

            .social-link::before {
                display: none;
            }

        .footer-content {
            animation: none;
        }
    }

    /* Фокус-стили для доступности */
    .footer-link:focus,
    .language-select:focus,
    .social-link:focus {
        outline: 2px solid #667eea;
        outline-offset: 2px;
        border-radius: 4px;
    }

    /* Контрастные цвета для лучшей читаемости */
    .footer-text,
    .footer-link,
    .language-select,
    .social-link .bi-github {
        color: #2c3e50;
    }

    .footer-meta {
        color: #6c757d;
    }
</style>