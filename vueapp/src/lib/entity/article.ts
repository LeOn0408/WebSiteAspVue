import type { ArticleModel } from "../model/articlemodel";
import { type IEntity } from "./entity";
import axios from 'axios';


export class Article implements IEntity<ArticleModel> {
    getListAsync(): Promise<Array<ArticleModel>> {
        throw new Error("Method not implemented.");
    }
    add(entity: ArticleModel): ArticleModel {
        throw new Error("Method not implemented.");
    }
    async getArticlesByPageAsync(page:number, pageSize:number): Promise<Array<ArticleModel>>{
        try {
            let result = await axios.get("/api/blog/list", {
                params: {
                    page: page,
                    pageSize: pageSize
                }
            });
            return result.data;
        }

        catch (error: any) {
            throw error;
        }
    }
    async getByIdAsync(id: number): Promise<ArticleModel> {
        try {
            let result = await axios.get("/api/blog/get", {
                params: {
                    id: id,
                }
            });
            return result.data;
        }
        catch (error: any) {
            throw error;
        }
    }
}