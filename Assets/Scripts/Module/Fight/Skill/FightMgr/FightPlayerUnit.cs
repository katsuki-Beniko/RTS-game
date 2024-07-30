public class FightPlayerUnit : FightUnitBase
{
    public override void Init()
    {
        base.Init();
        GameApp.FightManager.ResetEnemys();
        GameApp.ViewManager.Open(ViewType.TipView, "Player Turn");
    }
}
