using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.POS2Infrastructure
{
    public interface IPOS2UnitOfWork
    {
        void Commit();
    }
}
