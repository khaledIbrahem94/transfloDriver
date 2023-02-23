using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Domain;
using DTO.Model;

namespace InfraStructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public MainDbContext Context;

        public Repository(MainDbContext context)
        {
            Context = context;
        }

        public async Task<T> InsertAsync(T Entity)
        {
            var result = await Context.AddAsync(Entity);
            return Entity;
        }

        public async Task<T> UpdateAsync(T Entity, params Expression<Func<T, object>>[] ExcludePara)
        {
            var result = Context.Update(Entity);

            foreach (var para in ExcludePara)
            {
                Context.Entry(Entity).Property(para).IsModified = false;
            }

            return Entity;
        }

        public async Task<bool> DeleteAsync(T Entity)
        {
            try
            {
                Context.Set<T>().AsNoTracking();
                Context.Entry(Entity).State = EntityState.Detached;
                IQueryable<T> query = Context.Set<T>().AsNoTracking();
                var result = Context.Remove(Entity);
            }
            catch (Exception ex)
            {
            }
            return true;
        }

        public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

                if (Total == 0)
                {
                    return (0, null);
                }

                IQueryable<T> res;

                res = await Task.Run(() => query.Where(expression).AsNoTracking());

                return (Total, res.AsNoTracking());

                //string name = typeof(T).Name;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var r = await Context.Set<T>().FindAsync(id);
            return r;
        }
    }
}
