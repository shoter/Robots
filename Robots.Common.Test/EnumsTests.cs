using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Common.Test
{
    public class EnumsTests
    {
        private enum TestEnum
        {
            One = 1,
            Two = 2,
            Four = 4
        };

        [Fact]
        public void ToList_ReturnsAllValues()
        {
            var values = new TestEnum[]
            {
                TestEnum.One,
                TestEnum.Two,
                TestEnum.Four
            };

            var list = Enums.ToList<TestEnum>();

            foreach (var v in values)
                Assert.Contains(v, list);
        }
    }
}
