using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_caching
{
    public interface IMycache
    {
        bool Add(object key, object value);
    }
}
