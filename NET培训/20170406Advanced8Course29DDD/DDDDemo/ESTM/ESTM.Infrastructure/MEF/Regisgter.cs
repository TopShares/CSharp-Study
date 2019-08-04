using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Infrastructure.MEF
{
    public class Regisgter
    {
        public static CompositionContainer regisgter()
        {
            try
            {
                AggregateCatalog aggregateCatalog = new AggregateCatalog();
                string path = AppDomain.CurrentDomain.BaseDirectory;
                var thisAssembly = new DirectoryCatalog(path, "*.dll");
                if (thisAssembly.Count() == 0)
                {
                    path = path + "bin\\";
                    thisAssembly = new DirectoryCatalog(path, "*.dll");
                }
                aggregateCatalog.Catalogs.Add(thisAssembly);
               var _container = new CompositionContainer(aggregateCatalog);
               return _container;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
