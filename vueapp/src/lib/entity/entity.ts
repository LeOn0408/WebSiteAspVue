
export interface IEntity<T> {
    getListAsync(): Promise<Array<T>>;
    get(id: number): T;
    add(entity: T): T;
}
export abstract class Entity<T> implements IEntity<T> {
    getListAsync(): Promise<Array<T>> {
        throw new Error("Method not implemented.");
    }
    get(id: number): T {
        return {} as T;
    }
    add(entity: T): T {
        return {} as T;
    }
}
