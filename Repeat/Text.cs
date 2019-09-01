using System;
using System.Collections.Generic;
using System.Linq;
using HowWordsRepeat;

namespace Repeat
{
    public class Text
    {
        /// <summary>
        /// Слово написанное в другом регистре считается этим же словом.
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static List<Word> StringRepetWords(string inputString, List<Word> toAdd = null)
        {
            List<Word>  wordsRepat = toAdd;

            if (wordsRepat == null)
                wordsRepat = new List<Word>();

            string[] words = inputString.ToLower().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string singleWord in words)
            {
                Word findWord = wordsRepat.Where(w => w.Key == singleWord).FirstOrDefault();
                if (findWord == null)
                {
                    wordsRepat.Add(new Word() { Key = singleWord, Number = 1 });
                }
                else
                {
                    findWord.Number++;
                }
            }

            return wordsRepat;
        }
        /// <summary>
        /// Сортирует коллекцию:
        /// частота по убыванию, 
        /// с одинаковой частотой - по алфавиту.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static List<Word> OrderByDescending(List<Word> words)
        {
            // по словам по алфавиту
            var result = words.OrderBy(w => w.Key.ToLower());
            // А по частоте в обратном порядке
            result = result.OrderByDescending(w => w.Number);

            return result.ToList();  // !!!
        }
        public static void OutPut(List<Word> words, string caption)
        {
            Console.WriteLine($"Коллекция слов {caption}:");
            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {word.Number}");
            }
        }
    }
}