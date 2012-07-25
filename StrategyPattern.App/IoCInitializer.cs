using System;
using System.IO;
using System.Reflection;

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace StrategyPattern.App
{
    public class IoCInitializer : IDisposable
    {
        public IoCInitializer()
        {
            Container = new WindsorContainer();
        }

        public IWindsorContainer Container { get; private set; }

        public void Dispose()
        {
            if (Container != null)
            {
                Container.Dispose();
                Container = null;
            }
        }

        public IoCInitializer RegisterComponents()
        {
            var appDomainDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var foundAssemblies = FromAssembly.InDirectory(new AssemblyFilter(appDomainDirectory));
            Container.Install(foundAssemblies);
            Container.Register(Component.For<IWindsorContainer>().Instance(Container));

            return this;
        }
    }
}