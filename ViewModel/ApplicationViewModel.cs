using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWordsRepeat
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IInputString inputString;
        private readonly IWordsFrequency wordsFrequency;

        public ObservableCollection<Word> freqWords { get; set; }


        public ApplicationViewModel(IInputString inputString, IWordsFrequency wordsFrequency)
        {
            this.inputString = inputString;
            this.wordsFrequency = wordsFrequency;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommand readStringsGetFreqWords;
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
                        var words = wordsFrequency.GetFrequencyWords(inString);

                        // Инициализировать коллекцию для view
                        if (freqWords == null)
                            freqWords = new ObservableCollection<Word>();

                        freqWords.Clear();
                        foreach (var w in words)
                            freqWords.Add(w);
                    }));
            }
        }
    }
}
