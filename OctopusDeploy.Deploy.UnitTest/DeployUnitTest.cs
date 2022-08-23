using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OctopusDeploy.Deploy.Business.Interfaces;

namespace OctopusDeploy.Deploy.UnitTest
{
    public class Tests
    {
        private ServiceProvider _serviceprovider;
        private IDeployAction _action;
        private InitialSetup _initialize;

        [SetUp]
        public void Setup()
        {
            _initialize = new InitialSetup();

            _serviceprovider = _initialize.CreateServiceCollection();

            _action = _serviceprovider.GetService<IDeployAction>();

            _action?.SetReadWriteFilePaths(_initialize.DeploymentFileName,
                _initialize.ReleaseFileName, _initialize.EnvironmentFileName, _initialize.ProjectFileName);
        }

        [Test]
        public void GetAllDeployments_Success()
        {
            var allDeployments = _action.GetAllDeployments();

            allDeployments.Should().HaveCountGreaterThan(1);
        }

        [Test]
        public void DeleteOldDeployments_ForProject1_Success()
        {
            var deploymentsBeforeDelete = _action.GetAllDeploymentsForProject(_initialize.ProjectId1);

            _action.GetAndDeleteOldDeployments(_initialize.ProjectEnvironments);

            var deploymentsAfterDelete = _action.GetAllDeploymentsForProject(_initialize.ProjectId1);

            deploymentsBeforeDelete.Should().HaveCountGreaterThan(deploymentsAfterDelete.Count);
        }

        [Test]
        public void DeleteTwoOldDeployments_ForProject1_Success()
        {
            var deploymentsBeforeDelete = _action.GetAllDeploymentsForProject(_initialize.ProjectId2);

            _action.GetAndDeleteOldDeployments(_initialize.ProjectEnvironments1);

            var deploymentsAfterDelete = _action.GetAllDeploymentsForProject(_initialize.ProjectId2);

            deploymentsBeforeDelete.Should().HaveCountGreaterThan(deploymentsAfterDelete.Count);
        }
    }
}