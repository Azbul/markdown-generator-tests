using Markdown.Generator.Core.Markdown;
using System.Linq;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownableTypeTests
    {
        [Fact]
        public void MarkdownableType_SutTypeAsParameterAndCallGetMethods_ReturnSutPublicMethods()
        {
            var markdownableType = new MarkdownableType(typeof(Sut), null);

            var actual = markdownableType.GetMethods();

            Assert.True(actual.All(mi => mi.IsPublic));
        }

        [Fact]
        public void MarkdownableType_SutTypeAsParameterAndCallGetFields_ReturnSutPublicMethods()
        {
            var markdownableType = new MarkdownableType(typeof(Sut), null);

            var actual = markdownableType.GetFields();

            Assert.True(actual.All(mi => mi.IsPublic));
        }

        [Fact]
        public void MarkdownableType_SutTypeAsParameterAndCallGetProperties_ReturnSutPublicMethods()
        {
            var markdownableType = new MarkdownableType(typeof(Sut), null);

            var actual = markdownableType.GetProperties();

            Assert.True(actual.All(mi => mi.PropertyType.IsPublic));
        }

        class Sut
        {
            public object PublicField;
            private object _privateField;

            public object PublicProperty { get; set; }
            private object PrivateProperty { get; set; }

            public void PublicMethod() { }
            private void PrivateMethod() { }

        }
    }
}
