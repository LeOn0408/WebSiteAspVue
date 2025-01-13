<template>
    <div class="container mt-4">
        <div>
            <button class="btn btn-outline-primary mb-3" @click="goBack">
                ← Вернуться назад
            </button>
        </div>
        <div v-if="article" class="card shadow-sm">
            <div class="card-body">
                <h2 class="card-title">{{ article.title }}</h2>
                <p class="card-text text-muted small">
                    <span>от {{ article.createdByUser.userName }}</span> |
                    <span>{{ localeDate(article.creationDate) }}</span>
                </p>
                <div class="mb-3">
                    <span v-for="tag in article.tags" :key="tag.id" class="badge bg-secondary me-1">
                        {{ tag.title }}
                    </span>
                </div>
                <p class="card-text" v-html="article.description"></p>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { Article } from '@/lib/entity/article'; // Импорт модели

    export default defineComponent({
        props: {
            id: {
                type: String,
                required: true,
            },
        },
        data() {
            return {
                article: null as any,
            };
        },
        async created() {
            const articleService = new Article();
            this.article = await articleService.getByIdAsync(this.id); // Получение статьи по ID
        },
        methods: {
            localeDate(date: string) {
                const options = { year: 'numeric', month: 'long', day: 'numeric' };
                return new Date(date).toLocaleDateString('ru-RU', options);
            },
            goBack() {
                this.$router.go(-1); // Возврат на предыдущую страницу
            },
        },
    });
</script>
