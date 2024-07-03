using UnityEngine;

public class GameScene : MonoBehaviour
{
    public Texture2D mouseTxt;
    float dt;
    private static bool isLoaded = false;

    private void Awake()
    {
        if(isLoaded == true)
        {
            Destroy(gameObject);
        }
        else
        {
            isLoaded = true;
            DontDestroyOnLoad(gameObject);
            GameApp.Instance.Init();
        }
    }

    void Start()
    {
        Cursor.SetCursor(mouseTxt, Vector2.zero, CursorMode.Auto);

        //◊¢≤·≈‰÷√±Ì
        RegisterConfigs();

        GameApp.ConfigManager.LoadAllConfigs();//º”‘ÿ≈‰÷√±Ì

        //≤‚ ‘≈‰÷√±Ì
        ConfigData tempData = GameApp.ConfigManager.GetConfigData("enemy");
        string name = tempData.GetDataById(10001)["Name"];
        Debug.Log(name);

        GameApp.SoundManager.PlayBGM("login");
        RegisterModule();
        InitModule();
    }

    void RegisterModule()
    {
        GameApp.ControllerManager.Register(ControllerType.GameUI,new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game,new GameController());
        GameApp.ControllerManager.Register(ControllerType.Loading,new LoadingController());
        GameApp.ControllerManager.Register(ControllerType.Level, new LevelController());
        GameApp.ControllerManager.Register(ControllerType.Fight,new FightController());
    }

    void InitModule()
    {
        GameApp.ControllerManager.InitAllModules();
    }

    //◊¢≤·≈‰÷√±Ì
    void RegisterConfigs()
    {
        GameApp.ConfigManager.Register("enemy",new ConfigData("enemy"));
        GameApp.ConfigManager.Register("level", new ConfigData("level"));
        GameApp.ConfigManager.Register("option", new ConfigData("option"));
        GameApp.ConfigManager.Register("player", new ConfigData("player"));
        GameApp.ConfigManager.Register("role", new ConfigData("role"));
        GameApp.ConfigManager.Register("skill", new ConfigData("skill"));
    }

    void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
    }
}
