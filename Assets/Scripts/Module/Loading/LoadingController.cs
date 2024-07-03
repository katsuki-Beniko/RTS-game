
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���س���������
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

    //���س����ص�
    private void loadSceneCallBack(System.Object[] args)
    {
        LoadingModel loadingModel = args[0] as LoadingModel;

        SetModel(loadingModel);

        //�򿪼��ؽ���
        GameApp.ViewManager.Open(ViewType.LoadingView);

        //���س���
        asyncOp = SceneManager.LoadSceneAsync(loadingModel.SceneName);

        asyncOp.completed += onLoadedEndCallBack;
    }

    //���غ�ص�
    private void onLoadedEndCallBack(AsyncOperation op)
    {
        asyncOp.completed -= onLoadedEndCallBack;

        //�ӳ�һ���
        GameApp.TimerManager.Register(1f, delegate () 
        {
            GetModel<LoadingModel>().callback?.Invoke();

            GameApp.ViewManager.Close((int)ViewType.LoadingView);
        });
    }
}
