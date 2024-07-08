import { Article } from "../../lib/entity/article";
import type { ArticleModel } from "../../lib/model/articlemodel";

export default {
    state: {
        article: {},
    },
    mutations: {

    },
    actions: {
        async getArticle(context: any, id: number) {
            const result: Article = new Article();

            return {};
        },
        async getArticleList(context: any): Promise<Array<ArticleModel>> {
            return [];
        },
        //async getListPeriodAsync(context: any, {page, pagesize}): Promise<Array<ArticleModel>> {
        //    const result: Article = new Article();
        //    return await result.getListPeriodAsync(page, pagesize);
        //}
    }
};