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
        public void �P�ʎ��Ԃ�����3�����ł���`�[����_3�̃A�E�g�v�b�g���o��()
        {            
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<ITask> outputs = team.NextOutput();

            Assert.Equal(3, outputs.Count);
        }

        [Fact]
        public void �P�ʎ��Ԃ�����3�����ł���`�[����_�^�X�N��2�����ς܂�ĂȂ���_2�̃A�E�g�v�b�g���o��()
        {
            team.Input(new FeatureTask());
            team.Input(new FeatureTask());

            List<ITask> outputs = team.NextOutput();

            Assert.Equal(2, outputs.Count);
        }
    }
}