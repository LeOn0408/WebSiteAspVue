import { NewsModel } from "../model/newsmodel";
import { IEntity } from "./ientity";

export class News implements IEntity<NewsModel> {
    get(): NewsModel {
        throw new Error("Method not implemented.");
    }
    add(entity: NewsModel): NewsModel {
        throw new Error("Method not implemented.");
    }
    getList(): Array<NewsModel>{

        return [];
    }
}