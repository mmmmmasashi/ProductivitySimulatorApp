namespace ProductivitySimDomainLibTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const decimal TaskPerTime = 3;
            IUnit team = new DevTeam(TaskPerTime);
            
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<ITask> outputs = team.NextOutput();

            Assert.Equal(3, outputs.Count);
        }
    }
}