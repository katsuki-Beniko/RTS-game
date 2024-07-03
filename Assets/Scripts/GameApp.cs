public class GameApp : Singleton<GameApp>
{
    public static SoundManager SoundManager;

    public static ControllerManager ControllerManager;

    public static ViewManager ViewManager;

    public static ConfigManager ConfigManager;

    public static CameraManager CameraManager;

    public static MessageCenter MsgCenter;

    public static TimerManager TimerManager;

    public static FightWorldManager FightManager;

    public static MapManager MapManager;

    public static GameDataManager GameDataManager;

    public static UserInputManager UserInputManager;

    public static CommandManager CommandManager;

    //技能管理
    public static SkillManager SkillManager;

    public override void Init()
    {
        UserInputManager = new UserInputManager();
        TimerManager = new TimerManager();
        MsgCenter = new MessageCenter();
        CameraManager = new CameraManager();
        SoundManager = new SoundManager();
        ConfigManager = new ConfigManager();
        ControllerManager = new ControllerManager();
        FightManager = new FightWorldManager();
        MapManager = new MapManager();
        ViewManager = new ViewManager();
        CommandManager = new CommandManager();
        GameDataManager = new GameDataManager();
        SkillManager = new SkillManager();
    }

    public override void Update(float dt)
    {
        UserInputManager.Update();
        TimerManager.OnUpdate(dt);
        FightManager.Update(dt);
        CommandManager.Update(dt);
        SkillManager.Update(dt);
    }
}
