
using Autofac;
using Barney.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Barney.Tests.Integration.Infrastructure.Fixtures
{
    public class DependencyFixture : IDisposable
    {
        private readonly IContainer _dependencyContainer = null;
        private readonly IConfigurationRoot _configuration;

        public DependencyFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.secrets.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
            InitializeConfiguration();
            _dependencyContainer = CreateContainer();
        }

        public IntegrationTestConfiguration TestConfiguration { get; private set; }

                /// <summary>
        /// Respolve the specified Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return _dependencyContainer.Resolve<T>();

        }

        private void InitializeConfiguration()
        {
            var testConfiguration = new IntegrationTestConfiguration();
            _configuration.GetSection("IntegrationTests").Bind(testConfiguration);
            TestConfiguration = testConfiguration;
        }
        private IContainer CreateContainer()
        {
            var webUiConfiguration = new Barney.Infrastructure.Configuration.BarneyAppConfiguration(TestConfiguration.EntityContext);
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreModule(webUiConfiguration));
            return builder.Build();

        }

        /// <inheritdoc />
        /// <summary>
        /// Do not call dispose until the unit tests that use any dependencies are completed
        /// </summary>
        public void Dispose()
        {
            _dependencyContainer?.Dispose();
        }
    }

    
}
