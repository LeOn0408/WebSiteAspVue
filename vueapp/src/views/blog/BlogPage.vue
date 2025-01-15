<template>
    <div class="container mt-4">

        <!-- Верхняя панель с разделами -->
        <ul class="nav nav-tabs mb-3">
            <li class="nav-article">
                <a class="nav-link active" href="#">{{ $t('tabs.all') }}</a>
            </li>
        </ul>

        <div v-if="error" class="alert alert-danger" role="alert">
            {{ error }}
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div v-for="article in displayedArticles" :key="article.id || article.placeholderId" class="card mb-3 shadow-sm article-card">
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
                            <div class="mb-3 text-muted">
                                <span v-if="article.tags.length">
                                    {{ article.tags.map((tag: any) => tag.title).join(', ') }}
                                </span>
                                <span v-else>{{ $t('articles.noTags') }}</span>
                            </div>
                            <p class="card-text" v-html="article.description"></p>

                            <router-link :to="{ name: 'ArticlePage', params: { id: article.id } }"
                                         class="btn btn-outline-primary btn-sm mt-3">
                                {{ $t('buttons.readMore') }}
                            </router-link>
                        </template>
                    </div>
                </div>
            </div>
        </div>

        <!-- Постраничная навигация -->
        <nav class="mt-4">
            <ul class="pagination justify-content-center">
                <li class="page-article" :class="{ disabled: currentPage === 1 }">
                    <button class="page-link" @click="changePage(currentPage - 1)" :disabled="currentPage === 1">
                        {{ $t('pagination.prev') }}
                    </button>
                </li>
                <li class="page-article" v-for="page in totalPages" :key="page" :class="{ active: page === currentPage }">
                    <button class="page-link" @click="changePage(page)">{{ page }}</button>
                </li>
                <li class="page-article" :class="{ disabled: currentPage === totalPages }">
                    <button class="page-link" @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">
                        {{ $t('pagination.next') }}
                    </button>
                </li>
            </ul>
        </nav>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { ArticleService } from '@/api/services/ArticleService';
    import { Helper } from '../../lib/helper';

    export default defineComponent({
        data() {
            return {
                articles: [] as any[], // Загруженные статьи
                currentPage: 1,
                pageSize: 10,
                totalPages: 0,
                error: null,
                loading: true, // Состояние загрузки
            };
        },
        computed: {
            displayedArticles() {
                if (this.loading) {
                    // Возвращаем массив заглушек, пока идет загрузка
                    return Array.from({ length: this.pageSize }, (_, index) => ({
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
                this.loading = true; // Включаем индикатор загрузки
                try {
                    const articleService = new ArticleService();
                    const response = await articleService.getArticlesByPageAsync(this.currentPage, this.pageSize);
                    this.articles = response.items || [];
                    this.totalPages = Math.ceil(response.totalCount / this.pageSize);
                    this.error = null;
                } catch (error: any) {
                    this.error = error.message || this.$t('errors.default');
                } finally {
                    this.loading = false; // Выключаем индикатор загрузки
                }
            },
            localeDate(date: string) {
                return Helper.FormatDate(date);
            },
            changePage(page: number) {
                if (page < 1 || page > this.totalPages) return;
                this.currentPage = page;
                this.loadArticles();
            },
        },
    });
</script>

<style>
    .article-card {
        transition: box-shadow 0.3s ease;
    }

        .article-card:hover {
            box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.2);
        }
</style>
