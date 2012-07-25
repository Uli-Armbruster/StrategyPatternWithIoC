using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using StrategyPattern.Contracts;

namespace StrategyPatternV2
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (!container.Kernel.GetFacilities().Any(x => x is TypedFactoryFacility))
            {
                container.AddFacility<TypedFactoryFacility>();
            }
            container.Register(Components().ToArray());
        }

        private IEnumerable<IRegistration> Components()
        {
            yield return Component.For<IchErmittleArtikelStatus>()
                .ImplementedBy<Artikelstatusberechnung>()
                .LifestyleTransient();
            yield return Component.For<IchKenneDasBusiness>()
                .ImplementedBy<Geschäftslogik>()
                .LifestyleTransient();
            yield return Component.For<IchVermittleVorschlagsrechner>()
                .ImplementedBy<Vorschlagsrechner>()
                .LifestyleTransient();
        }
    }
}