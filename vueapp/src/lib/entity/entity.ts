
export interface IEntity<T> {
    getListAsync(): Promise<Array<T>>;
    getByIdAsync(id: number): Promise<T>;
    add(entity: T): T;
}
export abstract class Entity<T> implements IEntity<T> {
    getListAsync(): Promise<Array<T>> {
        throw new Error("Method not implemented.");
    }
    getByIdAsync(id: number): Promise<T> {
        return {} as Promise<T>;
    }
    add(entity: T): T {
        return {} as T;
    }
}
