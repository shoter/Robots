using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Common.Test
{
    public class UniqueIdGeneratorTest
    {
        private readonly UniqueIdGenerator uniqueId = new UniqueIdGenerator();

        [Fact]
        public void Id_FirstId_ShouldBeZero()
        {
            Assert.Equal((ulong)0, uniqueId.Id);
        }

        [Fact]
        public void Id_IsRising()
        {
            for(ulong i = 0;i < 1234; ++i)
            {
                Assert.Equal(i, uniqueId.Id);
            }
        }
    }
}
