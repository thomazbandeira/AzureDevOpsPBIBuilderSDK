using AzureDevOps.Model.Enum;

namespace AzureDevOps.Model
{
    public class RecordClass: IRecordClass
    {
        public long Id { get; set; } = long.MinValue;
        public string Title { get; set; } = string.Empty;
        public string[] Tags { get; set; } = new string[0];
        public string Description { get; set; } = string.Empty;
        public string AcceptanceCriteria { get; set; } = string.Empty;
        public string Discursion { get; set; } = string.Empty;

        public DateTime Status__Start_Date { get; set; } = DateTime.MinValue;
        public DateTime Status__Target_Date { get; set; } = DateTime.MinValue;

        public int Details__Priority { get; set; } = int.MinValue;

        public decimal Details__Effort { get; set; } = decimal.MinValue;

        public int Details__Business_Value { get; set; } = int.MinValue;

        public int Details__Time_Criticality { get; set; } = int.MinValue;

        public string Details__Value_Area { get; set; } = string.Empty;
        public virtual WorkItemTypeEnum WorkItemType { get; set; }
    }
    public class WorkItem<T> : RecordClass, IWorkItem<T> where T : new()
    {   
        public virtual T? Parent { get; set; }
    }
}
