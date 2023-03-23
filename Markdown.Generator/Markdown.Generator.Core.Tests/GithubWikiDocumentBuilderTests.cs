using Markdown.Generator.Core.Documents;
using Markdown.Generator.Core.Markdown;
using Moq;
using System;
using System.Reflection;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class GithubWikiDocumentBuilderTests
    {
        [Fact]
        public void Load_DllPathAndNamespacePathAsParameters_MetodCalledOnlyOnce() 
        {
            var mock = new Mock<IMarkdownGenerator>();
            
            mock.Setup(generator => generator.Load("dll path", "namespace match"))
                .Returns(Array.Empty<MarkdownableType>());

            var githubWikiDocumentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(mock.Object);
            
            //Act
            githubWikiDocumentBuilder.Generate("dll path", "namespace match", "some folder");

            //Assert
            mock.Verify(generator => generator.Load("dll path", "namespace match"), Times.AtMostOnce());
        }

        [Fact]
        public void Load_EmptyArrayOfTypeAsParameters_MetodCalledOnlyOnce() 
        {
            var emptyArrayOfType = Array.Empty<Type>();
            var mock = new Mock<IMarkdownGenerator>();
            
            mock.Setup(generator => generator.Load(emptyArrayOfType))
                .Returns(Array.Empty<MarkdownableType>());

            var githubWikiDocumentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(mock.Object);
            
            //Act
            githubWikiDocumentBuilder.Generate(emptyArrayOfType, "some folder");

            //Assert
            mock.Verify(generator => generator.Load(emptyArrayOfType), Times.AtMostOnce());
        }


        [Fact]
        public void Load_EmptyArrayOfAssemblyAsParameters_MetodCalledOnlyOnce() 
        {
            var emptyArrayOfAssembly = Array.Empty<Assembly>();
            var mock = new Mock<IMarkdownGenerator>();
            
            mock.Setup(generator => generator.Load(emptyArrayOfAssembly, "namespace match"))
                .Returns(Array.Empty<MarkdownableType>());

            var githubWikiDocumentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(mock.Object);
            
            //Act
            githubWikiDocumentBuilder.Generate(emptyArrayOfAssembly, "namespace match", "some folder");

            //Assert
            mock.Verify(generator => generator.Load(emptyArrayOfAssembly, "namespace match"), Times.AtMostOnce());
        }
    }
}
