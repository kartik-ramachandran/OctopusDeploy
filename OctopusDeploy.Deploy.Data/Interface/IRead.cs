namespace OctopusDeploy.Deploy.Data.Interface
{
    public interface IRead
    {
        void GetDeploymentsData();
        void GetReleasesData();
        void GetProjectsData();
        void GetEnvironmentsData();
        void GetReleasesForProject(string projectId);
        void GetDeploymentsForEnvironment(string environmentId);
    }
}
