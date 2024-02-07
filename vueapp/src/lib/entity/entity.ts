import { type IEntity } from "./ientity";

export abstract class Entity<T> implements IEntity<T> {
    getList(): Array<T> {
        return [];
    }
    get(): T {
        return {} as T;
    }
    add(entity: T): T {
        return {} as T;
    }
}