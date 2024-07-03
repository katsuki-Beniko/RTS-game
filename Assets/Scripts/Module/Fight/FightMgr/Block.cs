using UnityEngine;

public enum BlockType
{
    Null,
    Obstacle
}

public class Block : MonoBehaviour
{
    public int RowIndex;
    public int ColIndex;
    public BlockType Type;
    private SpriteRenderer selectSp; 
    private SpriteRenderer gridSp; 
    private SpriteRenderer dirSp; 

    private void Awake()
    {
        selectSp = transform.Find("select").GetComponent<SpriteRenderer>();
        gridSp = transform.Find("grid").GetComponent<SpriteRenderer>();
        dirSp = transform.Find("dir").GetComponent<SpriteRenderer>();
        GameApp.MsgCenter.AddEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MsgCenter.AddEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    private void OnDestroy()
    {
        GameApp.MsgCenter.RemoveEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MsgCenter.RemoveEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    public void ShowGrid(Color color)
    {
        gridSp.enabled = true;
        gridSp.color = color;
    }

    public void HideGrid()
    {
        gridSp.enabled = false;
    }
    //改动
    void OnSelectCallBack(System.Object arg)
    {
        GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);
        if(GameApp.CommandManager.IsRunningCommand == false 
            && GameApp.FightManager.state == GameState.Player)
        {
            GameApp.ViewManager.Open(ViewType.FightOptionDesView);
        }
    }

    //未选中
    void OnUnSelectCallBack(System.Object arg)
    {
        dirSp.sprite = null;
        GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
    }

    private void OnMouseEnter()
    {
        selectSp.enabled = true;
    }

    private void OnMouseExit()
    {
        selectSp.enabled = false;
    }

    public void SetDirSp(Sprite sp,Color color)
    {
        dirSp.sprite = sp;
        dirSp.color = color;
    }
}
