using AzureDevOps.Model.Enum;
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

        public async Task<WorkItem> CreateWorkItemAsync(WorkItemTypeEnum workItemType, string title, string description, string discursion = "", string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
            return await CreateWorkItemAsync(workItemType.ToString().Replace("_", " "), title, description, discursion, tags, parentWorkItemId, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<WorkItem> CreateWorkItemAsync(string workItemType, string title, string description, string discursion = "",string[] tags=null, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
            JsonPatchDocument workItem = jSonPatchDocumentMount(title, description, discursion, tags, parentWorkItemId);

            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = await connection.GetClientAsync<WorkItemTrackingHttpClient>().ConfigureAwait(false);
                return await workItemTrackingHttpClient.CreateWorkItemAsync(workItem, _project, workItemType, cancellationToken: cancellationToken);
            }
        }

        private JsonPatchDocument jSonPatchDocumentMount(string title, string description = "", string discursion = "", string[] tags = null, int? parentWorkItemId = null)
        {
            var workItem = new JsonPatchDocument();

            workItem.Add(new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path = "/fields/System.Title",
                Value = title
            });
            if (description != null)
            {
                workItem.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Description",
                    Value = description
                });
            }

            if (discursion != null)
            {
                workItem.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.History",
                    Value = discursion
                });
            }
            if (tags != null && tags.Length > 0)
            {
                workItem.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Tags",
                    Value = string.Join("; ", tags)
                });
            }



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

            return workItem;
        }

        public async Task DeleteWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = await connection.GetClientAsync<WorkItemTrackingHttpClient>().ConfigureAwait(false);
                await workItemTrackingHttpClient.DeleteWorkItemAsync(id, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<WorkItem> GetWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = await connection.GetClientAsync<WorkItemTrackingHttpClient>().ConfigureAwait(false);
                return await workItemTrackingHttpClient.GetWorkItemAsync(id, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<List<WorkItem>> GetWorkItemsAsync(WorkItemTypeEnum workItemType, CancellationToken cancellationToken = default)
        {
            return await GetWorkItemsAsync(workItemType.ToString().Replace("_", " "), cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<WorkItem>> GetWorkItemsAsync(string workItemType, CancellationToken cancellationToken = default)
        {
            using (var connection = GetConnection())
            {
                var workItemTrackingHttpClient = await connection.GetClientAsync<WorkItemTrackingHttpClient>().ConfigureAwait(false);
                var wiql = new Wiql() { Query = $"Select [System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = '{workItemType}' order by [Microsoft.VSTS.Scheduling.StartDate] desc" };
                var result = await workItemTrackingHttpClient.QueryByWiqlAsync(wiql).ConfigureAwait(false);
                var ids = result.WorkItems.Select(wi => wi.Id).ToArray();
                return await workItemTrackingHttpClient.GetWorkItemsAsync(ids, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<WorkItem> UpdateWorkItemAsync(int id, string title, string description, string discursion = "", string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
            JsonPatchDocument workItem = jSonPatchDocumentMount(title, description, discursion,tags, parentWorkItemId);

            using (var connection = GetConnection())
            {
                WorkItemTrackingHttpClient workItemTrackingHttpClient = await connection.GetClientAsync<WorkItemTrackingHttpClient>();
                return await workItemTrackingHttpClient.UpdateWorkItemAsync(workItem, id, cancellationToken: cancellationToken);
            }
        }
    }
}
