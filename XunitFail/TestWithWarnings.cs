using System;
using System.Collections.Generic;
using Xunit;

namespace XunitFail
{
    public abstract class BaseValue { }

    public abstract class ValidValue : BaseValue { }

    public class FooValue : ValidValue { }

    public class TestObject<T> where T : BaseValue
    {
        public T Value { get; set; }
    }

    public abstract class BaseValueTests<T> where T : BaseValue
    {
    }

    public abstract class ValidValueTests<T> : BaseValueTests<T>
        where T : ValidValue
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

    public class FooValueTests : ValidValueTests<FooValue>
    {
    }
}

