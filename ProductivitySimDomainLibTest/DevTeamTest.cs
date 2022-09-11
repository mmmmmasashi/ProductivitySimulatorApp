using ProductivitySimDomainLib.Task;
using ProductivitySimDomainLib.Unit;

namespace ProductivitySimDomainLibTest
{
    public class DevTeam_単位時間あたり処理量が3のTest
    {
        IUnit team;

        public DevTeam_単位時間あたり処理量が3のTest()
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

    public class DevTeam_単位時間あたり処理量が0dot3のTest
    {
        IUnit team;

        public DevTeam_単位時間あたり処理量が0dot3のTest()
        {
            const decimal TaskPerTime = 0.3M;
            team = new DevTeam(TaskPerTime);
        }

        [Fact]
        public void 単位時間あたり0dot3処理できるチームは4単位時間経過して1のアウトプットを出す()
        {
            //十分なタスクを与えておく
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<ITask> outputs1 = team.NextOutput();//0.3
            Assert.Empty(outputs1);

            List<ITask> outputs2 = team.NextOutput();//0.6
            Assert.Empty(outputs2);

            List<ITask> outputs3 = team.NextOutput();//0.9
            Assert.Empty(outputs3);

            List<ITask> outputs4 = team.NextOutput();//1.2 -> 0.2
            Assert.Single(outputs4);

            List<ITask> outputs5 = team.NextOutput();//0.5
            Assert.Empty(outputs5);

            List<ITask> outputs6 = team.NextOutput();//0.8
            Assert.Empty(outputs6);

            List<ITask> outputs7 = team.NextOutput();//1.1 -> 0.1
            Assert.Single(outputs7);
        }

    }
}