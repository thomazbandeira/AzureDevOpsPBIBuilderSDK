using AzureDevOpsUtils.Interfaces;
using Moq;
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
        public async void WhenExecuteCreateWorkItemAsyncEnum()
        {
            await _azureDevOpsManager.CreateWorkItemAsync(Enums.WorkItemTypeEnum.Task,"Title","Description").ConfigureAwait(false);

            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }

        [Fact]
        public async void WhenExecuteGetWorkItemsAsyncEnum()
        {
            await _azureDevOpsManager.GetWorkItemsAsync(Enums.WorkItemTypeEnum.Task).ConfigureAwait(false);

            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }
        [Fact]
        public async void WhenExecuteGetWorkItemAsyncEnum()
        {
            await _azureDevOpsManager.GetWorkItemAsync(1).ConfigureAwait(false);

            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }
        [Fact]
        public async void WhenExecuteDeleteWorkItemAsyncEnum()
        {
            await _azureDevOpsManager.DeleteWorkItemAsync(1).ConfigureAwait(false);

            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }
        [Fact]
        public async void WhenExecuteUpdateWorkItemAsyncEnum()
        {
            await _azureDevOpsManager.UpdateWorkItemAsync(1, "title2", "description2").ConfigureAwait(false);

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