﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Tool
{
    public class SimpleTagsCreator : ITagsCreator
    {
        public readonly Size DefaultSize = new Size(100, 50);

        private readonly IWordProvider provider;

        public SimpleTagsCreator(IWordProvider provider)
        {
            this.provider = provider;
        }

        public Result<IEnumerable<Tag>> CreateTags(int maxCount = 100)
        {
            var result = provider.GetWords();
            return !result.IsSuccess ?
                Result.Fail<IEnumerable<Tag>>(result.Error) :
                Result.Ok(CreateTags(maxCount, result.Value));
        }

        private IEnumerable<Tag> CreateTags(int maxCount, IEnumerable<string> words)
        {
            var statistic = GetFrequecncy(words).OrderByDescending(x => x.Value).Take(maxCount).ToList();
            foreach (var stat in statistic)
            {
                var minSize = DefaultSize;
                var freq = stat.Value;
                var relevance = 1 + freq * 10;
                var height = (int) Math.Round(minSize.Height * relevance);
                var width = (int) Math.Round(minSize.Width * relevance);
                var tag = new Tag(new Size(width, height), stat.Key);
                yield return tag;
            }
        }

        private Dictionary<string, double> GetFrequecncy(IEnumerable<string> words)
        {
            var frequency = new Dictionary<string, double>();
            var wordsCount = 0;
            foreach (var word in words)
            {
                wordsCount++;
                if (frequency.ContainsKey(word))
                    frequency[word] += 1;
                else
                    frequency.Add(word, 1);
            }
            var keys = new List<string>(frequency.Keys);
            foreach (var key in keys)
                frequency[key] /= wordsCount;
            return frequency;
        }
    }
}