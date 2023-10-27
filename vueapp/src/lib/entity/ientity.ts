export interface IEntity<T>{
    getList(): Array<T>;
    get(): T;
    add(entity: T): T;
}