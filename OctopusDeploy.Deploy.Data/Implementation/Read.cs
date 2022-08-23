using OctopusDeploy.Deploy.Data.Interface;
using OctopusDeploy.Deploy.Domain;
using OctopusDeploy.Deploy.Json;

namespace OctopusDeploy.Deploy.Data.Implementation
{
    public class Read : IRead
    {
        private readonly IJsonAction _jsonAction;
        public string? DeploymentFilePath { get; set; }
        public string? ReleaseFilePath { get; set; }
        public string? ProjectFilePath { get; set; }
        public string? EnvironmentFilePath { get; set; }

        public Read(IJsonAction jsonAction)
        {
            _jsonAction = jsonAction;
        }

        public List<Deployments> GetDeploymentsData()
        {
            return _jsonAction.Read<Deployments>(DeploymentFilePath);
        }

        public List<Deployments> GetDeploymentsForEnvironment(string environmentId)
        {
            var deployments = GetDeploymentsData();

            var filteredDeployments = deployments.FindAll(d => d.EnvironmentId.Equals(environmentId));

            return filteredDeployments;
        }

        public List<Deployments> GetDeploymentsForReleases(List<string> releaseIds)
        {
            var deployments = GetDeploymentsData();

            var filteredDeployments = deployments.FindAll(d => releaseIds.Contains(d.ReleaseId));

            return filteredDeployments;
        }

        public List<Environments> GetEnvironmentsData()
        {
            return _jsonAction.Read<Environments>(EnvironmentFilePath);
        }

        public List<Projects> GetProjectsData()
        {
            return _jsonAction.Read<Projects>(ProjectFilePath);
        }

        public List<Releases> GetReleasesData()
        {
            return _jsonAction.Read<Releases>(ReleaseFilePath);
        }

        public List<Releases> GetReleasesForProject(string projectId)
        {
            var releases = GetReleasesData();

            var filteredReleases = releases.FindAll(d => d.ProjectId.Equals(projectId));

            return filteredReleases;
        }
    }
}
