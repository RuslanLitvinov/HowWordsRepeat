using Ninject;
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
            NinjectContext.SetUp();
            DataContext = NinjectContext.Kernel.Get<ApplicationViewModel>();
        }
    }
}
