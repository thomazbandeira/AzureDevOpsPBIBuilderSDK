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
using AzureDevOps.Model.Enum;

namespace AzureDevOpsUtils.Interfaces
{
    public interface IAzureDevOpsService
    {   
        Task<WorkItem> CreateWorkItemAsync(string workItemType, string title, string description, string discursion = "", string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default);

        Task DeleteWorkItemAsync(int id, CancellationToken cancellationToken = default);

        Task<WorkItem> GetWorkItemAsync(int id, CancellationToken cancellationToken = default);
        Task<List<WorkItem>> GetWorkItemsAsync(string workItemType, CancellationToken cancellationToken = default);
        Task<WorkItem> UpdateWorkItemAsync(int id, string title, string description, string discursion = "", string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default);
    }
}
