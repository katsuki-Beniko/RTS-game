using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSelectHeroView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("bottom/startBtn").onClick.AddListener(onFightBtn);
    }

    private void onFightBtn()
    {
        if(GameApp.FightManager.heros.Count == 0)
        {
            Debug.Log("No hero is on the field");
        }
        else
        {
            GameApp.ViewManager.Close(ViewId);

            //切换到玩家回合
            GameApp.FightManager.ChangeState(GameState.Player);
        }
    }

    public override void Open(params object[] args)
    {
        base.Open(args);

        GameObject prefabObj = Find("bottom/grid/item");

        Transform gridTf = Find("bottom/grid").transform;

        for(int i=0;i<GameApp.GameDataManager.heros.Count;i++)
        {
            Dictionary<string, string> data = GameApp.ConfigManager.GetConfigData("player").GetDataById(GameApp.GameDataManager.heros[i]);

            GameObject obj = Object.Instantiate(prefabObj, gridTf);

            obj.SetActive(true);

            HeroItem item = obj.AddComponent<HeroItem>();
            item.Init(data);
        }
    }
}
