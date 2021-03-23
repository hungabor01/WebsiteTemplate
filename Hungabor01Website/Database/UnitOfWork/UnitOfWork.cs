using Database.Core;
using System.Threading.Tasks;

namespace Database.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        // add repositories
        // public ISampleEntityRepository SampleEntityRepository { get; }

        public UnitOfWork(
            ApplicationDbContext context
            /* ISampleEntityRepository sampleEntityRepository*/ )
        {
            this.context = context;
            // SampleEntityRepository = sampleEntityRepository;

            // initialize repositories with the context
            // SampleEntityRepository.Initialize(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
