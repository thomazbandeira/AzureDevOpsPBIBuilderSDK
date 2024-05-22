using AzureDevOpsUtils.Interfaces;
using Moq;
namespace AzureDevOpsUtils.Tests
{
    public class AzureDevOpsServiceTests
    {
        private readonly IAzureDevOpsService _azureDevOpsService;

        public AzureDevOpsServiceTests()
        {
            
            //_azureDevOpsService = new ;
        }

        [Fact]
        public async void WhenExecuteCreateWorkItemAsyncEnum()
        {
            await _azureDevOpsService.CreateWorkItemAsync(Enums.WorkItemTypeEnum.Task, "Title", "Description").ConfigureAwait(false);

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
            await _azureDevOpsService.GetWorkItemsAsync(Enums.WorkItemTypeEnum.Task).ConfigureAwait(false);

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
            await _azureDevOpsService.GetWorkItemAsync(1).ConfigureAwait(false);

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
            await _azureDevOpsService.DeleteWorkItemAsync(1).ConfigureAwait(false);

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
            await _azureDevOpsService.UpdateWorkItemAsync(1, "title2", "description2").ConfigureAwait(false);

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