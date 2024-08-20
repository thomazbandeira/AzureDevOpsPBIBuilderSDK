using AzureDevOps.Model.Enum;
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
        public async Task WhenExecuteCreateWorkItemAsyncEnum()
        {
            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }

        [Fact]
        public async Task WhenExecuteGetWorkItemsAsyncEnum()
        {
            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }
        [Fact]
        public async Task WhenExecuteGetWorkItemAsyncEnum()
        {
            await _azureDevOpsService.GetWorkItemAsync(1);

            // Arrange
            // Setup your mock and test data here

            // Act
            // Call the method you want to test here

            // Assert
            // Verify the results here
        }
        [Fact]
        public async Task WhenExecuteDeleteWorkItemAsyncEnum()
        {
           await _azureDevOpsService.DeleteWorkItemAsync(1);

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
            await _azureDevOpsService.UpdateWorkItemAsync(1, "title2", "description2");

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