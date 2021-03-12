

using Autofac;
using Barney.Infrastructure.Configuration;

namespace Barney.Infrastructure.DependencyInjection
{
    public static class DependencyBuilderFactory
    {
        public static ContainerBuilder Create(BarneyAppConfiguration webUiConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreModule(webUiConfiguration));

            return builder;
        }
    }
}
