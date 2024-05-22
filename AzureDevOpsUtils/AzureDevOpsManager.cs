using AzureDevOpsUtils.Enums;
using AzureDevOpsUtils.Interfaces;
using AzureDevOpsUtils.Services;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;

namespace AzureDevOpsUtils
{
    public class AzureDevOpsManager
    {
        private readonly IAzureDevOpsService _azureDevOpsService;
        

        public AzureDevOpsManager(IAzureDevOpsService azureDevOpsService)
        {
            _azureDevOpsService = azureDevOpsService;
        }
        public async Task<WorkItem> CreateWorkItemAsync(WorkItemTypeEnum workItemType, string title, string description=null, string discursion=null, string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
            return await _azureDevOpsService.CreateWorkItemAsync(workItemType.ToString().Replace("_", " "), title, description, discursion,tags, parentWorkItemId, cancellationToken).ConfigureAwait(false);
        }
        public async Task<List<WorkItem>> GetWorkItemsAsync(WorkItemTypeEnum workItemType, CancellationToken cancellationToken = default)
        {
            return await _azureDevOpsService.GetWorkItemsAsync(workItemType.ToString().Replace("_", " "), cancellationToken).ConfigureAwait(false);
        }

        public async Task<WorkItem> UpdateWorkItemAsync(int id, string title, string description=null, string discursion = null, string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
         return await _azureDevOpsService.UpdateWorkItemAsync(id, title, description,discursion,tags, parentWorkItemId, cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
             await _azureDevOpsService.DeleteWorkItemAsync(id,cancellationToken).ConfigureAwait(false);
        }

        public async Task<WorkItem> GetWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
           return await _azureDevOpsService.GetWorkItemAsync(id, cancellationToken).ConfigureAwait(false);
        }
    }
}
