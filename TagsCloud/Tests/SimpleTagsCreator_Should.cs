using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TagsCloud.Infrastructure;
using TagsCloud.Tool;

namespace TagsCloud.Tests
{
    [TestFixture]
    public class SimpleTagsCreator_Should
    {
        private SimpleTagsCreator creator;

        private IWordReader reader;

        [SetUp]
        public void SetUp()
        {
            var processor = new SimpleWordProcessor();
            reader = Substitute.For<IWordReader>();
            var provider = new SimpleWordProvider(reader, processor);
            creator = new SimpleTagsCreator(provider);
        }

        [Test]
        public void CreateTagBySingleWord()
        {
            var word = new[] {"word"};
            reader.ReadWords().Returns(word);

            var tags = creator.CreateTags().Value.ToList();

            tags.Count.Should().Be(1);
            tags.First().Word.Should().Be(word[0]);
        }

        [Test]
        public void CreateRectanglesTags()
        {
            var words = new[] {"word1", "a", "word2"};
            reader.ReadWords().Returns(words);

            var tags = creator.CreateTags().Value;

            tags.All(x => x.Size.Height < x.Size.Width).Should().BeTrue();
        }

        [Test]
        public void CreateLagerTagForMoreFrequencyWord()
        {
            var words = new[] {"word", "word", "word", "another"};
            reader.ReadWords().Returns(words);

            var tags = creator.CreateTags().Value;
            var wordSize = tags.Single(x => x.Word == "word").Size;
            var anotherSize = tags.Single(x => x.Word == "another").Size;
            (wordSize.Height + wordSize.Width).Should().BeGreaterThan(anotherSize.Width + anotherSize.Height);
        }

        [Test]
        public void CreateNotSmallTags()
        {
            var words = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                words.Add("word");
            }
            words.Add("another");
            reader.ReadWords().Returns(words);
            var tags = creator.CreateTags().Value;
            tags.All(x => x.Size.Width >= 10).Should().BeTrue();
            tags.All(x => x.Size.Height >= 20).Should().BeTrue();
        }
    }
}