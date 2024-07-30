using UnityEngine.UI;

public class FightOptionDesView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("bg/turnBtn").onClick.AddListener(onChangeEnemyTurnBtn);
        Find<Button>("bg/gameOverBtn").onClick.AddListener(onGameOverBtn);
        Find<Button>("bg/cancelBtn").onClick.AddListener(onCancelBtn);
    }

    private void onGameOverBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
    }

    private void onChangeEnemyTurnBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
        GameApp.FightManager.ChangeState(GameState.Enemy);
        GameApp.FightManager.IncrementRound(); // Increment round count on state change
    }

    private void onCancelBtn()
    {
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
    }
}
