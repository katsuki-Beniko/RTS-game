public class GameUIController : BaseController
{
    public GameUIController():base()
    {
        GameApp.ViewManager.Register(ViewType.StartView,new ViewInfo() 
        {
            PrefabName = "StartView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });

        GameApp.ViewManager.Register(ViewType.SetView, new ViewInfo()
        {
            PrefabName = "SetView",
            controller = this,
            Sorting_Order = 1,
            parentTf = GameApp.ViewManager.canvasTf
        });
        //要弹出提示窗口信息，确认玩家是否这样操作
        GameApp.ViewManager.Register(ViewType.MessageView,new ViewInfo() 
        {
            PrefabName = "MessageView",
            controller = this,
            Sorting_Order = 999,
            parentTf = GameApp.ViewManager.canvasTf
        });

        InitModuleEvent();
        InitGlobalEvent();
    }

    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.OpenStartView,openStartView);
        RegisterFunc(Defines.OpenSetView,openSetView);
        RegisterFunc(Defines.OpenMessageView, openMessageView);
    }

    private void openStartView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.StartView, arg);
    }

    private void openSetView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.SetView, arg);
    }

    //打开提示面板
    private void openMessageView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.MessageView, arg);
    }
}
