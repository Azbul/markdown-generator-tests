using Markdown.Generator.Core.Markdown;
using Markdown.Generator.Core.Markdown.Elements;
using System.Linq;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownBuilderTests
    {
        [Fact]
        public void MarkdownBuilder_CallCode_OneCodeInElements()
        {
            var markdownBuilder = new MarkdownBuilder();

            markdownBuilder.Code("csharp", "some code");

            Assert.Single(markdownBuilder.Elements);
            Assert.IsType<Code>(markdownBuilder.Elements.First());
        }

        [Fact]
        public void MarkdownBuilder_CallCodeQuote_OneCodeQuoteInElements()
        {
            var markdownBuilder = new MarkdownBuilder();

            markdownBuilder.CodeQuote("some code");

            Assert.Single(markdownBuilder.Elements);
            Assert.IsType<CodeQuote>(markdownBuilder.Elements.First());
        }

        [Fact]
        public void MarkdownBuilder_CallLink_OneLinkInElements()
        {
            var markdownBuilder = new MarkdownBuilder();

            markdownBuilder.Link("some text", "some url");

            Assert.Single(markdownBuilder.Elements);
            Assert.IsType<Link>(markdownBuilder.Elements.First());
        }

        [Fact]
        public void MarkdownBuilder_CallHeader_OneHeaderInElements()
        {
            var markdownBuilder = new MarkdownBuilder();

            markdownBuilder.Header(0 ,"some text");

            Assert.Single(markdownBuilder.Elements);
            Assert.IsType<Header>(markdownBuilder.Elements.First());
        }
    }
}
