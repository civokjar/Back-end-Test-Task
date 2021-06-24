using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelightShop.Ninject.Modules
{
    public class StoreModule : NinjectModule  
    {  
        public override void Load()
        {
            Kernel?.Bind<ICart>().To<Cart>().InThreadScope();
            Kernel?.Bind<ICheckout>().To<Checkout>().InThreadScope();
            Kernel?.Bind<IStore>().To<Store>().InThreadScope();
        }
  
     }
}
