using System.Collections.Generic;

namespace HowWordsRepeat
{
    public class WordsCount : IWordsFrequency
    {
        public List<Word> GetFrequencyWords(List<string> stringList)
        {
            List<Word> words = new List<Word>();

            foreach (var s in stringList)
                words = Text.StringRepetWords(s, words);

            // Обязательно сортировку
            words = Text.OrderByDescending(words);

            return words;          // !!!
        }
    }
}
