using OctopusDeploy.Deploy.Json.Domain;

namespace OctopusDeploy.Deploy.Json
{
    public interface IJsonAction
    {
        List<Deployments> ReadDeployments(string jsonFilePath);
        List<Environments> ReadEnv(string jsonFilePath);
        List<Projects> ReadProjects(string jsonFilePath);
        List<Releases> ReadReleases(string jsonFilePath);
        void ReadAll();
        void WriteDeployments(List<Deployments> deploymentsList, string jsonFilePath);
        void WriteEnv(List<Environments> deploymentsList, string jsonFilePath);
        void WriteProjects(List<Projects> deploymentsList, string jsonFilePath);   
        void WriteReleases(List<Releases> deploymentsList, string jsonFilePath);
    }
}
