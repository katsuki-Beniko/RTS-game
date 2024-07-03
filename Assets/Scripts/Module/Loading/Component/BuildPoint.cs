using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    public int LevelId;//…Ë÷√πÿø®Id

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("enter");
        GameApp.MsgCenter.PostEvent(Defines.ShowLevelDesEvent, LevelId);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("exit");
        GameApp.MsgCenter.PostEvent(Defines.HideLevelDesEvent);
    }
}
