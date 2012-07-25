using System.Linq;
using System.Reflection;
using Castle.Facilities.TypedFactory;

using StrategyPattern.Contracts;

namespace StrategyPattern.V3
{
    public class VorschlagsrechnerVermittler : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            if (method.Name == "Für" && arguments.Length == 1 && arguments[0] is Bestandsstatus)
            {
                var status = arguments[0].ToString();
                //von mir frei gewählte Konvention wie die Komponente im Container heißt
                return string.Format("BerechnerFürArtikelstatus{0}", status);
            }
            return base.GetComponentName(method, arguments);
        }
    }
}