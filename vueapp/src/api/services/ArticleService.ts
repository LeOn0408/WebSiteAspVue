import type { ArticleModel } from "../../lib/model/articlemodel";
import axios from 'axios';
import type { IDataService } from "./IDataService";
import { Logger } from '@/lib/services/Logger';


export class ArticleService implements IDataService<ArticleModel> {
    private logger: Logger;

    constructor() {
        this.logger = new Logger();
    }

    getListAsync(): Promise<Array<ArticleModel>> {
        throw new Error("Method not implemented.");
    }
    add(entity: ArticleModel): ArticleModel {
        throw new Error("Method not implemented.");
    }
    async getArticlesByPageAsync(page: number, pageSize: number): Promise<{ items: ArticleModel[], totalCount: number }> {
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
            this.logger.logError("Error fetching articles by page", error);
            //TODO:Локализация
            throw new Error("Failed to fetch articles. Please try again later.");
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
            this.logger.logError(`Error fetching article with ID: ${id}`, error);
            //TODO:Локализация
            throw new Error("Failed to fetch the article. Please try again later.");
        }
    }
}
