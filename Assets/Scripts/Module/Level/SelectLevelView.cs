using UnityEngine.UI;
public class SelectLevelView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("close").onClick.AddListener(onCloseBtn);
        //�󶨰�ť�¼�������ս���ؿ�
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

    //�л���ս������
    private void onFightBtn()
    {
        //�رյ�ǰ����
        GameApp.ViewManager.Close(ViewId);
        //���������λ��
        GameApp.CameraManager.ResetPos();

        LoadingModel loadingModel = new LoadingModel();
        //��ת��ս������
        loadingModel.SceneName = Controller.GetModel<LevelModel>().current.SceneName;
        loadingModel.callback = delegate ()
        {
            //���سɹ�����ʾս�������
            Controller.ApplyControllerFunc(ControllerType.Fight,Defines.BeginFight);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }
}
