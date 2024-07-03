using UnityEngine;
using UnityEngine.UI;

public class StartView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();

        Find<Button>("startBtn").onClick.AddListener(onStartGameBtn);
        Find<Button>("setBtn").onClick.AddListener(onSetBtn);
        Find<Button>("quitBtn").onClick.AddListener(onQuitGameBtn);
    }

    //开始游戏
    private void onStartGameBtn()
    {
        GameApp.ViewManager.Close(ViewId);

        LoadingModel loadingModel = new LoadingModel();
        loadingModel.SceneName = "map";
        loadingModel.callback = delegate () 
        {
            //打开选择关卡界面
            Controller.ApplyControllerFunc(ControllerType.Level,Defines.OpenSelectLevelView);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading,Defines.LoadingScene,loadingModel);
    }

    private void onSetBtn()
    {
        ApplyFunc(Defines.OpenSetView);
    }

    private void onQuitGameBtn()
    {
        Controller.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenMessageView, new MessageInfo()
        {
            okCallBack = delegate () 
            {
                Application.Quit();
            },
            MsgTxt = "Are you sure, you want to exit the game?"
        });
    }
}
