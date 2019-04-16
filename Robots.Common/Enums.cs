using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Common
{
    public static class Enums
    {
        public static List<TEnum> ToList<TEnum>()
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();

        }
    }
}
