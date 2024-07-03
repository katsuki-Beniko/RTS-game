using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 选项
/// </summary>
public class OptionItem : MonoBehaviour
{
    OptionData op_data;

    public void Init(OptionData data)
    {
        op_data = data;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate () 
        {
            GameApp.MsgCenter.PostTempEvent(op_data.EventName);//执行配置表中设置的event事件
            GameApp.ViewManager.Close((int)ViewType.SelectOptionView);//关闭选项界面
        });
        transform.Find("txt").GetComponent<Text>().text = op_data.Name;
    }
}
