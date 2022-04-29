using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Create(T entity);
        Task<List<T>> ReadAll();
        Task<T> Read(int id);
        Task<T> Update(T newEntity);
        Task<T> Delete(int id);
    }
}
