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

        Task<WorkItem> CreateWorkItem(WorkItemTypeEnum workItemType, string title, string description, int? parentWorkItemId = null, CancellationToken cancellationToken = default);

        Task<List<WorkItem>> GetWorkItems(WorkItemTypeEnum workItemType, CancellationToken cancellationToken = default);
        Task<WorkItem> CreateWorkItem(string workItemType, string title, string description, int? parentWorkItemId = null, CancellationToken cancellationToken = default);

        Task<WorkItem> UpdateWorkItem(int id, string title, string description, CancellationToken cancellationToken = default);

        Task DeleteWorkItem(int id, CancellationToken cancellationToken = default);

        Task<WorkItem> GetWorkItem(int id, CancellationToken cancellationToken = default);

        Task<List<WorkItem>> GetWorkItems(string workItemType, CancellationToken cancellationToken = default);
    }
}
