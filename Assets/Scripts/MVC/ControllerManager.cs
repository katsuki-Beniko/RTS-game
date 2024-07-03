using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ������������
/// </summary>
public class ControllerManager
{
    private Dictionary<int, BaseController> _modules;//�洢���������ֵ�

    public ControllerManager()
    {
        _modules = new Dictionary<int, BaseController>();
    }

    public void Register(ControllerType type,BaseController ctl)
    {
        Register((int)type,ctl);
    }

    //ע�������
    public void Register(int controllerKey,BaseController ctl)
    {
        if(_modules.ContainsKey(controllerKey) == false)
        {
            _modules.Add(controllerKey,ctl);
        }
    }

    //ִ�����п�����Init����
    public void InitAllModules()

    {
        foreach(var item in _modules)
        {
            item.Value.Init();
        }
    }

    //�Ƴ�������
    public void UnRegister(int controllerKey)
    {
        if(_modules.ContainsKey(controllerKey))
        {
            _modules.Remove(controllerKey);
        }
    }

    //���
    public void Clear()
    {
        _modules.Clear();
    }

    //���ȫ��������
    public void ClearAllModules()
    {
        List<int> keys = _modules.Keys.ToList();
        for(int i = 0;i<keys.Count;i++)
        {
            _modules[keys[i]].Destroy();
            _modules.Remove(keys[i]);
        }
    }

    //��ģ�崥����Ϣ
    public void ApplyFunc(int controllerKey,string eventName, System.Object[] args)
    {
        if(_modules.ContainsKey(controllerKey))
        {
            _modules[controllerKey].ApplyFunc(eventName, args);
        }
    }

    public BaseModel GetControllerModel(int controllerKey)
    {
        if(_modules.ContainsKey(controllerKey))
        {
            return _modules[controllerKey].GetModel();
        }
        else
        {
            return null;
        }
    }
}
