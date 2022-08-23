using Microsoft.Extensions.DependencyInjection;
using OctopusDeploy.Deploy.Data.Interface;
using OctopusDeploy.Deploy.Data.Implementation;
using OctopusDeploy.Deploy.Json;
using OctopusDeploy.Deploy.Business.Implementation;
using OctopusDeploy.Deploy.Business.Interfaces;
using OctopusDeploy.Deploy.Domain;
using OctopusDeploy.Deploy.Logging;

namespace OctopusDeploy.Deploy.UnitTest
{
    public class InitialSetup
    {
        public ServiceProvider CreateServiceCollection()
        {
            var services = new ServiceCollection();

            services.AddTransient<ICustomLogger, CustomLogger>();
            services.AddTransient<IJsonAction, JsonAction>();
            services.AddTransient<IRead, Read>();
            services.AddTransient<IWrite, Write>();
            services.AddTransient<IDeployAction, DeployAction>();            

            return services.BuildServiceProvider();
        }

        public string BaseTestFilePath { get { return @"D:\TestData\"; } }
        public string DeploymentFileName { get { return BaseTestFilePath + "Deployments.json"; } }
        public string ReleaseFileName { get { return BaseTestFilePath + "Releases.json"; } }
        public string ProjectFileName { get { return BaseTestFilePath + "Projects.json"; } }
        public string EnvironmentFileName { get { return BaseTestFilePath + "Environments.json"; } }

        public string ProjectId1 { get { return "Project-1"; } }
        public string ProjectId2 { get { return "Project-2"; } }

        public List<ProjectEnvironment> ProjectEnvironments
        {
            get
            {
                return new List<ProjectEnvironment>
                {
                    new ProjectEnvironment
                    {
                        ProjectId = ProjectId1,
                        EnvironmentIds = new List<string>
                        {
                            "Environment-1"
                        }
                    }
                };
            }
        }

        public List<ProjectEnvironment> ProjectEnvironments1
        {
            get
            {
                return new List<ProjectEnvironment>
                {
                    new ProjectEnvironment
                    {
                        ProjectId = ProjectId2,
                        EnvironmentIds = new List<string>
                        {
                            "Environment-1",
                            "Environment-2"
                        }
                    }
                };
            }
        }
    }
}
