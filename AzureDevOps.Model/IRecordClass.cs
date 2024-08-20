using AzureDevOps.Model.Enum;

namespace AzureDevOps.Model
{
    public interface IRecordClass
    {
        long Id { get; set; }
        string Title { get; set; }
        WorkItemTypeEnum WorkItemType { get; set; }
        string[] Tags { get; set; }
        string Description { get; set; }
        string AcceptanceCriteria { get; set; }
        string Discursion { get; set; }

        DateTime Status__Start_Date { get; set; }
        DateTime Status__Target_Date { get; set; }

        int Details__Priority { get; set; }

        decimal Details__Effort { get; set; }

        int Details__Business_Value { get; set; }

        int Details__Time_Criticality { get; set; }

        string Details__Value_Area { get; set; }
    }
}
