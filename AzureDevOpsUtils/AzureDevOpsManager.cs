using AzureDevOps.Model;
using AzureDevOps.Model.Enum;
using AzureDevOpsUtils.Interfaces;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Text;

namespace AzureDevOpsUtils
{
    public partial class AzureDevOpsManager
    {
        private readonly IAzureDevOpsService _azureDevOpsService;


        public AzureDevOpsManager(IAzureDevOpsService azureDevOpsService)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _ = Encoding.GetEncoding("utf-8");
            _azureDevOpsService = azureDevOpsService;
        }
        public void SavePBIChanges(List<AzureDevOps.Model.Task> Tasks)
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 10
            };

            AzureDevOpsToProcess toProcess = new AzureDevOpsToProcess();

            _ = Parallel.ForEachAsync(Tasks, options, (actualTask, cancelationToken) => {
                if (actualTask.Parent != null)
                {
                    bool findActualParentWithID = actualTask.Parent.Id > 0;
                    // Rever lógica de find (caso tenha ID e não achou na coleção, tem que fazer o contrário também... Caso que venha com ID, verificar por texto do que não tem ID e atualizar o ID e usar da lista)
                    if (toProcess.PBIs != null)
                    {
                        Pbi PBIFound = toProcess.PBIs.Find(actualPBI => (findActualParentWithID && actualPBI.Id == actualTask.Parent.Id) || (actualTask.Parent != null && (actualTask.Parent.Title??"").Equals((actualPBI.Title??""), StringComparison.OrdinalIgnoreCase)))?? new Pbi();
                        
                            if (!string.IsNullOrWhiteSpace(PBIFound.Title))
                        {
                            actualTask.Parent = PBIFound;
                        }else
                        {
                            toProcess.PBIs.Add(actualTask.Parent);
                            if (actualTask.Parent.Parent != null)
                            {
                                findActualParentWithID = actualTask.Parent.Parent.Id > 0;
                                Feature featureFound = toProcess.Features.Find(actualFeature => (findActualParentWithID && actualFeature.Id == actualTask.Parent.Parent.Id) || (actualTask.Parent.Parent != null && (actualTask.Parent.Parent.Title ?? "").Equals((actualFeature.Title ?? ""), StringComparison.OrdinalIgnoreCase))) ?? new Feature();
                                if (!string.IsNullOrWhiteSpace(featureFound.Title))
                                {
                                    actualTask.Parent.Parent = featureFound;
                                }
                                else
                                {
                                    toProcess.Features.Add(actualTask.Parent.Parent);
                                    if (actualTask.Parent.Parent.Parent != null)
                                    {
                                        ParentSearch<Epic>(actualTask.Parent.Parent.Parent, toProcess.Epics, (parentFound) =>
                                        {
                                            actualTask.Parent.Parent.Parent = (Epic)parentFound;
                                            bool ok = true;
                                        }, (parentNotFound) =>
                                        {
                                            toProcess.Epics.Add((Epic)parentNotFound);
                                            bool ok = true;
                                        });
                                        
                                        //findActualParentWithID = actualTask.Parent.Parent.Id > 0;
                                        //Epic epicFound = toProcess.Epics.Find(actualEpic => (findActualParentWithID && actualEpic.Id == actualTask.Parent.Parent.Parent.Id) || (actualTask.Parent.Parent.Parent != null && (actualTask.Parent.Parent.Parent.Title ?? "").Equals((actualEpic.Title ?? ""), StringComparison.OrdinalIgnoreCase))) ?? new Epic();
                                        //if (!string.IsNullOrWhiteSpace(epicFound.Title))
                                        //{
                                        //    actualTask.Parent.Parent.Parent = epicFound;
                                        //}
                                        //else
                                        //{
                                        //    toProcess.Epics.Add(actualTask.Parent.Parent.Parent);
                                        //}
                                    }
                                }
                                //aaa

                            }
                        }
                    }
                }

                return new ValueTask();
            }).ConfigureAwait(false);


        }
        private static bool ParentSearch<Z>(Z parent, List<Z> parentList, Action<RecordClass> parentFound, Action<RecordClass> parentNotFound)
            where Z : RecordClass
        {
            bool findActualParentWithID = parent.Id > 0;
            RecordClass epicFound = parentList.Find(actualParentOfList => (findActualParentWithID && actualParentOfList.Id == parent.Id) || (parent != null && (parent.Title ?? "").Equals((actualParentOfList.Title ?? ""), StringComparison.OrdinalIgnoreCase))) ?? new RecordClass();
            
            if (!string.IsNullOrWhiteSpace(epicFound.Title))
            {
                // Overide original value, for create reference memory
                parentFound(epicFound);
                //actualParent.Parent = epicFound;
            }
            else
            {
                // Criate list for save new parent
                parentNotFound(parent);
                //parentList.Epics.Add(actualParent.Parent.Parent.Parent);
            }

            return findActualParentWithID;
        }

        public async System.Threading.Tasks.Task<WorkItem> CreateWorkItemAsync(WorkItemTypeEnum workItemType, string title, string description = "", string discursion = "", string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
            return await _azureDevOpsService.CreateWorkItemAsync(workItemType.ToString().Replace("_", " "), title, description, discursion, tags, parentWorkItemId, cancellationToken).ConfigureAwait(false);
        }
        public async System.Threading.Tasks.Task<List<WorkItem>> GetWorkItemsAsync(WorkItemTypeEnum workItemType, CancellationToken cancellationToken = default)
        {
            return await _azureDevOpsService.GetWorkItemsAsync(workItemType.ToString().Replace("_", " "), cancellationToken).ConfigureAwait(false);
        }

        public async System.Threading.Tasks.Task<WorkItem> UpdateWorkItemAsync(int id, string title, string description = "", string discursion = "", string[] tags = null, int? parentWorkItemId = null, CancellationToken cancellationToken = default)
        {
            return await _azureDevOpsService.UpdateWorkItemAsync(id, title, description, discursion, tags, parentWorkItemId, cancellationToken).ConfigureAwait(false);
        }

        public async System.Threading.Tasks.Task DeleteWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
            await _azureDevOpsService.DeleteWorkItemAsync(id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<WorkItem> GetWorkItemAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _azureDevOpsService.GetWorkItemAsync(id, cancellationToken).ConfigureAwait(false);
        }
    }
}
