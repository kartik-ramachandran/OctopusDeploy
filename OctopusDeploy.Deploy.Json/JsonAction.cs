using OctopusDeploy.Deploy.Json.Domain;
using System.Text.Json;

namespace OctopusDeploy.Deploy.Json
{
    public class JsonAction : IJsonAction
    {
        public void ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<Deployments> ReadDeployments(string jsonFilePath)
        {
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<Deployments>>(json);
            }
        }

        public List<Environments> ReadEnv(string jsonFilePath)
        {
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<Environments>>(json);
            }
        }

        public List<Projects> ReadProjects(string jsonFilePath)
        {
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<Projects>>(json);
            }
        }

        public List<Releases> ReadReleases(string jsonFilePath)
        {
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<Releases>>(json);
            }
        }

        public void WriteDeployments(List<Deployments> deploymentsList, string jsonFilePath)
        {
            using (StreamWriter r = new StreamWriter(jsonFilePath))
            {
                var serializedPlayerDetails = JsonSerializer.Serialize<List<Deployments>>(deploymentsList);
                r.Write(serializedPlayerDetails);
            }
        }

        public void WriteEnv(List<Environments> envList, string jsonFilePath)
        {
            using (StreamWriter r = new StreamWriter(jsonFilePath))
            {
                var serializedPlayerDetails = JsonSerializer.Serialize<List<Environments>>(envList);
                r.Write(serializedPlayerDetails);
            }
        }

        public void WriteProjects(List<Projects> projectsList, string jsonFilePath)
        {
            using (StreamWriter r = new StreamWriter(jsonFilePath))
            {
                var serializedPlayerDetails = JsonSerializer.Serialize<List<Projects>>(projectsList);
                r.Write(serializedPlayerDetails);
            }
        }

        public void WriteReleases(List<Releases> releasesList, string jsonFilePath)
        {
            using (StreamWriter r = new StreamWriter(jsonFilePath))
            {
                var serializedPlayerDetails = JsonSerializer.Serialize<List<Releases>>(releasesList);
                r.Write(serializedPlayerDetails);
            }
        }
    }
}
