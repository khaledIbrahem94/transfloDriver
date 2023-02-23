using System;
using System.Threading.Tasks;

namespace InfraStructure
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        // bool Disposetransaction { get; set; }
        IRepository<T> GetRepository<T>() where T : class;

        Task<int> SaveChangesAsync();
    }
}
