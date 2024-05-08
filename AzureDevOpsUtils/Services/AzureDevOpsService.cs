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

        public async Task<WorkItem> CreateWorkItem(WorkItemTypeEnum workItemType, string title, string description, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
            return await CreateWorkItemAsync(workItemType.ToString().Replace("_", " "), title, description, parentWorkItemId, cancellationToken).ConfigureAwait(false);
        }

        public async Task<WorkItem> CreateWorkItemAsync(string workItemType, string title, string description, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
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
                return await workItemTrackingHttpClient.CreateWorkItemAsync(workItem, _project, workItemType, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task DeleteWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                await workItemTrackingHttpClient.DeleteWorkItemAsync(id, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<WorkItem> GetWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                return await workItemTrackingHttpClient.GetWorkItemAsync(id, cancellationToken: cancellationToken);
            }
        }

        public async Task<List<WorkItem>> GetWorkItems(WorkItemTypeEnum workItemType, CancellationToken cancellationToken = default)
        {
            return await GetWorkItemsAsync(workItemType.ToString().Replace("_", " "), cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<WorkItem>> GetWorkItemsAsync(string workItemType, CancellationToken cancellationToken = default)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
                var wiql = new Wiql() { Query = $"Select [System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = '{workItemType}' order by [Microsoft.VSTS.Scheduling.StartDate] desc" };
                var result = await workItemTrackingHttpClient.QueryByWiqlAsync(wiql, cancellationToken: cancellationToken);
                var ids = result.WorkItems.Select(wi => wi.Id).ToArray();
                return await workItemTrackingHttpClient.GetWorkItemsAsync(ids,cancellationToken: cancellationToken);
            }
        }

        public async Task<WorkItem> UpdateWorkItemAsync(int id, string title, string description, CancellationToken cancellationToken = default)
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
                return await workItemTrackingHttpClient.UpdateWorkItemAsync(workItem, id, cancellationToken: cancellationToken);
            }
        }
    }
}
