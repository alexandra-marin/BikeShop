using Ninject;

namespace BikeDistributor
{
    public class Startup
    {
        public static StandardKernel Kernel;

        public static void Main()
        {
            SetupKernel();
        }

        private static void SetupKernel()
        {
            var bindings = new Bindings();

            Kernel = new StandardKernel(bindings);
        }
    }
}
