using Markdown.Generator.Core.Markdown.Elements;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class ElementsTests
    {
        [Fact]
        public void Code_LanguageAndCodeAsParameter_ReturnMarkdownCodeMarkup()
        { 
            var expected = "``````csharp```\r\n```some code```\r\n```\r\n";
            var code = new Code("```csharp```", "```some code```");

            var actual = code.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeQuote_CodeAsParameter_ReturnMarkdownCodeQuoteMarkup()
        {
            var expected = "```some code```";
            var codeQuote = new CodeQuote("some code");

            var actual = codeQuote.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Header_LevelAndTextAsParameter_ReturnMarkdownHeaderMarkup()
        {
            var expected = "## some text\r\n";
            const int LEVEL_THREE = 3;
            var header = new Header(LEVEL_THREE, "some text");

            var actual = header.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Header_LevelAndCodeQuoteAsParameter_ReturnMarkdownHeaderMarkup()
        {
            var expected = "### ```some code```\r\n";
            var codeQuote = new CodeQuote("some code");
            const int LEVEL_FOUR = 4;
            var header = new Header(LEVEL_FOUR, codeQuote);

            var actual = header.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Header_LevelAndLinkAsParameter_ReturnMarkdownHeaderMarkup()
        {
            var expected = "#### [some text](some url)\r\n";
            const int LEVEL_FIVE = 5;
            var link = GetLinkWithSomeTextAndSomeUrl;
            var header = new Header(LEVEL_FIVE, link); 

            var actual = header.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_TextAsParameter_ReturnMarkdownListMarkup()
        {
            var expected = "- some text\r\n";
            var list = new List("some text");

            var  actual = list.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_LinkAsParameter_ReturnMarkdownListMarkup()
        {
            var expected = "- [some text](some url)\r\n";
            var link = GetLinkWithSomeTextAndSomeUrl;
            var list = new List(link);

            var  actual = list.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Link_TextAndUrlAsParameter_ReturnMarkdownLinkMarkup()
        {
            var expected = "[some text](some url)";
            var link = new Link("some text", "some url");

            var  actual = link.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Image_TextAndImageUrlAsParameter_ReturnMarkdownImageMarkup()
        {
            var expected = "![some text](some url)";
            var image = new Image("some text", "some url");

            var  actual = image.Create();

            Assert.Equal(expected, actual);
        }

        private Link GetLinkWithSomeTextAndSomeUrl =>
            new Link("some text", "some url");
    }
}
