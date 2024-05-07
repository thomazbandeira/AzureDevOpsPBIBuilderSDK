using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureDevOpsUtils.Enums;

namespace AzureDevOpsUtils.Interfaces
{
    public interface IAzureDevOpsService
    {

        Task<WorkItem> CreateWorkItem(WorkItemTypeEnum workItemType, string title, string description, int? parentWorkItemId = null);

        Task<List<WorkItem>> GetWorkItems(WorkItemTypeEnum workItemType);
        Task<WorkItem> CreateWorkItem(string workItemType, string title, string description, int? parentWorkItemId = null);

        Task<WorkItem> UpdateWorkItem(int id, string title, string description);

        Task DeleteWorkItem(int id);

        Task<WorkItem> GetWorkItem(int id);

        Task<List<WorkItem>> GetWorkItems(string workItemType);
    }
}
