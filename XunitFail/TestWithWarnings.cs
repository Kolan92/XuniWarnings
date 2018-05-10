using System;
using System.Collections.Generic;
using Xunit;

namespace XunitFail
{
    public class ValidValue { }

    public class FooValue : ValidValue { }

    public class ValidValueTests<T>
    {
    }

    public class FooValueTests : ValidValueTests<FooValue>
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

