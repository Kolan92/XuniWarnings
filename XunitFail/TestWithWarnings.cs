using System;
using System.Collections.Generic;
using Xunit;

namespace XunitFail
{
    public class FooValueTests
    {

        public static IEnumerable<object[]> Validities => new[]
        {
            new object[] {TimeSpan.MaxValue}
        };

        [Theory]
        [MemberData(nameof(Validities))]
        public void Should_Serialize_Validity_To_Valid_Json(TimeSpan validity)
        {
        }
    }
}

