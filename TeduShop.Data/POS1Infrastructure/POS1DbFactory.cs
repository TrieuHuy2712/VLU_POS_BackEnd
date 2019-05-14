using TeduShop.Data.Infrastructure;

namespace TeduShop.Data.POS1Infrastructure
{
    public class POS1DbFactory : Disposable, IPOS1DbFactory
    {
        private POS1DbContext dbContext;

        public POS1DbContext Init()
        {
            return dbContext ?? (dbContext = new POS1DbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}