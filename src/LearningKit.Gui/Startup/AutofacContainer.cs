using Autofac;
using LearningKit.Gui.Pages;
using LearningKit.Gui.Services;
using LearningKit.Gui.ViewModels;

namespace LearningKit.Gui.Startup
{
    static class AutofacContainer
    {
        public static readonly IContainer Container;

        static AutofacContainer() {
            var builder = new ContainerBuilder();

            builder.RegisterType<Navigator>().As<INavigationService>().InstancePerLifetimeScope();
            builder.RegisterType<DialogService>().As<IDialogService>();

            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MainPage>().AsSelf();

            Container = builder.Build();
        }

        public static T Resolve<T>() {
            return Container.Resolve<T>();
        }
    }
}
