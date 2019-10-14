using System;
using System.Windows.Forms;
using CommonLibrary.PlayingCardFactory;
using SimpleInjector;

namespace SimpleWinForm
{
    internal static class Program
    {
        internal static bool IsForm2Loaded = false;
        private static Container _container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(_container.GetInstance<Form1>());
        }

        private static void Bootstrap()
        {
            _container = new Container();
            _container.Register<IPlayingCardFactory, PlayingCardFactory>(Lifestyle.Singleton);     //.Scoped);
            _container.Register<Form1>(Lifestyle.Singleton);
            // Optionally verify the container.
            _container.Verify();
        }
    }
}