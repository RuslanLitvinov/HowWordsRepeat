using System.Windows;

namespace HowWordsRepeat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new TextFileStrings(), new WordsCount());
        }
    }
}
