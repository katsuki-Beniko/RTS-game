using UnityEngine.UI;

public class LossView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("okBtn").onClick.AddListener(delegate ()
        {
            //ж��ս���е���Դ
            GameApp.FightManager.ReLoadRes();
            GameApp.ViewManager.CloseAll();

            //�л�����
            LoadingModel load = new LoadingModel();
            load.SceneName = "map";
            load.callback = delegate ()
            {
                GameApp.SoundManager.PlayBGM("mapbgm");
                GameApp.ViewManager.Open(ViewType.SelectLevelView);
            };
            Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, load);
        });
    }
}
