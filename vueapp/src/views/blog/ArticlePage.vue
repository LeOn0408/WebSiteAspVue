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

                <p class="card-text" v-html="article.description"></p>


                <div>
                    <span class="fw-bold">{{ $t('articles.tags') }}: </span>
                    <a href="#" class="badge bg-secondary me-1" v-for="tag in article.tags" :key="tag.id">{{ tag.title }}</a>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { ArticleService } from '@/api/services/ArticleService'; 
    import { Helper } from '@/lib/helper';

    export default defineComponent({
        props: {
            id: {
                type: Number,
                required: true,
            },
        },
        data() {
            return {
                article: null as any,
            };
        },
        async created() {
            const articleService = new ArticleService();
            this.article = await articleService.getByIdAsync(this.id); // Получение статьи по ID
        },
        methods: {
            localeDate(date: string) {
                return Helper.FormatDate(date);
            },
            goBack() {
                this.$router.go(-1); // Возврат на предыдущую страницу
            },
        },
    });
</script>
