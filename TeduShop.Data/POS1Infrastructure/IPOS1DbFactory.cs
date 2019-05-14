using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.POS1Infrastructure
{
    public interface IPOS1DbFactory: IDisposable
    {
        POS1DbContext Init();
    }
}
