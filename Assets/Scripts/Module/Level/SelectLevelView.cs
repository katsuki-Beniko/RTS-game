using UnityEngine.UI;
public class SelectLevelView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("close").onClick.AddListener(onCloseBtn);
        //绑定按钮事件，进入战斗关卡
        Find<Button>("level/fightBtn").onClick.AddListener(onFightBtn);
    }

    private void onCloseBtn()
    {
        GameApp.ViewManager.Close(ViewId);

        LoadingModel loadingModel = new LoadingModel();
        loadingModel.SceneName = "game";
        loadingModel.callback = delegate ()
        {
            Controller.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenStartView);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }

    public void ShowLevelDes()
    {
        Find("level").SetActive(true);
        LevelData current = Controller.GetModel<LevelModel>().current;
        Find<Text>("level/name/txt").text = current.Name;
        Find<Text>("level/des/txt").text = current.Des;
    }

    public void HideLevelDes()
    {
        Find("level").SetActive(false);
    }

    //切换到战斗场景
    private void onFightBtn()
    {
        //关闭当前界面
        GameApp.ViewManager.Close(ViewId);
        //摄像机重置位置
        GameApp.CameraManager.ResetPos();

        LoadingModel loadingModel = new LoadingModel();
        //跳转到战斗场景
        loadingModel.SceneName = Controller.GetModel<LevelModel>().current.SceneName;
        loadingModel.callback = delegate ()
        {
            //加载成功后显示战斗界面等
            Controller.ApplyControllerFunc(ControllerType.Fight,Defines.BeginFight);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }
}
