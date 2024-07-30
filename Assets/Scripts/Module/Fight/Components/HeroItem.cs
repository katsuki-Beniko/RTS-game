using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroItem : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    Dictionary<string, string> data;

    private void Start()
    {
        transform.Find("icon").GetComponent<Image>().SetIcon(data["Icon"]);
    }


    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameApp.ViewManager.Open(ViewType.DragHeroView, data["Icon"]);
    }

    //½áÊøÍÏ×§
    public void OnEndDrag(PointerEventData eventData)
    {
        GameApp.ViewManager.Close((int)ViewType.DragHeroView);

        Tools.ScreenPointToRay2D(eventData.pressEventCamera, eventData.position, delegate (Collider2D col)
        {
            if(col != null)
            {
                Block b = col.GetComponent<Block>();
                if(b!=null)
                {
                    Debug.Log(b);
                    Destroy(gameObject);
                    GameApp.FightManager.AddHero(b, data);
                }
            }
        });
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
