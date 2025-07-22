<template>
    <div class="home-wrapper container mt-5">
        <!-- Новости -->
        <div v-if="error" class="alert alert-danger" role="alert">
            {{ error }}
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div v-for="article in displayedArticles" :key="article.id || article.placeholderId"
                     class="card mb-4 shadow article-card border-0">
                    <div class="card-body">
                        <template v-if="loading">
                            <h5 class="card-title placeholder-glow">
                                <span class="placeholder col-6"></span>
                            </h5>
                            <p class="card-text text-muted small placeholder-glow">
                                <span class="placeholder col-4"></span> |
                                <span class="placeholder col-3"></span>
                            </p>
                            <div class="mb-3 placeholder-glow">
                                <span class="placeholder col-3 me-1"></span>
                                <span class="placeholder col-2 me-1"></span>
                            </div>
                            <p class="card-text placeholder-glow">
                                <span class="placeholder col-12"></span>
                                <span class="placeholder col-10"></span>
                            </p>
                        </template>
                        <template v-else>
                            <h5 class="card-title">{{ article.title }}</h5>
                            <p class="card-text text-muted small">
                                <span>{{ article.createdByUser?.userName || '—' }}</span> |
                                <span>{{ article.creationDate ? localeDate(article.creationDate) : '—' }}</span>
                            </p>
                            <div class="mb-2 text-muted">
                                <span v-if="article.tags.length">
                                    {{ article.tags.map((tag: any) => tag.title).join(', ') }}
                                </span>
                                <span v-else>{{ $t('articles.noTags') }}</span>
                            </div>
                            <p class="card-text" v-html="article.description"></p>

                            <router-link :to="{ name: 'ArticlePage', params: { id: article.id } }"
                                         class="btn btn-sm btn-outline-primary mt-3">
                                {{ $t('buttons.readMore') }}
                            </router-link>
                        </template>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script lang="ts">
    import { defineComponent } from 'vue';
    import { ArticleService } from '@/api/services/ArticleService';
    import { Helper } from '../../lib/helper';

    export default defineComponent({
        data() {
            return {
                articles: [] as any[],
                error: null,
                loading: true,
            };
        },
        computed: {
            displayedArticles() : any {
                if (this.loading) {
                    // Возвращаем массив заглушек, пока идет загрузка
                    return Array.from({ length: 1 }, (_, index) => ({
                        placeholderId: `placeholder-${index}`,
                    }));
                }
                return this.articles;
            },
        },
        created() {
            this.loadArticles();
        },
        methods: {
            async loadArticles() {
                this.loading = true;
                try {
                    const articleService = new ArticleService();
                    const response = await articleService.getArticlesByPageAsync(1, 10); // 1-я страница, 10 новостей
                    this.articles = response.items || [];
                    this.error = null;
                } catch (error: any) {
                    this.error = error.message || this.$t('errors.default');
                } finally {
                    this.loading = false;
                }
            },
            localeDate(date: string) {
                return Helper.FormatDate(date);
            },
        },
    });
</script>

<style scoped>
    .home-wrapper {
        background: #f8f9fa;
        border-radius: 0.5rem;
        padding: 2rem;
        box-shadow: 0 5px 20px rgba(0, 0, 0, 0.15);
    }

    .article-card {
        border-bottom-left-radius: 0;
        border-bottom-right-radius: 0;
        transition: box-shadow 0.3s ease;
    }

        .article-card:hover {
            box-shadow: 0 6px 16px rgba(0, 0, 0, 0.25);
        }

    .section-header h2 {
        font-size: 1.8rem;
        margin-bottom: 0.5rem;
    }
</style>

