using UnityEngine;
using UnityEngine.UI;

public class DragHeroView : BaseView
{
    private void Update()
    {
        //拖拽中跟随鼠标移动，显示的时候才进行移动
        if(_canvas.enabled == false)
        {
            return;
        }

        //鼠标坐标转换成世界坐标
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = worldPos;
    }

    public override void Open(params object[] args)
    {
        transform.GetComponent<Image>().SetIcon(args[0].ToString());
    }
}
