using DTO.Model;
using System.Linq.Expressions;

namespace InfraStructure
{
    public interface IRepository<T> where T : class
    {
        Task<T> InsertAsync(T Entity);

        Task<T> UpdateAsync(T Entity, params Expression<Func<T, object>>[] ExcludePara);

        Task<bool> DeleteAsync(T Entity);

        Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(object id);
    }
}
