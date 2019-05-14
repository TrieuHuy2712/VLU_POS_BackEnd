
namespace TeduShop.Data.Infrastructure
{
    public class BackupUnitOfWork : IBackupUnitOfWork

    {
        private readonly IDbFactoryBackup dbFactory;
        private BackupDbContext dbContext;

        public BackupUnitOfWork(IDbFactoryBackup dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public BackupDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
