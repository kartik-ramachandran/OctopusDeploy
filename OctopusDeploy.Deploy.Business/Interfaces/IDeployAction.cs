using OctopusDeploy.Deploy.Domain;

namespace OctopusDeploy.Deploy.Business.Interfaces
{
    public interface IDeployAction
    {
        List<Deployments> GetAllDeployments();
        void GetAndDeleteOldDeployments(List<ProjectEnvironment> projectEnvironments);
        List<Deployments> GetAllDeploymentsForProject(string projectId);
        void SetReadWriteFilePaths(string deploymentFilePath, string releaseFilePath, string envFilePath, string projectFilePath);
    }
}
