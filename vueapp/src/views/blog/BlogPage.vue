<template>
    <div class="container mt-4">
        <!-- Верхняя панель с разделами -->
        <ul class="nav nav-tabs mb-3">
            <li class="nav-item">
                <a class="nav-link active" href="#">Все</a>
            </li>
            <!--TODO:Добавить все разделы-->
            <!--<li class="nav-item">
                <a class="nav-link" href="#">Раздел 1</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">Раздел 2</a>
            </li>-->
        </ul>

        <div class="row">
            <div class="col-lg-12">
                <div v-for="item in articles" :key="item.id" class="card mb-3 shadow-sm article-card">
                    <div class="card-body">
                        <h5 class="card-title">{{ item.title }}</h5>
                        <p class="card-text text-muted small">
                            <span>от {{ item.createdByUser.userName }}</span> |
                            <span>{{ localeDate(item.creationDate) }}</span>
                        </p>
                        <p class="card-text" v-html="item.description"></p>
                        <div>
                            <a href="#" class="badge bg-secondary me-1" v-for="tag in item.tags" :key="tag.id">{{ tag.title }}</a>
                        </div>
                        <router-link :to="{ name: 'ArticlePage', params: { id: item.id }}" class="btn btn-outline-primary btn-sm mt-3">
                            Читать далее
                        </router-link>
                    </div>
                </div>
            </div>
        </div>
        <!-- Постраничная навигация -->
        <nav class="mt-4">
            <ul class="pagination justify-content-center">
                <li class="page-item" :class="{ disabled: currentPage === 1 }">
                    <button class="page-link" @click="changePage(currentPage - 1)" :disabled="currentPage === 1">
                        ← Назад
                    </button>
                </li>
                <li class="page-item" v-for="page in totalPages" :key="page" :class="{ active: page === currentPage }">
                    <button class="page-link" @click="changePage(page)">{{ page }}</button>
                </li>
                <li class="page-item" :class="{ disabled: currentPage === totalPages }">
                    <button class="page-link" @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">
                        Вперед →
                    </button>
                </li>
            </ul>
        </nav>
    </div>
</template>


<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    import { mapActions, mapState } from 'vuex';
    import { Article } from "../../lib/entity/article";
    import { Helper } from "../../lib/helper"
    const ArticleComponent = defineAsyncComponent(() =>
        import('@/components/modal/ArticleComponent.vue')
    )

    export default defineComponent({
        data() {
            return {
                articles: [] as any[],//пока any
                currentPage: 1, // Текущая страница
                pageSize: 10, // Количество статей на странице
                totalPages: 0, // Общее количество страниц
            }
        },
        components: {
            ArticleComponent
        },
        created() {
            this.loadArticles()
        },
        methods: {
            async loadArticles() {
                const articleService = new Article();
                const response = await articleService.getArticlesByPageAsync(this.currentPage, this.pageSize);
                
                this.articles = response.items;
                this.totalPages = Math.ceil(response.totalCount / this.pageSize);
            },
            localeDate(date: string) {
                return Helper.FormatDate(date);
            },
            changePage(page: number) {
                if (page < 1 || page > this.totalPages) return; // Проверка границ
                this.currentPage = page;
                this.loadArticles(); // Загрузка статей для выбранной страницы
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

    .sticky-top {
        position: sticky;
    }
</style>