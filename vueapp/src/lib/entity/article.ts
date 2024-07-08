import type { ArticleModel } from "../model/articlemodel";
import { type IEntity } from "./entity";
import axios from 'axios';


export class Article implements IEntity<ArticleModel> {
    getListAsync(): Promise<Array<ArticleModel>> {
        throw new Error("Method not implemented.");
    }
    get(id: number): ArticleModel {
        
        throw new Error("Method not implemented.");
    }
    add(entity: ArticleModel): ArticleModel {
        throw new Error("Method not implemented.");
    }
    async getListPeriodAsync(page:number, pageSize:number): Promise<Array<ArticleModel>>{
        try {
            let result: ArticleModel[] = await axios.get("/api/blog/list", {
                params: {
                    page: page,
                    pageSize: pageSize
                }
            });
            return result;
        }

        catch (error: any) {
            throw error;
        }
    }
}