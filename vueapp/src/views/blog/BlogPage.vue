<template>
    <div class="blog-page">
        <!-- home Section -->
        <section class="blog-home">
            <div class="container">
                <div class="home-content text-center">
                    <h1 class="home-title">Блог</h1>
                    <p class="home-subtitle">Последние новости и статьи</p>
                </div>
            </div>
        </section>

        <!-- Content Section -->
        <section class="blog-content">
            <div class="container">

                <!--TODO: реализовать и включить-->
                <!-- Filter Tabs -->
                <!--<div class="filter-tabs">
                    <button class="filter-tab active">
                        {{ $t('tabs.all') }}
                    </button>-->
                    <!-- Можно добавить дополнительные фильтры -->
                <!--</div>-->

                <!-- Error State -->
                <div v-if="error" class="error-state">
                    <div class="error-icon">
                        <i class="bi bi-exclamation-circle"></i>
                    </div>
                    <h3>Произошла ошибка</h3>
                    <p>{{ error }}</p>
                    <button @click="loadArticles" class="retry-btn">
                        Попробовать снова
                    </button>
                </div>

                <!-- Articles Grid -->
                <div v-else class="articles-grid">
                    <article v-for="article in displayedArticles"
                             :key="article.id || article.placeholderId"
                             class="article-card"
                             :class="{ 'skeleton': loading }">
                        <div class="card-content">
                            <!-- Skeleton Loader -->
                            <template v-if="loading">
                                <div class="skeleton-loader">
                                    <div class="skeleton-image"></div>
                                    <div class="skeleton-content">
                                        <div class="skeleton-title"></div>
                                        <div class="skeleton-meta"></div>
                                        <div class="skeleton-tags"></div>
                                        <div class="skeleton-text"></div>
                                        <div class="skeleton-text short"></div>
                                        <div class="skeleton-button"></div>
                                    </div>
                                </div>
                            </template>

                            <!-- Article Content -->
                            <template v-else>
                                <div class="article-image">
                                    <img :src="getArticleImage(article)" :alt="article.title" />
                                    <div class="article-overlay"></div>
                                </div>

                                <div class="article-body">
                                    <header class="article-header">
                                        <h3 class="article-title">{{ article.title }}</h3>
                                        <div class="article-meta">
                                            <div class="meta-item">
                                                <i class="bi bi-person"></i>
                                                <span>{{ article.createdByUser?.userName || '—' }}</span>
                                            </div>
                                            <div class="meta-item">
                                                <i class="bi bi-calendar"></i>
                                                <span>{{ article.creationDate ? localeDate(article.creationDate) : '—' }}</span>
                                            </div>
                                        </div>
                                    </header>

                                    <div class="article-tags">
                                        <span v-for="tag in article.tags.slice(0, 3)"
                                              :key="tag.id"
                                              class="tag">
                                            {{ tag.title }}
                                        </span>
                                        <span v-if="article.tags.length > 3" class="tag-more">
                                            +{{ article.tags.length - 3 }}
                                        </span>
                                    </div>

                                    <div class="article-excerpt" v-html="truncateText(article.description, 150)"></div>

                                    <footer class="article-footer">
                                        <router-link :to="{ name: 'ArticlePage', params: { id: article.id } }"
                                                     class="read-more-link">
                                            <span>{{ $t('buttons.readMore') }}</span>
                                            <i class="bi bi-arrow-right"></i>
                                        </router-link>
                                    </footer>
                                </div>
                            </template>
                        </div>
                    </article>
                </div>

                <!-- Pagination -->
                <div class="pagination-wrapper" v-if="!loading && totalPages > 1">
                    <div class="pagination">
                        <button class="pagination-btn prev"
                                @click="changePage(currentPage - 1)"
                                :disabled="currentPage === 1">
                            <i class="bi bi-chevron-left"></i>
                            {{ $t('pagination.prev') }}
                        </button>

                        <div class="pagination-pages">
                            <button v-for="page in visiblePages"
                                    :key="page"
                                    class="page-number"
                                    :class="{ active: page === currentPage }"
                                    @click="changePage(page)">
                                {{ page }}
                            </button>
                            <span class="page-ellipsis" v-if="showEndEllipsis">...</span>
                        </div>

                        <button class="pagination-btn next"
                                @click="changePage(currentPage + 1)"
                                :disabled="currentPage === totalPages">
                            {{ $t('pagination.next') }}
                            <i class="bi bi-chevron-right"></i>
                        </button>
                    </div>

                    <div class="pagination-info">
                        Страница {{ currentPage }} из {{ totalPages }}
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { ArticleService } from '@/api/services/ArticleService';
    import { Helper } from '../../lib/helper';
    import Plug from '@/assets/images/main/img.png';

    export default defineComponent({
        name: 'BlogPage',
        data() {
            return {
                articles: [] as any[],
                currentPage: 1,
                pageSize: 9,
                totalPages: 0,
                error: null as string | null,
                loading: true,
            };
        },
        computed: {
            displayedArticles() {
                if (this.loading) {
                    return Array.from({ length: this.pageSize }, (_, index) => ({
                        placeholderId: `placeholder-${index}`,
                    }));
                }
                return this.articles;
            },
            visiblePages(): number[] {
                const pages = [];
                const start = Math.max(1, this.currentPage - 2);
                const end = Math.min(this.totalPages, start + 4);

                for (let i = start; i <= end; i++) {
                    pages.push(i);
                }
                return pages;
            },
            showEndEllipsis(): boolean {
                return this.currentPage + 2 < this.totalPages;
            }
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
                    const response = await articleService.getArticlesByPageAsync(this.currentPage, this.pageSize);
                    this.articles = response.items || [];
                    this.totalPages = Math.ceil(response.totalCount / this.pageSize);
                } catch (error: any) {
                    this.error = error.message || this.$t('errors.default');
                } finally {
                    this.loading = false;
                }
            },
            localeDate(date: string) {
                return Helper.FormatDate(date);
            },
            changePage(page: number) {
                if (page < 1 || page > this.totalPages) return;
                this.currentPage = page;
                this.loadArticles();
                window.scrollTo({ top: 0, behavior: 'smooth' });
            },
            getArticleImage(article: any): string {
                // Заглушка для изображений. TODO:прикрепить из базы и конвертировать в web
                return Plug;
            },
            truncateText(text: string, length: number): string {
                if (!text) return '';
                const div = document.createElement('div');
                div.innerHTML = text;
                const plainText = div.textContent || div.innerText || '';
                return plainText.length > length ? plainText.substring(0, length) + '...' : plainText;
            }
        },
    });
