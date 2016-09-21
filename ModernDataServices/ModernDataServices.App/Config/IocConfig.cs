using StructureMap;

namespace ModernDataServices.App.Config
{
    /// <summary>
    /// Structuremap IOC Container Setup
    /// </summary>
    public static class IocConfig
    {
        /// <summary>
        /// Gets or sets the container (private).
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container { get; set; }


        /// <summary>
        /// Gets or builds the container 
        /// </summary>
        /// <returns></returns>
        public static IContainer UseIoc()
        {
            return Container ?? BuildContainer();
        }

        /// <summary>
        /// Builds the container (private).
        /// </summary>
        /// <returns></returns>
        private static IContainer BuildContainer()
        {
            Container = new Container(c =>
            {

                c.Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.LookForRegistries();
                    s.WithDefaultConventions();
                });

            });

            return Container;
        }
    }
}
