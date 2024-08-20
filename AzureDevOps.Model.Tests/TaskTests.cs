using AzureDevOps.Model.Enum;
using Xunit;


namespace AzureDevOps.Model.Tests
{
    public class TaskTests
    {
        [Fact]
        public void TestValuesOfObject()
        {
            var model = new Task();
            Assert.True(model.WorkItemType == WorkItemTypeEnum.Task);
            Assert.Null(model.Parent);

            model.Parent = new Pbi();
            Assert.NotNull(model.Parent);

            model.AcceptanceCriteria = "AcceptanceCriteria";
            Assert.Equal("AcceptanceCriteria", model.AcceptanceCriteria);

            model.Description = "Description";
            Assert.Equal("Description", model.Description);

            model.Title = "Title";
            Assert.Equal("Title", model.Title);

            model.Status__Start_Date = new DateTime(2024, 05, 30,0,0,0,DateTimeKind.Utc);
            Assert.True(model.Status__Start_Date == new DateTime(2024, 05, 30,0,0,0,DateTimeKind.Utc));

            model.Status__Target_Date = new DateTime(2024, 05, 30,0,0,0,DateTimeKind.Utc);
            Assert.True(model.Status__Target_Date == new DateTime(2024, 05, 30,0,0,0,DateTimeKind.Utc));

            model.Discursion = "Discursion";
            Assert.True(model.Discursion == "Discursion");

            model.Details__Business_Value = 1;
            Assert.True(model.Details__Business_Value == 1);

            model.Details__Value_Area = "Value_Area";
            Assert.True(model.Details__Value_Area == "Value_Area");

            model.Tags = new string[] {"tag1","tag2"};
            Assert.True(model.Tags == new string[] {"tag1","tag2"});

            model.Details__Effort = 1;
            Assert.True(model.Details__Effort == 1);
            model.Details__Priority = 1;
            Assert.True(model.Details__Priority == 1);
            model.Details__Time_Criticality= 1;
            Assert.True(model.Details__Time_Criticality == 1);
        }
    }
}