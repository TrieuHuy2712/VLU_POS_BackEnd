using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface ISyncLogService
    {
        SyncLog Add(SyncLog Product);

        IEnumerable<SyncLog> GetAll();

        void Save();
    }

    public class SyncLogService : ISyncLogService
    {
        private ISyncLogRepository _syncLogRepository;

        private IUnitOfWork _unitOfWork;

        public SyncLogService(ISyncLogRepository syncLogRepository, IUnitOfWork unitOfWork)
        {
            this._syncLogRepository = syncLogRepository;
            this._unitOfWork = unitOfWork;
        }

        public SyncLog Add(SyncLog syncLog)
        {
            return _syncLogRepository.Add(syncLog);
        }

        public IEnumerable<SyncLog> GetAll()
        {
            return _syncLogRepository.GetAll().OrderBy(x => x.CreatedDate);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

    }
}