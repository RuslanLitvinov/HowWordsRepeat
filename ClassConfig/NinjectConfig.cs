using Ninject.Modules;

namespace HowWordsRepeat
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IWordsFrequency>().To<WordsCount>();
            Bind<IInputString>().To<TextFileStrings>();
            Bind<ApplicationViewModel>().ToSelf();
        }
    }
}
