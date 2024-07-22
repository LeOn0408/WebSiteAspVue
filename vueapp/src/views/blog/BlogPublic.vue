<template>
    <div class="d-flex justify-content-center">
        <span class="lead align-bottom">Все статьи</span>
    </div>

    <div class="d-flex justify-content-center my-5" v-if="articles.length==0">
        <div class="spinner-grow me-2" role="status"></div>
        <div class="spinner-grow me-2" role="status"></div>
        <div class="spinner-grow me-2" role="status"></div>
        <span class="visually-hidden">Загрузка...</span>
    </div>

    <div class="row mx-auto article">
        <div class="col-sm-6 col-lg-3 col-md-4  g-3" v-for="item in articles">
            <div class="card article-card">
                <div class="card-body article-body">
                    <h5 class="card-title">{{item.title}}</h5>
                    <p class="card-title small">
                        <span class="text-black-50">от</span> <span class="text-success">{{item.createdByUser.userName}}</span>
                        <span class="small text-black-50 me-1 ms-1">{{localeDate(item.creationDate)}}</span>
                        <span class="text-black-50">в</span> <span class="card-title small text-success  me-1 ms-1">{{item.section.title}}</span>
                    </p>
                    <p>
                        <span v-for="tag in item.tags">
                            <span class="badge me-1 rounded-pill " :class="tag.colorCode">{{tag.title}}</span>
                        </span>
                    </p>
                    <p class="card-text" v-html="item.description"></p>
                </div>
                <div class="card-footer text-muted">
                    <a class="icon-link icon-link-hover" data-bs-toggle="modal" href="#articleModalToggle" role="button" @click="open(item)">
                        {{ $t('article.readmore') }}
                        <svg class="bi" aria-hidden="true"><use xlink:href="#arrow-right"></use></svg>
                    </a>
                </div>

            </div>
        </div>

    </div>
    <div class="modal fade" id="articleModalToggle" aria-hidden="true" aria-labelledby="articleModalToggleLabel" tabindex="-1">
        
       <ArticleComponent :article="selectArticle"></ArticleComponent>
        
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
                selectArticle: {title:"new"} as any
            }
        },
        components:{        
            ArticleComponent
        },
        created() {
            this.getArticleList()
        },
        methods: {
            async getArticleList(){
                const articleService = new Article();
                let articles = await articleService.getListPeriodAsync(0, 12)           
                this.articles = articles;
            },
            localeDate(date:string) {
                return Helper.FormatDate(date);
            },
            open(article:Object) {
                this.selectArticle = article;
            }
        },
    });
</script>

<style>
    .article-card {
        height: 25vh;
        overflow-y: hidden;
    }
    .article-body {
        height: 5rem;
        overflow-y: hidden;
    }
    .article{
        margin-bottom: 5rem;
    }
</style>