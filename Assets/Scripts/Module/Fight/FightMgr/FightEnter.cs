/// <summary>
/// ����ս������Ҫ������߼�
/// </summary>
public class FightEnter : FightUnitBase
{
    public override void Init()
    {
        //��ͼ��ʼ��
        GameApp.MapManager.Init();

        //����ս��
        GameApp.FightManager.EnterFight();
    }
}
