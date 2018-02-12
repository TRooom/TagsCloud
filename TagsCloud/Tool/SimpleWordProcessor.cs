using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Tool
{
    public class SimpleWordProcessor : IWordProcessor
    {
        private readonly List<Predicate<string>> excluded;

        public Func<string, string> Convertion { get; set; }

        public SimpleWordProcessor()
        {
            Convertion = x => x;
            excluded = new List<Predicate<string>>();
        }

        public void AddExcludingRule(Predicate<string> boringWords)
        {
            excluded.Add(boringWords);
        }

        public Result<IEnumerable<string>> ProcessWords(Result<IEnumerable<string>> result)
        {
            if (!result.IsSuccess)
                return Result.Fail<IEnumerable<string>>(result.Error);
            var words = result.Value;
            return Result.Of(() => words
                .Where(word =>
                    !(string.IsNullOrEmpty(word) ||
                      string.IsNullOrWhiteSpace(word) ||
                      IsExcluded(word)))
                .Select(word => Convertion(word.Trim().ToLower())));
        }

        private bool IsExcluded(string word)
        {
            return excluded.Any(x => x(word));
        }
    }
}