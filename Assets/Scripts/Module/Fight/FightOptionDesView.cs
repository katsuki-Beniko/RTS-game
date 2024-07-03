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

    //结束本局游戏
    private void onGameOverBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
    }

    //回合结束，切换到敌人回合
    private void onChangeEnemyTurnBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
        //修复bug：准备按钮点击之后才能允许开启选项窗口，才能点击回合结束
        GameApp.FightManager.ChangeState(GameState.Enemy);//切换到敌人回合
    }

    //取消
    private void onCancelBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
    }
}
