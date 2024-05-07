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
        public async Task<WorkItem> CreateWorkItem(WorkItemTypeEnum workItemType, string title, string description, int? parentWorkItemId = null)
        {
            return await _azureDevOpsService.CreateWorkItem(workItemType.ToString().Replace("_", " "), title, description, parentWorkItemId).ConfigureAwait(false);
        }
        public async Task<List<WorkItem>> GetWorkItems(WorkItemTypeEnum workItemType)
        {
            return await _azureDevOpsService.GetWorkItems(workItemType.ToString().Replace("_", " ")).ConfigureAwait(false);
        }

        public async Task<WorkItem> UpdateWorkItem(int id, string title, string description)
        {
         return await _azureDevOpsService.UpdateWorkItem(id, title, description).ConfigureAwait(false);
        }

        public async Task DeleteWorkItem(int id)
        {
             await _azureDevOpsService.DeleteWorkItem(id).ConfigureAwait(false);
        }

        public async Task<WorkItem> GetWorkItem(int id)
        {
           return await _azureDevOpsService.GetWorkItem(id).ConfigureAwait(false);
        }
    }
}
