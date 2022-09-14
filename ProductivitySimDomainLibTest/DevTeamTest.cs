using ProductivitySimDomainLib.Output;
using ProductivitySimDomainLib.Task;
using ProductivitySimDomainLib.Unit;
using System;
using Xunit;

namespace ProductivitySimDomainLibTest
{

    public class DevTeamTest
    {
        [Fact]
        public void 修正失敗率は0_1の間()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(1, -0.01));
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(1, 1.01));
        }

        [Fact]
        public void 時間あたり処理タスクは正の値()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DevTeam(-0.1M, 1));
        }

        [Fact]
        public void 修正失敗率が0だとバグが起きない()
        {
            const decimal TaskPerTime = 3;
            const double FailureRate = 0;//修正失敗率 
            var team = new DevTeam(TaskPerTime, FailureRate);

            for (int i = 0; i < 100; i++)
            {
                team.Input(new FeatureTask());
                List<IOutput> outputs = team.NextOutput();
                Assert.False(outputs.First().HasBug);
            }
        }

        [Fact]
        public void 修正失敗率が100percentだと必ずバグが発生する()
        {
            const decimal TaskPerTime = 3;
            const double FailureRate = 1;//修正失敗率 
            var team = new DevTeam(TaskPerTime, FailureRate);

            for (int i = 0; i < 100; i++)
            {
                team.Input(new FeatureTask());
                List<IOutput> outputs = team.NextOutput();
                Assert.True(outputs.First().HasBug);
            }
        }
    }

    public class DevTeam_単位時間あたり処理量が3のTest
    {
        IUnit team;

        public DevTeam_単位時間あたり処理量が3のTest()
        {
            const decimal TaskPerTime = 3;
            const double FailureRate = 0;//修正失敗率 
            team = new DevTeam(TaskPerTime, FailureRate);
        }

        [Fact]
        public void 単位時間あたり3処理できるチームが_3のアウトプットを出す()
        {
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<IOutput> outputs = team.NextOutput();

            Assert.Equal(3, outputs.Count);
        }

        [Fact]
        public void 単位時間あたり3処理できるチームが_タスクが2しか積まれてないと_2のアウトプットを出す()
        {
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<IOutput> outputs = team.NextOutput();

            Assert.Equal(2, outputs.Count);
        }
    }


    public class DevTeam_単位時間あたり処理量が0dot3のTest
    {
        IUnit team;

        public DevTeam_単位時間あたり処理量が0dot3のTest()
        {
            const decimal TaskPerTime = 0.3M;
            team = new DevTeam(TaskPerTime, 0);
        }

        [Fact]
        public void 単位時間あたり0dot3処理できるチームは4単位時間経過して1のアウトプットを出す()
        {
            //十分なタスクを与えておく
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<IOutput> outputs1 = team.NextOutput();//0.3
            Assert.Empty(outputs1);

            List<IOutput> outputs2 = team.NextOutput();//0.6
            Assert.Empty(outputs2);

            List<IOutput> outputs3 = team.NextOutput();//0.9
            Assert.Empty(outputs3);

            List<IOutput> outputs4 = team.NextOutput();//1.2 -> 0.2
            Assert.Single(outputs4);

            List<IOutput> outputs5 = team.NextOutput();//0.5
            Assert.Empty(outputs5);

            List<IOutput> outputs6 = team.NextOutput();//0.8
            Assert.Empty(outputs6);

            List<IOutput> outputs7 = team.NextOutput();//1.1 -> 0.1
            Assert.Single(outputs7);
        }

    }
}