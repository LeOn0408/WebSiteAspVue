<template>
    <footer class="footer">
        <div class="container-fluid py-4">
            <div class="row align-items-center">
                <!-- Левая часть -->
                <div class="col-md-6 text-center text-md-start mb-3 mb-md-0">
                    <span class="footer-text">© 2023. <a href="https://aparshukov.ru" target="_blank" class="footer-link">aparshukov.ru</a></span>
                </div>
                <!-- Правая часть -->
                <div class="col-md-6 text-center text-md-end">
                    <select class="form-select form-select-sm d-inline-block w-auto me-3" id="language-select" @change="onChangeLang" v-model="preferredLocale">
                        <option value="ru">Русский</option>
                        <option value="en">English</option>
                    </select>
                    <!--<a href="#" class="footer-icon">
                        <i class="bi bi-facebook"></i>
                    </a>
                    <a href="#" class="footer-icon">
                        <i class="bi bi-twitter"></i>
                    </a>-->
                    <a href="#" class="footer-icon">
                        <i class="bi bi-github"></i>
                    </a>
                </div>
            </div>
        </div>
    </footer>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { mapState } from 'vuex';

    export default defineComponent({
        computed: mapState(['preferredLocale']),
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
        background: linear-gradient(45deg, #2c3e50, #34495e);
        color: #ecf0f1;
        font-size: 0.875rem;
        box-shadow: 0 -1px 5px rgba(0, 0, 0, 0.1);
    }

    .footer a {
        color: #1abc9c;
        text-decoration: none;
        transition: color 0.2s ease-in-out;
    }

    .footer a:hover {
        color: #16a085;
    }

    .footer-text {
        font-weight: 500;
    }

    .footer-icon {
        color: #ecf0f1;
        margin-left: 10px;
        font-size: 1.2rem;
        transition: color 0.2s ease-in-out;
    }

        .footer-icon:hover {
            color: #1abc9c;
        }

    #language-select {
        background-color: #2c3e50;
        color: #ecf0f1;
        border: 1px solid #34495e;
        transition: all 0.2s ease-in-out;
    }

    #language-select:focus {
        outline: none;
        border-color: #1abc9c;
        box-shadow: 0 0 5px rgba(26, 188, 156, 0.5);
    }

    @media (max-width: 768px) {
        .footer-text {
            font-size: 0.8rem;
        }

        .footer-icon {
            font-size: 1rem;
        }
    }
</style>
