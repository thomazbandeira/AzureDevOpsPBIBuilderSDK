using AzureDevOps.Model.Enum;

namespace AzureDevOps.Model
{
    public class Pbi : WorkItem<Feature>, IWorkItem<Feature>
    {
        public override WorkItemTypeEnum WorkItemType { get; set; } = WorkItemTypeEnum.Product_Backlog_Item;
        public override Feature? Parent { get; set; } = null;
    }
}