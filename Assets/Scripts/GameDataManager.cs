using System.Collections.Generic;

/// <summary>
/// 游戏数据管理器（存储玩家基本的游戏信息）
/// </summary>
public class GameDataManager
{
    public List<int> heros;//可选英雄集合

    public int Money;//金币
    public GameDataManager()
    {
        heros = new List<int>();

        //根据play.txt文本，默认预存前三个英雄的id
        heros.Add(10001);
        heros.Add(10002);
        heros.Add(10003);

    }
}
