using System;
using System.Threading.Tasks;

namespace Database.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // add repositories
        // public ISampleEntityRepository SampleEntityRepository { get; }

        public int Complete();

        public Task<int> CompleteAsync();
    }
}
