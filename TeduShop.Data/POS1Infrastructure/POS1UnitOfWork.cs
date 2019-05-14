using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.POS1Infrastructure
{
    public class POS1UnitOfWork: IPOS1UnitOfWork
    {
        private readonly IPOS1DbFactory dbFactory;
        private POS1DbContext dbContext;

        public POS1UnitOfWork(IPOS1DbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public POS1DbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
