using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class cutscenetransfer : BaseView
{
    public Button levelDescriptionButton;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger.");
            levelDescriptionButton.gameObject.SetActive(true);
        }
    }
    public void Changed()
    {
        SceneManager.LoadScene("Cutscene");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("exit");
        GameApp.MsgCenter.PostEvent(Defines.HideLevelDesEvent);
    }
}
