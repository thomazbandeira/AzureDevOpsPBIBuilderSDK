using AzureDevOpsUtils.Enums;
using AzureDevOpsUtils.Interfaces;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;

namespace AzureDevOpsUtils.Services
{
    public class AzureDevOpsService : IAzureDevOpsService
    {
        private readonly Uri _uri;
        private readonly string _personalAccessToken;
        private readonly string _project;
        private string GetWorkItemUrl(int id)
        {
            return $"{_uri}/{_project}/_apis/wit/workItems/{id}";
        }
        public AzureDevOpsService(string uri, string personalAccessToken, string project)
        {
            _uri = new Uri(uri);
            _personalAccessToken = personalAccessToken;
            _project = project;
        }
        private VssConnection GetConnection()
        {
            VssConnection connection = new VssConnection(_uri, new VssBasicCredential(string.Empty, _personalAccessToken));
            return connection;
        }

        public async Task<WorkItem> CreateWorkItem(WorkItemTypeEnum workItemType, string title, string description, int? parentWorkItemId = null)
        {
            return await CreateWorkItem(workItemType.ToString().Replace("_", " "), title, description, parentWorkItemId).ConfigureAwait(false);
        }

        public async Task<WorkItem> CreateWorkItem(string workItemType, string title, string description, int? parentWorkItemId = null)
        {
            var workItem = new JsonPatchDocument
        {
            new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path = "/fields/System.Title",
                Value = title
            },
            new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path = "/fields/System.Description",
                Value = description
            }
        };

            if (parentWorkItemId.HasValue)
            {
                workItem.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/relations/-",
                        Value = new
                        {
                            rel = "System.LinkTypes.Hierarchy-Reverse",
                            url = GetWorkItemUrl(parentWorkItemId.Value),
                            attributes = new
                            {
                                comment = "Parent work item"
                            }
                        }
                    });
            }

            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                return await workItemTrackingHttpClient.CreateWorkItemAsync(workItem, _project, workItemType);
            }
        }

        public async Task DeleteWorkItem(int id)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                await workItemTrackingHttpClient.DeleteWorkItemAsync(id);
            }
        }

        public async Task<WorkItem> GetWorkItem(int id)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                return await workItemTrackingHttpClient.GetWorkItemAsync(id);
            }
        }

        public async Task<List<WorkItem>> GetWorkItems(WorkItemTypeEnum workItemType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkItem>> GetWorkItems(string workItemType)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                var wiql = new Wiql() { Query = $"Select [System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = '{workItemType}' order by [Microsoft.VSTS.Scheduling.StartDate] desc" };
                var result = await workItemTrackingHttpClient.QueryByWiqlAsync(wiql);
                var ids = result.WorkItems.Select(wi => wi.Id).ToArray();
                return await workItemTrackingHttpClient.GetWorkItemsAsync(ids);
            }
        }

        public async Task<WorkItem> UpdateWorkItem(int id, string title, string description)
        {
            var workItem = new JsonPatchDocument
        {
            new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path = "/fields/System.Title",
                Value = title
            },
            new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path = "/fields/System.Description",
                Value = description
            }
        };

            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                return await workItemTrackingHttpClient.UpdateWorkItemAsync(workItem, id);
            }
        }
    }
}
