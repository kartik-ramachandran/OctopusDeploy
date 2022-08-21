namespace OctopusDeploy.Deploy.Data.Interface
{
    public interface IWrite
    {
        void AddDeployments();
        void AddProjects();
        void AddReleases();
        void AddEnvironments();
        void RemoveEnvironments();
        void RemoveProjects();
        void RemoveReleases();
        void RemoveDeployments();
        void UpdateProjectData();
        void UpdateEnvironmentData();
        void UpdateReleaseData();
        void UpdateDeploymentData();
    }
}
