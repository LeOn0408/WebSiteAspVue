<template>
    <div class="article-page">
        <!-- Back Button -->
        <div class="container">
            <button class="back-btn" @click="goBack">
                <i class="bi bi-arrow-left"></i>
                <span>Вернуться к статьям</span>
            </button>
        </div>

        <!-- Article Content -->
        <article class="article-main" v-if="article">
            <div class="container">
                <div class="article-header">
                    <div class="article-meta">
                        <div class="meta-item">
                            <img :src="getUserAvatar(article.createdByUser)" :alt="article.createdByUser.userName" class="author-avatar">
                            <div class="author-info">
                                <span class="author-name">{{ article.createdByUser.userName }}</span>
                                <span class="publish-date">{{ localeDate(article.creationDate) }}</span>
                            </div>
                        </div>
                        <div class="reading-time">
                            <i class="bi bi-clock"></i>
                            <span>{{ estimateReadingTime(article.description) }} мин чтения</span>
                        </div>
                    </div>

                    <h1 class="article-title">{{ article.title }}</h1>

                    <div class="article-tags">
                        <span v-for="tag in article.tags"
                              :key="tag.id"
                              class="tag">
                            {{ tag.title }}
                        </span>
                    </div>
                </div>

                <div class="article-image">
                    <img :src="getArticleImage(article)" :alt="article.title" />
                </div>

                <div class="article-content">
                    <div class="content-wrapper" v-html="article.description"></div>
                </div>

                <div class="article-footer">
                    <div class="footer-actions">
                        <button class="action-btn" @click="shareArticle">
                            <i class="bi bi-share"></i>
                            <span>Поделиться</span>
                        </button>
                        <button class="action-btn" @click="toggleLike">
                            <i class="bi bi-heart" :class="{ 'liked': isLiked }"></i>
                            <span>{{ likeCount }}</span>
                        </button>
                    </div>

                    <!--TODO: реализовать смену статьи-->
                    <!--<div class="article-navigation">
                        <router-link v-if="previousArticle" :to="{ name: 'ArticlePage', params: { id: previousArticle.id } }" class="nav-link prev">
                            <i class="bi bi-chevron-left"></i>
                            <div class="nav-content">
                                <span class="nav-label">Предыдущая</span>
                                <span class="nav-title">{{ previousArticle.title }}</span>
                            </div>
                        </router-link>

                        <router-link v-if="nextArticle" :to="{ name: 'ArticlePage', params: { id: nextArticle.id } }" class="nav-link next">
                            <div class="nav-content">
                                <span class="nav-label">Следующая</span>
                                <span class="nav-title">{{ nextArticle.title }}</span>
                            </div>
                            <i class="bi bi-chevron-right"></i>
                        </router-link>
                    </div>-->
                </div>
            </div>
        </article>

        <!-- Loading State -->
        <div v-else class="loading-state">
            <div class="container">
                <div class="skeleton-article">
                    <div class="skeleton-header">
                        <div class="skeleton-meta"></div>
                        <div class="skeleton-title"></div>
                        <div class="skeleton-tags"></div>
                    </div>
                    <div class="skeleton-image"></div>
                    <div class="skeleton-content">
                        <div class="skeleton-text"></div>
                        <div class="skeleton-text"></div>
                        <div class="skeleton-text short"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { ArticleService } from '@/api/services/ArticleService';
    import { Helper } from '@/lib/helper';
    import Plug from '@/assets/images/main/img.png';

    export default defineComponent({
        name: 'ArticlePage',
        props: {
            id: {
                type: Number,
                required: true,
            },
        },
        data() {
            return {
                article: null as any,
                previousArticle: null as any,
                nextArticle: null as any,
                isLiked: false,
                likeCount: 0,
            };
        },
        async created() {
            await this.loadArticle();
            await this.loadNavigation();
        },
        methods: {
            async loadArticle() {
                const articleService = new ArticleService();
                this.article = await articleService.getByIdAsync(this.id);
                // Заглушка для лайков
                this.likeCount = Math.floor(Math.random() * 50) + 10;
            },
            async loadNavigation() {
                // Заглушка для навигации - в реальном приложении нужно загружать соседние статьи
                const articleService = new ArticleService();
                const response = await articleService.getArticlesByPageAsync(1, 10);
                const articles = response.items || [];
                const currentIndex = articles.findIndex((a: any) => a.id === this.id);

                if (currentIndex > 0) {
                    this.previousArticle = articles[currentIndex - 1];
                }
                if (currentIndex < articles.length - 1) {
                    this.nextArticle = articles[currentIndex + 1];
                }
            },
            localeDate(date: string) {
                return Helper.FormatDate(date);
            },
            goBack() {
                this.$router.go(-1);
            },
            getUserAvatar(user: any): string {
                return `https://ui-avatars.com/api/?name=${user.userName}&background=667eea&color=fff&size=64`;
            },
            getArticleImage(article: any): string {
                // Заглушка для изображений. TODO:прикрепить из базы и конвертировать в web
                return Plug;
            },
            estimateReadingTime(content: string): number {
                const wordsPerMinute = 200;
                const text = content.replace(/<[^>]*>/g, '');
                const wordCount = text.split(/\s+/).length;
                return Math.ceil(wordCount / wordsPerMinute);
            },
            shareArticle() {
                if (navigator.share) {
                    navigator.share({
                        title: this.article.title,
                        text: this.article.description.replace(/<[^>]*>/g, '').substring(0, 100),
                        url: window.location.href,
                    });
                } else {
                    navigator.clipboard.writeText(window.location.href);
                    // Показать уведомление о копировании
                    alert('Ссылка скопирована в буфер обмена!');
                }
            },
            toggleLike() {
                this.isLiked = !this.isLiked;
                this.likeCount += this.isLiked ? 1 : -1;
            }
        },
    });
