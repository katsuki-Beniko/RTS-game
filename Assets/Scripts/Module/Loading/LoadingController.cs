
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 加载场景控制器
/// </summary>
public class LoadingController : BaseController
{
    AsyncOperation asyncOp;
    public LoadingController():base()
    {
        GameApp.ViewManager.Register(ViewType.LoadingView,new ViewInfo() 
        {
            PrefabName = "LoadingView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });

        InitModuleEvent();
    }

    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.LoadingScene,loadSceneCallBack);
    }

    //加载场景回调
    private void loadSceneCallBack(System.Object[] args)
    {
        LoadingModel loadingModel = args[0] as LoadingModel;

        SetModel(loadingModel);

        //打开加载界面
        GameApp.ViewManager.Open(ViewType.LoadingView);

        //加载场景
        asyncOp = SceneManager.LoadSceneAsync(loadingModel.SceneName);

        asyncOp.completed += onLoadedEndCallBack;
    }

    //加载后回调
    private void onLoadedEndCallBack(AsyncOperation op)
    {
        asyncOp.completed -= onLoadedEndCallBack;

        //延迟一会儿
        GameApp.TimerManager.Register(1f, delegate () 
        {
            GetModel<LoadingModel>().callback?.Invoke();

            GameApp.ViewManager.Close((int)ViewType.LoadingView);
        });
    }
}
