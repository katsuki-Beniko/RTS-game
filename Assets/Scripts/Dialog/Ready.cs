using UnityEngine;
using UnityEngine.SceneManagement;

public class Ready : MonoBehaviour
{
    public int LevelId;

    public void Onbuttonclick()
    {
        LevelId = 1001;

        GameApp.MsgCenter.PostEvent(Defines.ShowLevelDesEvent, LevelId = 1001);
    }


}