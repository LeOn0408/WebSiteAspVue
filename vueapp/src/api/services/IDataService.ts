export interface IDataService<T> {
    getListAsync(): Promise<Array<T>>;
    getByIdAsync(id: number): Promise<T>;
    add(entity: T): T;
}
