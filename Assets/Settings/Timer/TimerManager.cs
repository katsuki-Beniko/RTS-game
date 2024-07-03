using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 简单制作一个全局时间计时管理器
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
