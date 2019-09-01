using System;
using System.Collections.Generic;
using System.Linq;
using HowWordsRepeat;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repeat
{
    [TestClass]
    public class UnitTestRepeat
    {
        private void CompareCollection(List<Word> a, List<Word> b)
        {
            if (a.Count != b.Count)
            {
                Console.WriteLine("Число элементов коллекций неодинаковое");
                Assert.AreEqual(true, false);
            }
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Key != b[i].Key ||
                    a[i].Number != b[i].Number)
                {
                    Console.WriteLine($"элемент <{a[i].Key}-{a[i].Number}> не равен <{b[i].Key}-{b[i].Number}>");
                    Assert.AreEqual(true, false);
                }
            }
        }
        [TestMethod]
        public void HowRepeatWords()
        {
            string inputString = "это слово это   слово слово это Встречается";
            // Функционал
            List<Word> actualWords = Text.StringRepetWords(inputString);
            actualWords = Text.OrderByDescending(actualWords);

            // Образец
            List<Word> expectedWords = new List<Word>()
            {
                new Word(){ Key = "слово", Number = 3},
                new Word(){ Key = "это", Number = 3},
                new Word(){ Key = "встречается", Number = 1}
            };
            // Проверка
            CompareCollection(expectedWords, actualWords);

            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void HowManyDifferentWords()
        {
            string inputString = "это слово это слово это встречается";
            List<Word> wordsRepeat = Text.StringRepetWords(inputString);

            Assert.AreEqual(3, wordsRepeat.Count);
        }
        [TestMethod]
        public void AddStringСorrectly()
        {
            // Получаем коллекцию
            string inputString1 = "слово наше слово наше  встретилось";
            List<Word> words = Text.StringRepetWords(inputString1);
            string inputString2 = "встретилось наше  встретилось снова Встретилось слово ";
            words = Text.StringRepetWords(inputString2, words);
            // Обязательно сортировку
            words = Text.OrderByDescending(words);
            // Образец
            List<Word> expectedWords = new List<Word>()
            {
                new Word(){ Key = "встретилось", Number = 4},
                new Word(){ Key = "наше", Number = 3},
                new Word(){ Key = "слово", Number = 3},
                new Word(){ Key = "снова", Number = 1},
            };
            // Проверка
            Text.OutPut(words, "полученная");
            Text.OutPut(expectedWords, "образец");
            CompareCollection(expectedWords, words);
            Assert.AreEqual(true, true);

        }
    }
}