</script>

<style scoped>
    .blog-page {
        min-height: 100vh;
        background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
    }

    .blog-home {
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        color: white;
        padding: 4rem 0;
        text-align: center;
        position: relative;
        overflow: hidden;
    }

        .blog-home::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            /*background: url('@/assets/images/pattern.svg') center/cover;*/
            opacity: 0.1;
        }

    .home-content {
        position: relative;
        z-index: 2;
    }

    .home-title {
        font-size: 3rem;
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
        font-weight: 300;
    }

    .blog-content {
        padding: 4rem 0;
    }

    .filter-tabs {
        display: flex;
        gap: 0.5rem;
        margin-bottom: 3rem;
        justify-content: center;
        flex-wrap: wrap;
    }

    .filter-tab {
        padding: 0.75rem 1.5rem;
        border: none;
        background: white;
        border-radius: 25px;
        font-weight: 500;
        color: #6c757d;
        cursor: pointer;
        transition: all 0.3s ease;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    }

        .filter-tab:hover {
            color: #667eea;
            transform: translateY(-2px);
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.15);
        }

        .filter-tab.active {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
        }

    .articles-grid {
        display: grid;
        grid-template-columns: repeat(auto-fill, minmax(350px, 1fr));
        gap: 2rem;
        margin-bottom: 4rem;
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
        height: 100%;
        display: flex;
        flex-direction: column;
    }

    .article-image {
        position: relative;
        height: 200px;
        overflow: hidden;
    }

        .article-image img {
            width: 100%;
            height: 100%;
            object-fit: cover;
            transition: transform 0.3s ease;
        }

    .article-card:hover .article-image img {
        transform: scale(1.05);
    }

    .article-overlay {
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background: linear-gradient(to bottom, transparent 0%, rgba(0,0,0,0.1) 100%);
    }

    .article-body {
        padding: 1.5rem;
        flex-grow: 1;
        display: flex;
        flex-direction: column;
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

    .meta-item {
        display: flex;
        align-items: center;
        gap: 0.25rem;
    }

    .article-tags {
        display: flex;
        flex-wrap: wrap;
        gap: 0.5rem;
        margin-bottom: 1rem;
    }

    .tag {
        background: rgba(102, 126, 234, 0.1);
        color: #667eea;
        padding: 0.25rem 0.75rem;
        border-radius: 12px;
        font-size: 0.75rem;
        font-weight: 500;
    }

    .tag-more {
        background: rgba(108, 117, 125, 0.1);
        color: #6c757d;
        padding: 0.25rem 0.75rem;
        border-radius: 12px;
        font-size: 0.75rem;
    }

    .article-excerpt {
        color: #495057;
        line-height: 1.6;
        margin-bottom: 1.5rem;
        flex-grow: 1;
        display: -webkit-box;
        -webkit-line-clamp: 3;
        -webkit-box-orient: vertical;
        overflow: hidden;
    }

    .article-footer {
        margin-top: auto;
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
        height: 100%;
    }

    .skeleton-image {
        height: 200px;
        background: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
        background-size: 200% 100%;
        animation: loading 1.5s infinite;
    }

    .skeleton-content {
        padding: 1.5rem;
        flex-grow: 1;
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
        height: 24px;
        width: 70%;
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
        margin-top: auto;
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
        padding: 4rem 2rem;
        background: white;
        border-radius: 16px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
    }

    .error-icon {
        font-size: 4rem;
        color: #dc3545;
        margin-bottom: 1.5rem;
    }

    .error-state h3 {
        color: #2c3e50;
        margin-bottom: 1rem;
    }

    .error-state p {
        color: #6c757d;
        margin-bottom: 2rem;
    }

    .retry-btn {
        padding: 0.75rem 2rem;
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        color: white;
        border: none;
        border-radius: 25px;
        font-weight: 600;
        cursor: pointer;
        transition: all 0.3s ease;
    }

        .retry-btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(102, 126, 234, 0.3);
        }

    /* Pagination */
    .pagination-wrapper {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 1rem;
    }

    .pagination {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        background: white;
        padding: 1rem;
        border-radius: 16px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
    }

    .pagination-btn {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        padding: 0.75rem 1.25rem;
        border: 1px solid #e9ecef;
        background: white;
        border-radius: 12px;
        cursor: pointer;
        transition: all 0.3s ease;
        font-weight: 500;
    }

        .pagination-btn:not(:disabled):hover {
            background: #667eea;
            color: white;
            border-color: #667eea;
        }

        .pagination-btn:disabled {
            opacity: 0.5;
            cursor: not-allowed;
        }

    .pagination-pages {
        display: flex;
        gap: 0.25rem;
    }

    .page-number {
        padding: 0.75rem 1rem;
        border: 1px solid #e9ecef;
        background: white;
        border-radius: 8px;
        cursor: pointer;
        transition: all 0.3s ease;
        min-width: 45px;
        font-weight: 500;
    }

        .page-number:hover {
            border-color: #667eea;
            color: #667eea;
        }

        .page-number.active {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            border-color: transparent;
        }

    .page-ellipsis {
        padding: 0.75rem 0.5rem;
        color: #6c757d;
    }

    .pagination-info {
        color: #6c757d;
        font-size: 0.875rem;
    }

    /* Адаптивность */
    @media (max-width: 768px) {
        .blog-home {
            padding: 3rem 0;
        }

        .home-title {
            font-size: 2.5rem;
        }

        .blog-content {
            padding: 3rem 0;
        }

        .articles-grid {
            grid-template-columns: 1fr;
            gap: 1.5rem;
        }

        .pagination {
            flex-wrap: wrap;
            justify-content: center;
        }

        .pagination-pages {
            order: 3;
            width: 100%;
            justify-content: center;
            margin-top: 1rem;
        }
    }

    @media (max-width: 480px) {
        .home-title {
            font-size: 2rem;
        }

        .home-subtitle {
            font-size: 1.1rem;
        }

        .filter-tabs {
            justify-content: flex-start;
            overflow-x: auto;
            padding-bottom: 0.5rem;
        }
    }
</style>