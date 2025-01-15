using webapi.Model;

namespace webapi.Services
{
    public interface IEntityService<T> where T : Entity
    {
        public int Add(T entity);
        public bool Delete(T entity);
        public bool Update(T entity);
        public T Get(int id);
        public CollectionResult<T> GetAll();
        
    }
}
