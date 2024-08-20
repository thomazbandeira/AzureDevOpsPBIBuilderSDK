using AzureDevOps.Model.Enum;

namespace AzureDevOps.Model
{
    public class Task : WorkItem<Pbi>
    {
        public override WorkItemTypeEnum WorkItemType { get; set; } = WorkItemTypeEnum.Task;
        public new Pbi? Parent { get; set; } = null;
    }

}