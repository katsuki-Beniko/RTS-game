using UnityEngine;
using UnityEngine.UI;

public class LossView : BaseView
{
    public Tips tips;

    protected override void OnStart()
    {
        base.OnStart();
        if (tips != null)
        {
            tips.DisplayRandomTip();
        }
        else
        {
            Debug.LogError("Tips reference is not set in the inspector.");
        }

        Find<Button>("okBtn").onClick.AddListener(delegate ()
        {
            GameApp.FightManager.ReLoadRes();
            GameApp.ViewManager.CloseAll();

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
