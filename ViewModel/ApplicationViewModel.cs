using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HowWordsRepeat
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IInputString inputString;
        private readonly IWordsFrequency wordsFrequency;

        public ObservableCollection<Word> FreqWords { get; set; }


        public ApplicationViewModel(IInputString inputString, IWordsFrequency wordsFrequency)
        {
            this.inputString = inputString;
            this.wordsFrequency = wordsFrequency;
            FreqWords = new ObservableCollection<Word>();
        }

        private RelayCommand readStringsGetFreqWords;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand ReadStringsGetFreqWords
        {
            get
            {
                return readStringsGetFreqWords ??
                    (
                    readStringsGetFreqWords = new RelayCommand(obj =>
                    {
                        // Получить отсортированную коллекцию частоты слов
                        List<string> inString = inputString.GetStrings();
                        if (inString == null)
                            return;          // !!!

                        var words = wordsFrequency.GetFrequencyWords(inString);

                        // Инициализировать коллекцию для view
                        if (FreqWords == null)
                            FreqWords = new ObservableCollection<Word>();

                        FreqWords.Clear();
                        foreach (var w in words)
                            FreqWords.Add(w);
                    }));
            }
        }
    }
}
