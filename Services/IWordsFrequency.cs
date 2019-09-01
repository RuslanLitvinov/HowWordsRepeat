using System.Collections.Generic;

namespace HowWordsRepeat
{
    public interface IWordsFrequency
    {
        List<Word> GetFrequencyWords(List<string> stringList);
    }
}