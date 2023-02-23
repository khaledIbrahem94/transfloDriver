using Domain;

namespace InfraStructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public MainDbContext Context;

        public UnitOfWork(MainDbContext context)
        {
            Context = context;
        }

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public async ValueTask DisposeAsync()
        {
            await Context.DisposeAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            this._repositories = new Dictionary<Type, object>();

            var type = typeof(T);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new Repository<T>(Context);
            }

            return (IRepository<T>)this._repositories[type];
        }

        public Task RollBackTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await Context.SaveChangesAsync();
            return result;
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            this._repositories = new Dictionary<Type, object>();

            var type = typeof(T);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new Repository<T>(Context);
            }

            return (IRepository<T>)this._repositories[type];
        }
    }
}
