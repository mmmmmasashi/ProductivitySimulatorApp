using ProductivitySimDomainLib.Task;
using ProductivitySimDomainLib.Unit;

namespace ProductivitySimDomainLibTest
{
    public class DevTeam_�P�ʎ��Ԃ����菈���ʂ�3��Test
    {
        IUnit team;

        public DevTeam_�P�ʎ��Ԃ����菈���ʂ�3��Test()
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

    public class DevTeam_�P�ʎ��Ԃ����菈���ʂ�0dot3��Test
    {
        IUnit team;

        public DevTeam_�P�ʎ��Ԃ����菈���ʂ�0dot3��Test()
        {
            const decimal TaskPerTime = 0.3M;
            team = new DevTeam(TaskPerTime);
        }

        [Fact]
        public void �P�ʎ��Ԃ�����0dot3�����ł���`�[����4�P�ʎ��Ԍo�߂���1�̃A�E�g�v�b�g���o��()
        {
            //�\���ȃ^�X�N��^���Ă���
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