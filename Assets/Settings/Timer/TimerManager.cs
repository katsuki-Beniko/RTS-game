using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������һ��ȫ��ʱ���ʱ������
/// </summary>
public class TimerManager
{
    GameTimer timer;

    public TimerManager()
    {
        timer = new GameTimer();
    }

    public void Register(float time,System.Action callback)
    {
        timer.Register(time, callback);
    }

    public void OnUpdate(float dt)
    {
        timer.OnUpdate(dt);
    }
}
