using OctopusDeploy.Deploy.Domain;

namespace OctopusDeploy.Deploy.Business.Interfaces
{
    public interface IDeployAction
    {
        void FetchProjectData(List<ProjectEnvironment> projectEnvironments);
        void DeleteOldDeployment();
        void IsReleaseDeployed();
    }
}
