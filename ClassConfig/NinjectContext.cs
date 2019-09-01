using Ninject;

namespace HowWordsRepeat
{
    /// <summary>
    /// Хранение ядра для всего проекта
    /// </summary>
    public static class NinjectContext
    {
        public static IKernel Kernel { get; private set; }
        /// <summary>
        /// Для получения один раз ядра на старт программы.
        /// </summary>
        /// <returns></returns>
        public static void SetUp()
        {
            Kernel = new StandardKernel(new NinjectConfig());
        }
    }
}