</script>

<style scoped>
    .article-page {
        min-height: 100vh;
        background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
        padding-bottom: 4rem;
    }

    .back-btn {
        display: inline-flex;
        align-items: center;
        gap: 0.5rem;
        padding: 1rem 0;
        background: none;
        border: none;
        color: #667eea;
        font-weight: 600;
        cursor: pointer;
        transition: all 0.3s ease;
        margin-bottom: 1rem;
    }

        .back-btn:hover {
            gap: 0.75rem;
            color: #764ba2;
        }

    .article-main {
        background: white;
        border-radius: 20px;
        box-shadow: 0 10px 40px rgba(0, 0, 0, 0.1);
        overflow: hidden;
    }

    .article-header {
        padding: 3rem 2rem 2rem;
        border-bottom: 1px solid #e9ecef;
    }

    .article-meta {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 2rem;
        flex-wrap: wrap;
        gap: 1rem;
    }

    .meta-item {
        display: flex;
        align-items: center;
        gap: 1rem;
    }

    .author-avatar {
        width: 50px;
        height: 50px;
        border-radius: 50%;
        object-fit: cover;
    }

    .author-info {
        display: flex;
        flex-direction: column;
    }

    .author-name {
        font-weight: 600;
        color: #2c3e50;
    }

    .publish-date {
        color: #6c757d;
        font-size: 0.875rem;
    }

    .reading-time {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        color: #6c757d;
        font-size: 0.875rem;
    }

    .article-title {
        font-size: 2.5rem;
        font-weight: 800;
        color: #2c3e50;
        line-height: 1.2;
        margin-bottom: 1.5rem;
    }

    .article-tags {
        display: flex;
        flex-wrap: wrap;
        gap: 0.5rem;
    }

    .tag {
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        color: white;
        padding: 0.5rem 1rem;
        border-radius: 20px;
        font-size: 0.875rem;
        font-weight: 500;
    }

    .article-image {
        width: 100%;
        height: 400px;
        overflow: hidden;
    }

        .article-image img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

    .article-content {
        padding: 3rem 2rem;
    }

    .content-wrapper {
        max-width: 800px;
        margin: 0 auto;
        font-size: 1.125rem;
        line-height: 1.7;
        color: #2c3e50;
    }

        .content-wrapper :deep(h1) {
            font-size: 2rem;
            font-weight: 700;
            margin: 2rem 0 1rem;
            color: #2c3e50;
        }

        .content-wrapper :deep(h2) {
            font-size: 1.75rem;
            font-weight: 600;
            margin: 1.5rem 0 1rem;
            color: #2c3e50;
        }

        .content-wrapper :deep(h3) {
            font-size: 1.5rem;
            font-weight: 600;
            margin: 1.5rem 0 1rem;
            color: #2c3e50;
        }

        .content-wrapper :deep(p) {
            margin-bottom: 1.5rem;
        }

        .content-wrapper :deep(a) {
            color: #667eea;
            text-decoration: none;
            font-weight: 500;
        }

        .content-wrapper :deep(a:hover) {
            color: #764ba2;
            text-decoration: underline;
        }

        .content-wrapper :deep(ul), .content-wrapper :deep(ol) {
            margin-bottom: 1.5rem;
            padding-left: 2rem;
        }

        .content-wrapper :deep(li) {
            margin-bottom: 0.5rem;
        }

        .content-wrapper :deep(blockquote) {
            border-left: 4px solid #667eea;
            padding-left: 1.5rem;
            margin: 2rem 0;
            font-style: italic;
            color: #6c757d;
        }

        .content-wrapper :deep(code) {
            background: #f8f9fa;
            padding: 0.2rem 0.4rem;
            border-radius: 4px;
            font-family: 'Monaco', 'Menlo', 'Ubuntu Mono', monospace;
            font-size: 0.875rem;
        }

    .article-footer {
        padding: 2rem;
        border-top: 1px solid #e9ecef;
    }

    .footer-actions {
        display: flex;
        gap: 1rem;
        margin-bottom: 3rem;
        justify-content: center;
    }

    .action-btn {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        padding: 0.75rem 1.5rem;
        border: 2px solid #e9ecef;
        background: white;
        border-radius: 25px;
        cursor: pointer;
        transition: all 0.3s ease;
        font-weight: 500;
        color: #6c757d;
    }

        .action-btn:hover {
            border-color: #667eea;
            color: #667eea;
            transform: translateY(-2px);
        }

        .action-btn .bi-heart.liked {
            color: #dc3545;
        }

    .article-navigation {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 2rem;
    }

    .nav-link {
        display: flex;
        align-items: center;
        gap: 1rem;
        padding: 1.5rem;
        border: 2px solid #e9ecef;
        border-radius: 16px;
        text-decoration: none;
        color: inherit;
        transition: all 0.3s ease;
    }

        .nav-link:hover {
            border-color: #667eea;
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
        }

        .nav-link.prev {
            text-align: left;
        }

        .nav-link.next {
            text-align: right;
            flex-direction: row-reverse;
        }

    .nav-content {
        flex: 1;
    }

    .nav-label {
        display: block;
        font-size: 0.875rem;
        color: #6c757d;
        margin-bottom: 0.25rem;
    }

    .nav-title {
        display: block;
        font-weight: 600;
        color: #2c3e50;
        line-height: 1.4;
    }

    /* Loading State */
    .loading-state {
        background: white;
        border-radius: 20px;
        box-shadow: 0 10px 40px rgba(0, 0, 0, 0.1);
        overflow: hidden;
    }

    .skeleton-article {
        padding: 2rem;
    }

    .skeleton-header {
        margin-bottom: 2rem;
    }

    .skeleton-meta,
    .skeleton-title,
    .skeleton-tags,
    .skeleton-image,
    .skeleton-text {
        background: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
        background-size: 200% 100%;
        animation: loading 1.5s infinite;
        border-radius: 4px;
    }

    .skeleton-meta {
        height: 50px;
        width: 200px;
        margin-bottom: 2rem;
    }

    .skeleton-title {
        height: 48px;
        width: 80%;
        margin-bottom: 1.5rem;
    }

    .skeleton-tags {
        height: 32px;
        width: 60%;
        margin-bottom: 2rem;
    }

    .skeleton-image {
        height: 400px;
        width: 100%;
        margin-bottom: 2rem;
    }

    .skeleton-text {
        height: 20px;
        width: 100%;
        margin-bottom: 1rem;
    }

        .skeleton-text.short {
            width: 70%;
        }

    @keyframes loading {
        0% {
            background-position: 200% 0;
        }

        100% {
            background-position: -200% 0;
        }
    }

    /* Адаптивность */
    @media (max-width: 768px) {
        .article-header {
            padding: 2rem 1.5rem 1.5rem;
        }

        .article-title {
            font-size: 2rem;
        }

        .article-meta {
            flex-direction: column;
            align-items: flex-start;
        }

        .article-content {
            padding: 2rem 1.5rem;
        }

        .content-wrapper {
            font-size: 1rem;
        }

        .article-navigation {
            grid-template-columns: 1fr;
            gap: 1rem;
        }

        .footer-actions {
            flex-direction: column;
            align-items: center;
        }
    }

    @media (max-width: 480px) {
        .article-title {
            font-size: 1.75rem;
        }

        .article-header {
            padding: 1.5rem 1rem 1rem;
        }

        .article-content {
            padding: 1.5rem 1rem;
        }

        .meta-item {
            flex-direction: column;
            align-items: flex-start;
            gap: 0.5rem;
        }
    }
</style>