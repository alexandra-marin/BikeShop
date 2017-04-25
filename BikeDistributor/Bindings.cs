using Ninject.Modules;

namespace BikeDistributor
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<DiscountConfiguration>().To<DiscountConfiguration>().InSingletonScope();
            Bind<DiscountedPrice>().To<DiscountedPrice>().InSingletonScope();
        }
    }
}
