using System.Collections.Generic;
using System.Linq;

using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using StrategyPattern.Contracts;

namespace StrategyPattern.V3
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

            //yield return Component.For<IchErrechneArtikelZukaufsvorschlag>()
            //    .ImplementedBy<Ok>()
            //    .Named("StatusOk")
            //    .LifestyleTransient();

            //yield return Component.For<IchErrechneArtikelZukaufsvorschlag>()
            //    .ImplementedBy<Warnung>()
            //    .Named("StatusWarnung")
            //    .LifestyleTransient();

            //yield return Component.For<IchErrechneArtikelZukaufsvorschlag>()
            //    .ImplementedBy<Deckungslücke>()
            //    .Named("StatusDeckungslücke")
            //    .LifestyleTransient();

            //yield return Component.For<IchErrechneArtikelZukaufsvorschlag>()
            //    .ImplementedBy<AkuteDeckungslücke>()
            //    .Named("StatusAkuteDeckungslücke")
            //    .LifestyleTransient();



            yield return AllTypes.FromThisAssembly()
                .BasedOn<IchErrechneArtikelZukaufsvorschlag>()
                .Configure(a => a.Named(string.Format("BerechnerFürArtikelstatus{0}",
                    a.Implementation.UnderlyingSystemType.Name)))
                .Configure(a => a.LifestyleTransient());

            yield return Component
                .For<IchVermittleVorschlagsrechner>()
                .AsFactory(c => c.SelectedWith(new VorschlagsrechnerVermittler()));
        }
    }
}