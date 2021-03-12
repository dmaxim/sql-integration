
using System;
using System.Diagnostics;
using System.IO;


namespace Barney.Tests.Integration.Infrastructure.Fixtures
{
    public class IntegrationTestFixture : IDisposable
    {
        private readonly string _dockerComposeDirectory;
        private readonly bool _useDockerDependencies;

        public IntegrationTestFixture()
        {
            _useDockerDependencies = true;

            if(_useDockerDependencies)
            {
                _dockerComposeDirectory = GetDockerComposeDirectory();
                InitializeContainers();
            }

        }

        private string GetDockerComposeDirectory()
        {
           var testProjectDirectory = this.GetType().Assembly.Location;
           return $"{Path.GetDirectoryName(testProjectDirectory)}\\Infrastructure";
        }

        private void InitializeContainers()
        {


            //if (_integrationTestConfiguration.PullLatestImages)
            //{
            //    var dockerPullProcessInfo = new ProcessStartInfo("cmd.exe", "/C docker-compose pull")
            //    {
            //        WorkingDirectory = _dockerComposeDirectory,
            //        CreateNoWindow = false
            //    };
            //    var dockerPullProcess = Process.Start(dockerPullProcessInfo);

            //    dockerPullProcess.WaitForExit();

            //}


            var dockerComposeUpProcessInfo = new ProcessStartInfo("cmd.exe", "/C docker-compose up -d")
            {
                WorkingDirectory = _dockerComposeDirectory,
                CreateNoWindow = false
            };



            var dockerComposeUpProcess = Process.Start(dockerComposeUpProcessInfo);

            dockerComposeUpProcess.WaitForExit();
        }


        private void TeardownContainers()
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/C docker-compose down")
            {
                WorkingDirectory = _dockerComposeDirectory,
                CreateNoWindow = false
            };

            // Do not wait for exit as it will cause the test runner to hang
            var dockerComposeDownProcess = Process.Start(processInfo);
        }

        public void Dispose()
        {
            if(_useDockerDependencies)
            {
                TeardownContainers();
            }
            
        }
    }
}
