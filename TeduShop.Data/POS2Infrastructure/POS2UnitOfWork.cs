using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.POS2Infrastructure
{
    public class POS2UnitOfWork : IPOS2UnitOfWork
    {
        private readonly IPOS2DbFactory dbFactory;
        private POS2DbContext dbContext;

        public POS2UnitOfWork(IPOS2DbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public POS2DbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
