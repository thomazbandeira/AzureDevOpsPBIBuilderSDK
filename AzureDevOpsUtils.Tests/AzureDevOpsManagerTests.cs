using AzureDevOps.Model.Enum;
using AzureDevOpsUtils.Interfaces;
using Moq;
using System.Threading;
namespace AzureDevOpsUtils.Tests
{
    public class AzureDevOpsManagerTests
    {
        private readonly Mock<IAzureDevOpsService> _azureDevOpsServiceMock;
        private readonly AzureDevOpsManager _azureDevOpsManager;

        public AzureDevOpsManagerTests()
        {
            _azureDevOpsServiceMock = new Mock<IAzureDevOpsService>();
            _azureDevOpsManager = new AzureDevOpsManager(_azureDevOpsServiceMock.Object);
        }

        [Fact]
        public async Task WhenExecuteCreateWorkItemAsyncEnum()
        {
            #region Arrange
            // Arrange
            // Setup your mock and test data here
            _azureDevOpsServiceMock.Setup(setup =>
            setup.CreateWorkItemAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<int?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem()
                {
                    Id = 1,
                    Fields = new Dictionary<string, object>()
                {
                    { "System.Title", "Title" },
                    { "System.Description", "Description" }
                },
                    Url = "http://url"
                });
            #endregion Arrange

            #region Act
            // Act
            // Call the method you want to test here
            var tested = await _azureDevOpsManager.CreateWorkItemAsync(WorkItemTypeEnum.Task, "Title", "Description");
            #endregion Act

            #region Assert
            // Assert
            // Verify the results here
            Assert.NotNull(tested);
            Assert.Equal(1, tested.Id);
            Assert.Equal("Title", tested.Fields["System.Title"]);
            Assert.Equal("Description", tested.Fields["System.Description"]);
            Assert.Equal("http://url", tested.Url);
            #endregion
        }

        [Fact]
        public async Task WhenExecuteGetWorkItemsAsyncEnum()
        {

            #region Arrange
            // Arrange
            // Setup your mock and test data here
            _azureDevOpsServiceMock.Setup(setup =>
            setup.GetWorkItemsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem>()
                {
                    new Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem()
                    {
                        Id = 1,
                        Fields = new Dictionary<string, object>()
                        {
                            { "System.Title", "Title" },
                            { "System.Description", "Description" }
                        },
                        Url = "http://url"

                    }
                });
            #endregion Arrange

            #region Act
            // Act
            // Call the method you want to test here
            var tested = await _azureDevOpsManager.GetWorkItemsAsync(WorkItemTypeEnum.Task);
            #endregion Act

            #region Assert
            // Assert
            // Verify the results here
            Assert.NotEmpty(tested);
            #endregion Assert
        }
        [Fact]
        public async Task WhenExecuteGetWorkItemAsyncEnum()
        {
            await _azureDevOpsManager.GetWorkItemAsync(1);

            #region Arrange
            // Arrange
            // Setup your mock and test data here
            _azureDevOpsServiceMock.Setup(setup =>
            setup.GetWorkItemAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem()
                {
                    Id = 1,
                    Fields = new Dictionary<string, object>()
                    {
                        { "System.Title", "Title" },
                        { "System.Description", "Description" }
                    },
                });
            #endregion Arrange

            #region Act
            // Act
            // Call the method you want to test here
            var tested = await _azureDevOpsManager.GetWorkItemsAsync(WorkItemTypeEnum.Task);
            #endregion Act

            #region Assert
            // Assert
            // Verify the results here
            Assert.NotEmpty(tested);
            #endregion Assert
        }
        [Fact]
        public async Task WhenExecuteDeleteWorkItemAsyncEnum()
        {
            await _azureDevOpsManager.DeleteWorkItemAsync(1);

            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }
        [Fact]
        public async Task WhenExecuteUpdateWorkItemAsyncEnum()
        {
            await _azureDevOpsManager.UpdateWorkItemAsync(1, "title2", "description2");

            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }

        // Add more tests for other methods in AzureDevOpsManager
    }
}