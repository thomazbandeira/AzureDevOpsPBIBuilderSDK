using AzureDevOps.Model;

namespace AzureDevOpsUtils
{
    public partial class AzureDevOpsManager
    {
        class AzureDevOpsToProcess
        {
            public List<Epic> Epics { get; set; } = new List<Epic>();
            public List<Feature> Features { get; set; } = new List<Feature>();
            public List<Pbi> PBIs { get; set; } = new List<Pbi>();
            public List<AzureDevOps.Model.Task> Tasks { get; set; } = new List<AzureDevOps.Model.Task>();
        }
    }
}
