<template>
    <div class="news-list-wrapper">
        <!-- Error State -->
        <div v-if="error" class="error-state">
            <i class="bi bi-exclamation-triangle"></i>
            <p>{{ error }}</p>
            <button @click="loadArticles" class="btn btn-primary">
                {{ $t('buttons.retry') }}
            </button>
        </div>

        <!-- Articles Grid -->
        <div v-else class="articles-grid">
            <article v-for="article in displayedArticles"
                     :key="article.id || article.placeholderId"
                     class="article-card"
                     :class="{ 'loading': loading }">
                <div class="card-content">
                    <!-- Skeleton Loader -->
                    <template v-if="loading">
                        <div class="skeleton-loader">
                            <div class="skeleton-title"></div>
                            <div class="skeleton-meta"></div>
                            <div class="skeleton-tags"></div>
                            <div class="skeleton-text"></div>
                            <div class="skeleton-text short"></div>
                            <div class="skeleton-button"></div>
                        </div>
                    </template>

                    <!-- Article Content -->
                    <template v-else>
                        <header class="article-header">
                            <h3 class="article-title">{{ article.title }}</h3>
                            <div class="article-meta">
                                <span class="author">
                                    <i class="bi bi-person"></i>
                                    {{ article.createdByUser?.userName || '—' }}
                                </span>
                                <span class="date">
                                    <i class="bi bi-calendar"></i>
                                    {{ article.creationDate ? localeDate(article.creationDate) : '—' }}
                                </span>
                            </div>
                        </header>

                        <div class="article-tags">
                            <span v-if="article.tags.length" class="tags">
                                <i class="bi bi-tags"></i>
                                {{ article.tags.map((tag: any) => tag.title).join(', ') }}
                            </span>
                            <span v-else class="no-tags">
                                {{ $t('articles.noTags') }}
                            </span>
                        </div>

                        <div class="article-excerpt" v-html="article.description"></div>

                        <footer class="article-footer">
                            <router-link :to="{ name: 'ArticlePage', params: { id: article.id } }"
                                         class="read-more-link">
                                {{ $t('buttons.readMore') }}
                                <i class="bi bi-arrow-right"></i>
                            </router-link>
                        </footer>
                    </template>
                </div>
            </article>
        </div>

        <!-- View All Button -->
        <div class="view-all-section">
            <router-link to="/blog" class="view-all-btn">
                <span>{{ $t('home.read_more') }}</span>
                <i class="bi bi-arrow-right"></i>
            </router-link>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { ArticleService } from '@/api/services/ArticleService';
    import { Helper } from '../../lib/helper';

    export default defineComponent({
        name: 'NewsList',
        data() {
            return {
                articles: [] as any[],
                error: null as string | null,
                loading: true,
            };
        },
        computed: {
            displayedArticles(): any {
                if (this.loading) {
                    return Array.from({ length: 3 }, (_, index) => ({
                        placeholderId: `placeholder-${index}`,
                    }));
                }
                return this.articles.slice(0, 3); // Показываем только 3 статьи на главной
            },
        },
        created() {
            this.loadArticles();
        },
        methods: {
            async loadArticles() {
                this.loading = true;
                this.error = null;
                try {
                    const articleService = new ArticleService();
                    const response = await articleService.getArticlesByPageAsync(1, 10);
                    this.articles = response.items || [];
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
    .news-list-wrapper {
        max-width: 1200px;
        margin: 0 auto;
    }

    .articles-grid {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(350px, 1fr));
        gap: 2rem;
        margin-bottom: 3rem;
    }

    .article-card {
        background: white;
        border-radius: 16px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
        transition: all 0.3s ease;
        overflow: hidden;
        border: 1px solid rgba(255, 255, 255, 0.2);
    }

        .article-card:hover {
            transform: translateY(-8px);
            box-shadow: 0 12px 40px rgba(0, 0, 0, 0.15);
        }

    .card-content {
        padding: 2rem;
    }

    .article-header {
        margin-bottom: 1rem;
    }

    .article-title {
        font-size: 1.25rem;
        font-weight: 700;
        color: #2c3e50;
        line-height: 1.4;
        margin-bottom: 0.75rem;
        display: -webkit-box;
        -webkit-line-clamp: 2;
        -webkit-box-orient: vertical;
        overflow: hidden;
    }

    .article-meta {
        display: flex;
        gap: 1rem;
        font-size: 0.875rem;
        color: #6c757d;
    }

        .article-meta span {
            display: flex;
            align-items: center;
            gap: 0.25rem;
        }

    .article-tags {
        margin-bottom: 1rem;
        font-size: 0.875rem;
    }

    .tags, .no-tags {
        color: #6c757d;
        display: flex;
        align-items: center;
        gap: 0.25rem;
    }

    .article-excerpt {
        color: #495057;
        line-height: 1.6;
        margin-bottom: 1.5rem;
        display: -webkit-box;
        -webkit-line-clamp: 3;
        -webkit-box-orient: vertical;
        overflow: hidden;
    }

    .article-footer {
        border-top: 1px solid #e9ecef;
        padding-top: 1rem;
    }

    .read-more-link {
        display: inline-flex;
        align-items: center;
        gap: 0.5rem;
        color: #667eea;
        text-decoration: none;
        font-weight: 600;
        transition: all 0.3s ease;
    }

        .read-more-link:hover {
            color: #764ba2;
            gap: 0.75rem;
        }

    /* Skeleton Loader */
    .skeleton-loader {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }

    .skeleton-title,
    .skeleton-meta,
    .skeleton-tags,
    .skeleton-text,
    .skeleton-button {
        background: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
        background-size: 200% 100%;
        animation: loading 1.5s infinite;
        border-radius: 4px;
    }

    .skeleton-title {
        height: 24px;
        width: 80%;
    }

    .skeleton-meta {
        height: 16px;
        width: 60%;
    }

    .skeleton-tags {
        height: 16px;
        width: 40%;
    }

    .skeleton-text {
        height: 16px;
    }

        .skeleton-text.short {
            width: 70%;
        }

    .skeleton-button {
        height: 36px;
        width: 120px;
        border-radius: 18px;
    }

    @keyframes loading {
        0% {
            background-position: 200% 0;
        }

        100% {
            background-position: -200% 0;
        }
    }

    /* Error State */
    .error-state {
        text-align: center;
        padding: 3rem;
        color: #dc3545;
    }

        .error-state i {
            font-size: 3rem;
            margin-bottom: 1rem;
        }

        .error-state p {
            margin-bottom: 1.5rem;
            font-size: 1.1rem;
        }

    /* View All Button */
    .view-all-section {
        text-align: center;
        margin-top: 2rem;
    }

    .view-all-btn {
        display: inline-flex;
        align-items: center;
        gap: 0.75rem;
        padding: 1rem 2rem;
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        color: white;
        text-decoration: none;
        border-radius: 50px;
        font-weight: 600;
        transition: all 0.3s ease;
        box-shadow: 0 4px 15px rgba(102, 126, 234, 0.3);
    }

        .view-all-btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 8px 25px rgba(102, 126, 234, 0.4);
            color: white;
            gap: 1rem;
        }

    /* Адаптивность */
    @media (max-width: 768px) {
        .articles-grid {
            grid-template-columns: 1fr;
            gap: 1.5rem;
        }

        .card-content {
            padding: 1.5rem;
        }

        .article-meta {
            flex-direction: column;
            gap: 0.5rem;
        }

        .view-all-btn {
            padding: 0.875rem 1.5rem;
        }
    }
</style>