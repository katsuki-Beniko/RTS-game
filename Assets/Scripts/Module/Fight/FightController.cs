public class FightController : BaseController
{
    public FightController():base()
    {
        SetModel(new FightModel(this));

        GameApp.ViewManager.Register(ViewType.FightView,new ViewInfo() 
        {
            PrefabName = "FightView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });
        GameApp.ViewManager.Register(ViewType.FightSelectHeroView, new ViewInfo()
        {
            PrefabName = "FightSelectHeroView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 1
        });

        GameApp.ViewManager.Register(ViewType.DragHeroView, new ViewInfo()
        {
            PrefabName = "DragHeroView",
            controller = this,
            parentTf = GameApp.ViewManager.worldCanvasTf,
            Sorting_Order = 2
        });

        GameApp.ViewManager.Register(ViewType.TipView, new ViewInfo()
        {
            PrefabName = "TipView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 2
        });

        GameApp.ViewManager.Register(ViewType.HeroDesView, new ViewInfo() 
        {
            PrefabName = "HeroDesView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 2
        });
        GameApp.ViewManager.Register(ViewType.EnemyDesView, new ViewInfo()
        {
            PrefabName = "EnemyDesView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 2
        });
        GameApp.ViewManager.Register(ViewType.SelectOptionView, new ViewInfo() 
        {
            PrefabName = "SelectOptionView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });
        GameApp.ViewManager.Register(ViewType.FightOptionDesView, new ViewInfo()
        {
            PrefabName = "FightOptionDesView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 3
        });
        //ʤ����ʧ�ܵĴ���
        GameApp.ViewManager.Register(ViewType.WinView, new ViewInfo()
        {
            PrefabName = "WinView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 3
        });
        GameApp.ViewManager.Register(ViewType.LossView, new ViewInfo()
        {
            PrefabName = "LossView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 3
        });
        InitModuleEvent();
    }

    public override void Init()
    {
        base.Init();
        model.Init();
    }

    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.BeginFight, onBeginFightCallback);
    }

    private void onBeginFightCallback(System.Object[] arg)
    {
        GameApp.FightManager.ChangeState(GameState.Enter);

        GameApp.ViewManager.Open(ViewType.FightView);
        GameApp.ViewManager.Open(ViewType.FightSelectHeroView);
    }
}
