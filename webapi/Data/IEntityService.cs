using webapi.Data.Dto.News;

namespace webapi.Data
{
    public interface IEntityService<T>
    {
        public int Add(T entity);
        public bool Delete(T entity);
        public bool Update(T entity);
        public T Get();
        public IEnumerable<T> GetAll();
    }
}
