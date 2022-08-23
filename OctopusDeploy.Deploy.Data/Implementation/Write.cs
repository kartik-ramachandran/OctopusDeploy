using OctopusDeploy.Deploy.Data.Interface;
using OctopusDeploy.Deploy.Domain;
using OctopusDeploy.Deploy.Json;

namespace OctopusDeploy.Deploy.Data.Implementation
{
    public class Write : IWrite
    {
        private readonly IJsonAction _jsonAction;
        public string? DeploymentFilePath { get; set; }
        public string? ReleaseFilePath { get; set; }
        public string? ProjectFilePath { get; set; }
        public string? EnvironmentFilePath { get; set; }

        public Write(IJsonAction jsonAction)
        {
            _jsonAction = jsonAction;
        }

        public void WriteDeployments(List<Deployments> deployments)
        {
            _jsonAction.Write<Deployments>(deployments, DeploymentFilePath);
        }

        public void WriteEnvironments(List<Environments> environments)
        {
            _jsonAction.Write<Environments>(environments, EnvironmentFilePath);
        }

        public void WriteProjects(List<Projects> projects)
        {
            _jsonAction.Write<Projects>(projects, ProjectFilePath);
        }

        public void WriteReleases(List<Releases> releases)
        {
            _jsonAction.Write<Releases>(releases, ReleaseFilePath);
        }        
    }
}
