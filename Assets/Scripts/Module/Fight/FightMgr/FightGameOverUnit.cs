/// <summary>
/// 战斗结束
/// </summary>
public class FightGameOverUnit : FightUnitBase
{
    public override void Init()
    {
        base.Init();

        //清除指令
        GameApp.CommandManager.Clear();

        if(GameApp.FightManager.heros.Count==0)
        {
            //延迟一点时间才出现界面
            GameApp.CommandManager.AddCommand(new WaitCommand(1.25f, delegate ()
            {
                GameApp.ViewManager.Open(ViewType.LossView);
            }));
        }
        else if(GameApp.FightManager.enemys.Count == 0)
        {
            GameApp.CommandManager.AddCommand(new WaitCommand(1.25f, delegate ()
            {
                GameApp.ViewManager.Open(ViewType.WinView);
            }));
        }
        else
        {

        }
    }

    public override bool Update(float dt)
    {
        return true;
    }
}
