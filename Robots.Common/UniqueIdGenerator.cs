using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Common
{
    public class UniqueIdGenerator
    {
        public ulong lastId { get; private set; } = ulong.MinValue;

        public ulong Id => lastId++;
    }
}
