using AzureDevOps.Model.Enum;

namespace AzureDevOps.Model
{
    public class Epic: WorkItem<Epic>, IWorkItem<Epic>
    {
        public override WorkItemTypeEnum WorkItemType { get; set; } = WorkItemTypeEnum.Epic;
        public override Epic? Parent { get; set; } = null;
    }
}