<template>
    <div class="container py-5">
        <div class="text-center mb-5">
            <h1 class="display-5 fw-bold">{{ $t('home.welcome') }}</h1>
            <p class="text-muted">{{ $t('home.description') }}</p>
        </div>

        <section class="mb-5">
            <h2 class="section-title">🎮 {{ $t('home.myServers') }}</h2>
            <GameServerList />
        </section>

        <section class="mb-5">
            <h2  class="section-title">💼 {{ $t('home.projects') }}</h2>
            <MyProjects/>
        </section>

        <section class="mb-5">
            <h2 class="section-title">📰 {{ $t('home.news') }}</h2>
            <NewsList />
        </section>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue'
    import GameServerList from '@/components/home/GameServerList.vue'
    import NewsList from '@/components/home/NewsList.vue'
    import MyProjects from '@/components/home/MyProjects.vue'

    export default defineComponent({
        components: {
            GameServerList,
            NewsList,
            MyProjects
        }
    })
</script>

<style scoped>
    .section-title {
        font-size: 1.5rem;
        font-weight: 600;
        border-bottom: 2px solid #eee;
        padding-bottom: 0.4rem;
        margin-bottom: 1.5rem;
    }

    @media (max-width: 768px) {
        .section-title {
            font-size: 1.25rem;
        }
    }
</style>
