namespace TeduShop.Data.Infrastructure
{
    public class DbFactoryBackup : Disposable, IDbFactoryBackup
    {
        private BackupDbContext dbContext;

        public BackupDbContext Init()
        {
            return dbContext ?? (dbContext = new BackupDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}