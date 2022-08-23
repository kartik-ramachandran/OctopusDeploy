using OctopusDeploy.Deploy.Domain;

namespace OctopusDeploy.Deploy.Data.Interface
{
    public interface IWrite
    {
        string? DeploymentFilePath { get; set; }
        string? EnvironmentFilePath { get; set; }
        string? ProjectFilePath { get; set; }
        string? ReleaseFilePath { get; set; }

        void WriteDeployments(List<Deployments> deployments);
        void WriteEnvironments(List<Environments> environments);
        void WriteProjects(List<Projects> projects);
        void WriteReleases(List<Releases> releases);
       
    }
}
