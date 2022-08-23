using OctopusDeploy.Deploy.Business.Interfaces;
using OctopusDeploy.Deploy.Data.Interface;
using OctopusDeploy.Deploy.Domain;
using OctopusDeploy.Deploy.Logging;

namespace OctopusDeploy.Deploy.Business.Implementation
{
    public class DeployAction : IDeployAction
    {
        private readonly IRead _read;
        private readonly IWrite _write;
        private readonly ICustomLogger _logger;

        public DeployAction(IRead read, IWrite write, ICustomLogger logger)
        {
            _read = read;
            _write = write;
            _logger = logger;
        }
        public void SetReadWriteFilePaths(string deploymentFilePath,
                                           string releaseFilePath,
                                           string envFilePath,
                                           string projectFilePath)
        {
            _read.DeploymentFilePath = _write.DeploymentFilePath = deploymentFilePath;
            _read.ReleaseFilePath = _write.ReleaseFilePath = releaseFilePath;
            _read.EnvironmentFilePath = _write.EnvironmentFilePath = envFilePath;
            _read.ProjectFilePath = _write.ProjectFilePath = projectFilePath;
        }

        public void GetAndDeleteOldDeployments(List<ProjectEnvironment> projectEnvironments)
        {
            projectEnvironments.ForEach(pe =>
            {
                var descSortedDeployments = GetDescSortedDeployments(pe.ProjectId);

                pe.EnvironmentIds.ForEach(env => {
                    DeleteOldDeployment(env, descSortedDeployments);
                });               
            });
        }

        private void DeleteOldDeployment(string envId, List<Deployments> deployments)
        {
            var filteredDeployment = deployments.FindAll(d => d.EnvironmentId.Equals(envId));

            _logger.LogInfo($"Keep deployment at {filteredDeployment[0].Id} as it the latest deployment");

            filteredDeployment.RemoveAt(0);

            if (filteredDeployment.Count > 0)
            {
                var allDeployments = GetAllDeployments();

                filteredDeployment.ForEach(dep =>
                {
                    RemoveDeployments(dep.Id, allDeployments);
                });

                _write.WriteDeployments(allDeployments);
            }
        }

        public List<Deployments> GetAllDeployments()
        {
            return _read.GetDeploymentsData();
        }

        public List<Deployments> GetAllDeploymentsForProject(string projectId)
        {
            return GetDescSortedDeployments(projectId);
        }

        private void RemoveDeployments(string deploymentId, List<Deployments> allDeployments)
        {
            var itemToRemove = allDeployments.Single(ad => ad.Id == deploymentId);
            allDeployments.Remove(itemToRemove);
        }

        private List<Deployments> GetDescSortedDeployments(string projectId)
        {
            var releases = _read.GetReleasesForProject(projectId);

            var deployments = _read.GetDeploymentsForReleases(releases.Select(p => p.Id).ToList());

            return deployments.OrderByDescending(d => DateTime.Parse(d.DeployedAt)).ToList();
        }
    }
}
