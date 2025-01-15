<template>
    <div class="container mt-5 about-page">
        <h1 class="text-center mb-4">{{ $t('about.title') }}</h1>
        <div class="card shadow-sm border-0">
            <div class="card-body">
                <h2 class="card-title">{{ $t('about.name') }}</h2>
                <p class="card-text">
                    {{ $t('about.description') }}
                </p>

                <h3 class="mt-4">{{ $t('about.professional.title') }}</h3>
                <ul>
                    <li>{{ $t('about.professional.experience') }}</li>
                    <li>{{ $t('about.professional.skills') }}</li>
                    <li>{{ $t('about.professional.currentProjects') }}</li>
                </ul>

                <h3 class="mt-4">{{ $t('about.hobbies.title') }}</h3>
                <p>{{ $t('about.hobbies.description') }}</p>

                <h3 class="mt-4">{{ $t('about.contact.title') }}</h3>
                <p>
                    <a href="https://t.me/aparshukov"
                       class="btn btn-outline-primary d-flex align-items-center"
                       target="_blank"
                       rel="noopener noreferrer">
                        <i class="bi bi-telegram me-2"></i>{{ $t('about.contact.telegram') }}
                    </a>
                </p>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: 'AboutPage',
    });
</script>

<style scoped>
    .about-page h1 {
        color: #303030;
    }

    .about-page .card {
        background-color: #f8f9fa;
    }

    .about-page h2, h3 {
        color: #007bff;
    }

    .bi-telegram {
        font-size: 1.2rem;
        color: #007bff;
    }
</style>
