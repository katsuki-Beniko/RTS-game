public class GameTimerData
{
    private float timer; //��ʱʱ��
    private System.Action callback;//�ص�

    public GameTimerData(float timer,System.Action callback)
    {
        this.timer = timer;
        this.callback = callback;
    }

    public bool OnUpdate(float dt)
    {
        timer -= dt;
        if(timer <= 0)
        {
            this.callback.Invoke();
            return true;
        }
        return false;
    }
}
