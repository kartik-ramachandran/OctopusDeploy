namespace OctopusDeploy.Deploy.Json.Domain
{
    public class DevopsDeploy
    {
        public List<Deployments> Deployments { get; set; }  
        public List<Projects> Projects { get; set; }
        public List<Environments> Environments { get; set; }
        public List<Releases> Releases { get; set; }
    }
}
