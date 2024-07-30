/// <summary>
/// 命令基类（可派生，移动，使用技能等）
/// </summary>
public class BaseCommand
{
    public ModelBase model;
    protected bool isFinish;

    public BaseCommand()
    {

    }

    public BaseCommand(ModelBase model)
    {
        this.model = model;
        isFinish = false;
    }

    public virtual bool Update(float dt)
    {
        return isFinish;
    }

    //执行命令
    public virtual void Do()
    {

    }

    //撤销命令
    public virtual void UnDo()
    {

    }
}
