using AzureDevOpsUtils.Enums;
using AzureDevOpsUtils.Services;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsUtils.Interfaces
{
    public interface IAzureDevOpsManager
    {
        Task<WorkItem> CreateWorkItem(WorkItemTypeEnum workItemType, string title, string description, int? parentWorkItemId = null);

        Task<List<WorkItem>> GetWorkItems(WorkItemTypeEnum workItemType);


        Task<WorkItem> UpdateWorkItem(int id, string title, string description);

        Task DeleteWorkItem(int id);

        Task<WorkItem> GetWorkItem(int id);
    }
}
