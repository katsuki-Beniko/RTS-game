using UnityEngine.UI;

public class FightOptionDesView :BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("bg/turnBtn").onClick.AddListener(onChangeEnemyTurnBtn);
        Find<Button>("bg/gameOverBtn").onClick.AddListener(onGameOverBtn);
        Find<Button>("bg/cancelBtn").onClick.AddListener(onCancelBtn);
    }

    //����������Ϸ
    private void onGameOverBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
    }

    //�غϽ������л������˻غ�
    private void onChangeEnemyTurnBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
        //�޸�bug��׼����ť���֮�����������ѡ��ڣ����ܵ���غϽ���
        GameApp.FightManager.ChangeState(GameState.Enemy);//�л������˻غ�
    }

    //ȡ��
    private void onCancelBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
    }
}
