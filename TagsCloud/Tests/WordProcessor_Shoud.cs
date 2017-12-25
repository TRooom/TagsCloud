using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TagsCloud.Infrastructure;
using NSubstitute;
using TagsCloud.Tool;

namespace TagsCloud.Tests
{
    [TestFixture]
    public class WordProcessor_Shoud
    {
        private IWordProcessor processor;
        private IWordReader reader;
        private IWordProvider provider;

        [SetUp]
        public void SetUp()
        {
            processor = new SimpleWordProcessor();
            reader = Substitute.For<IWordReader>();
            provider = new SimpleWordProvider(reader, processor);
        }

        [Test]
        public void DontChangeWords_ByDefault()
        {
            var words = new[] {"one", "two", "three"};
            reader.ReadWords().Returns(words);

            provider.GetWords().ShouldBeEquivalentTo(words);
        }

        [Test]
        public void ExcludeWords_ByRule()
        {
            var words = new[] {"one", "two", "three"};
            reader.ReadWords().Returns(words);

            processor.AddExcludingRule(x => x.Length > 3);

            provider.GetWords().ShouldBeEquivalentTo(new[] {"one", "two"});
        }

        [Test]
        public void ExculeWords_BySeveralRules()
        {
            var words = new[] {"one", "two", "three"};
            reader.ReadWords().Returns(words);

            processor.AddExcludingRule(x => x.Length > 3);
            processor.AddExcludingRule(x => x == "two");

            provider.GetWords().ShouldBeEquivalentTo(new[] {"one"});
        }

        [Test]
        public void ConvertAllWords_ByConvertion()
        {
            var words = new[] {"one", "two", "three"};
            reader.ReadWords().Returns(words);

            processor.Convertion = x => x.ToUpper();

            provider.GetWords().ShouldBeEquivalentTo(new[] {"ONE", "TWO", "THREE"});
        }

        [Test]
        public void ExcludeAndConvert()
        {
            var words = new[] {"one", "two", "three"};
            reader.ReadWords().Returns(words);

            processor.AddExcludingRule(x => x.Length > 3);
            processor.Convertion = x => x + " cookies";

            provider.GetWords().ShouldBeEquivalentTo(new[] {"one cookies", "two cookies"});
        }
    }
}