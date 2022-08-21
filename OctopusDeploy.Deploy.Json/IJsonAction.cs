namespace OctopusDeploy.Deploy.Json
{
    public interface IJsonAction
    {
        List<T> Read<T>(string jsonFilePath);
        void ReadAll();
        void Write<T>(List<T> deploymentsList, string jsonFilePath);
    }
}
