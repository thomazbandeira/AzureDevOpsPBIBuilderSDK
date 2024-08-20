using AzureDevOps.Model.Enum;

namespace AzureDevOps.Model
{
    public class Feature : WorkItem<Epic>, IWorkItem<Epic>
    {
        public override WorkItemTypeEnum WorkItemType { get; set; } = WorkItemTypeEnum.Feature;
        public override Epic? Parent { get; set; } = null;
    }
}