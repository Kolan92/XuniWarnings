using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XunitFail
{
    public static class Extensions
    {
        public static IEnumerable<object[]> ToArgumentsArray(this IEnumerable arguments)
        {
            return arguments.OfType<object>().Select(a => new[] { a });
        }
    }

    public abstract class BaseValue
    {

    }

    public abstract class ValidValue : BaseValue
    {

    }

    public class FooValue : ValidValue
    {
        public bool Value { get; set; }
    }

    public class BarValue : ValidValue
    {
        public string Value { get; set; }
    }


    public class TestObject<T>
    where T : BaseValue
    {
        public T Value { get; set; }
        public int Quality { get; set; }
        public TimeSpan Validity { get; set; }
        public DateTime Stamp { get; set; }
    }

    public static class TestArguments
    {
        public static IEnumerable<object[]> DateTimes => new[]
            {
                default(DateTime),
                new DateTime(2222, 2, 22, 22, 22, 22, DateTimeKind.Utc),
                new DateTime(2222, 2, 22, 22, 22, 22, DateTimeKind.Local),
                DateTime.MaxValue
            }
            .ToArgumentsArray();
    }

    public abstract class BaseBaseClass<T>
    where T : BaseValue
    {
        //        [Theory]
        //        [MemberData(nameof(TestArguments.DateTimes), MemberType = typeof(TestArguments))]
        //        public void Should_Serialize_Stamp_To_Valid_Json(DateTime stamp)
        //        {
        //            var testObject = FactoryMethod();
        //            testObject.Stamp = stamp;
        //
        //            Assert.Equal(stamp, testObject.Stamp);
        //        }

        public abstract TestObject<T> FactoryMethod();

    }

    public abstract class BaseTestClass<T> : BaseBaseClass<T>
        where T : ValidValue
    {
        private const int Special = 10;

        public static IEnumerable<object[]> Validities => new[]
            {
                    TimeSpan.MaxValue
                }
            .ToArgumentsArray();


        //        [Theory]
        //        [InlineData(0)]
        //        [InlineData(Special)]
        //        [InlineData(111)]
        //        public void Should_Serialize_Quality_To_Valid_Json(int quality)
        //        {
        //            var testObject = FactoryMethod();
        //            testObject.Quality = quality;
        //
        //            Assert.Equal(quality, testObject.Quality);
        //        }


        [Theory]
        [MemberData(nameof(Validities))]
        public void Should_Serialize_Validity_To_Valid_Json(TimeSpan validity)
        {
            //            var testObject = FactoryMethod();
            //            testObject.Validity = validity;
            //
            //            Assert.Equal(validity, testObject.Validity);
        }
    }

    public class TestWithWarnings1 : BaseTestClass<FooValue>
    {
        //        [Theory]
        //        [InlineData(true)]
        //        [InlineData(false)]
        //        public void Should_Serialize_Value_To_Valid_Json(bool value)
        //        {
        //            var testObject = FactoryMethod();
        //            testObject.Value.Value = value;
        //
        //            Assert.Equal(value, testObject.Value.Value);
        //        }

        public override TestObject<FooValue> FactoryMethod()
        {
            return new TestObject<FooValue>
            {
                Value = new FooValue()
            };
        }
    }

    //    public class TestWithWarnings2 : BaseTestClass<BarValue>
    //    {
    ////        [Theory]
    ////        [InlineData("")]
    ////        [InlineData("test")]
    ////        public void Should_Serialize_Value_To_Valid_Json(string value)
    ////        {
    ////            var testObject = FactoryMethod();
    ////            testObject.Value.Value = value;
    ////
    ////            Assert.Equal(value, testObject.Value.Value);
    ////        }
    //
    //        public override TestObject<BarValue> FactoryMethod()
    //        {
    //            return new TestObject<BarValue>
    //            {
    //                Value = new BarValue()
    //            };
    //        }
    //    }
}

