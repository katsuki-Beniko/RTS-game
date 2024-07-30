using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChanger : MonoBehaviour
{

    public void Onbuttonclick()
    {
        GameApp.ViewManager.Open(ViewType.WinView);

    }
    public StartView startView;
    public void Onbuttonclick2()
    {
        startView.onStartGameBtn();

    }
}
