using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;

namespace TeduShop.Data.POS2Infrastructure
{
    public class POS2DbFactory : Disposable, IPOS2DbFactory
    {
        private POS2DbContext dbContext;

        public POS2DbContext Init()
        {
            return dbContext ?? (dbContext = new POS2DbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
