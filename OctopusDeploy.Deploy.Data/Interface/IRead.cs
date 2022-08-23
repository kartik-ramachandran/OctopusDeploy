using OctopusDeploy.Deploy.Domain;

namespace OctopusDeploy.Deploy.Data.Interface
{
    public interface IRead
    {
        string DeploymentFilePath { get; set; }
        string EnvironmentFilePath { get; set; }
        string ProjectFilePath { get; set; }
        string ReleaseFilePath { get; set; }

        List<Deployments> GetDeploymentsData();
        List<Deployments> GetDeploymentsForEnvironment(string environmentId);
        List<Environments> GetEnvironmentsData();
        List<Projects> GetProjectsData();
        List<Releases> GetReleasesData();
        List<Releases> GetReleasesForProject(string projectId);
        List<Deployments> GetDeploymentsForReleases(List<string> releaseIds);
    }
}
