namespace OctopusDeploy.Deploy.Domain
{
    public class Deployments
    {
        public string Id { get; set; }
        public string ReleaseId { get; set; }
        public string EnvironmentId { get; set; }
        public string DeployedAt { get; set; }
    }
}
