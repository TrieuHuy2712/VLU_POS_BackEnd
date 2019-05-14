using System;

namespace TeduShop.Data.Infrastructure
{
    public interface IDbFactoryBackup : IDisposable
    {
        BackupDbContext Init();
    }
}