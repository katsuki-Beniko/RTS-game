public class FightEnemyUnit : FightUnitBase
{
    public override void Init()
    {
        base.Init();
        GameApp.FightManager.ResetHeros();
        GameApp.ViewManager.Open(ViewType.TipView,"Enemy Round");

        GameApp.CommandManager.AddCommand(new WaitCommand(1.25f));

        //�����ƶ���ʹ�ü��ܵ�
        for(int i = 0;i<GameApp.FightManager.enemys.Count;i++)
        {
            Enemy enemy = GameApp.FightManager.enemys[i];
            GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//�ȴ�
            GameApp.CommandManager.AddCommand(new AiMoveCommand(enemy));//�ƶ�
            GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//�ȴ�
            GameApp.CommandManager.AddCommand(new SkillCommand(enemy));//ʹ�ü���
            GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));
        }


        GameApp.CommandManager.AddCommand(new WaitCommand(0.2f, delegate () 
        {
            GameApp.FightManager.ChangeState(GameState.Player);
        }));
    }
}
