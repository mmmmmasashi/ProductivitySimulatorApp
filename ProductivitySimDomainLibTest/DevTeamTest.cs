using ProductivitySimDomainLib.Task;
using ProductivitySimDomainLib.Unit;

namespace ProductivitySimDomainLibTest
{
    public class DevTeamTest
    {
        IUnit team;

        public DevTeamTest()
        {
            const decimal TaskPerTime = 3;
            team = new DevTeam(TaskPerTime);
        }

        [Fact]
        public void 単位時間あたり3処理できるチームが_3のアウトプットを出す()
        {            
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<ITask> outputs = team.NextOutput();

            Assert.Equal(3, outputs.Count);
        }

        [Fact]
        public void 単位時間あたり3処理できるチームが_タスクが2しか積まれてないと_2のアウトプットを出す()
        {
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<ITask> outputs = team.NextOutput();

            Assert.Equal(2, outputs.Count);
        }
    }
}