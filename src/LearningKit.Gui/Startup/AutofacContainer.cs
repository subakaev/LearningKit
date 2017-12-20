using Autofac;

namespace LearningKit.Gui.Startup
{
    static class AutofacContainer
    {
        public static readonly IContainer Container;

        static AutofacContainer() {
            var builder = new ContainerBuilder();

            Container = builder.Build();
        }

        public static T Resolve<T>() {
            return Container.Resolve<T>();
        }
    }
}
