using System.Collections.Generic;
using UnityEngine;

public class ModelBase : MonoBehaviour
{
    public int Id;
    public Dictionary<string, string> data;
    public int Step;
    public int Attack;
    public int Type;
    public int MaxHp;
    public int CurHp;

    public int RowIndex;
    public int ColIndex;
    public SpriteRenderer bodySp;
    public GameObject stopObj;
    public Animator ani;
    private bool _isStop;

    public bool IsStop
    {
        get
        {
            return _isStop;
        }
        set
        {
            stopObj.SetActive(value);

            if(value == true)
            {
                bodySp.color = Color.gray;
            }
            else
            {
                bodySp.color = Color.white;
            }

            _isStop = value;
        }
    }

    private void Awake()
    {
        bodySp = transform.Find("body").GetComponent<SpriteRenderer>();
        stopObj = transform.Find("stop").gameObject;
        ani = transform.Find("body").GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        AddEvents();
    }

    protected virtual void OnDestroy()
    {
        RemoveEvents();
    }

    protected virtual void AddEvents()
    {
        GameApp.MsgCenter.AddEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MsgCenter.AddEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    protected virtual void RemoveEvents()
    {
        GameApp.MsgCenter.RemoveEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MsgCenter.RemoveEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    protected virtual void OnSelectCallBack(System.Object arg)
    {
        GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);
        GameApp.MapManager.ShowStepGrid(this,Step);
    }

    protected virtual void OnUnSelectCallBack(System.Object arg)
    {
        GameApp.MapManager.HideStepGrid(this, Step);
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public virtual bool Move(int rowIndex,int colIndex,float dt)
    {
        Vector3 pos = GameApp.MapManager.GetBlockPos(rowIndex, colIndex);

        pos.z = transform.position.z;

        if(transform.position.x > pos.x && transform.localScale.x > 0)
        {
            Flip();
        }
        if (transform.position.x < pos.x && transform.localScale.x < 0)
        {
            Flip();
        }

        if(Vector3.Distance(transform.position,pos)<=0.02f)
        {
            this.RowIndex = rowIndex;
            this.ColIndex = colIndex;
            transform.position = pos;
            return true;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, dt);

        return false;
    }

    public void PlayAni(string aniName)
    {
        ani.Play(aniName);
    }

    //受伤
    public virtual void GetHit(ISkill skill)
    {

    }

    //播放特效（特效物体）
    public virtual void PlayEffect(string name)
    {
        GameObject obj = Instantiate(Resources.Load($"Effect/{name}")) as GameObject;
        obj.transform.position = transform.position;
    }
    
    //计算两个model的距离(根据行列下标计算)
    public float GetDis(ModelBase model)
    {
        return Mathf.Abs(RowIndex - model.RowIndex) + Mathf.Abs(ColIndex - model.ColIndex);
    }

    //播放音效（攻击，受伤等）
    public void PlaySound(string name)
    {
        GameApp.SoundManager.PlayEffect(name, transform.position);
    }

    //看向某个Model
    public void LookAtModel(ModelBase model)
    {
        if ((model.transform.position.x > transform.position.x) && transform.localScale.x < 0)
        {
            Flip();
        }
        else if((model.transform.position.x < transform.position.x) && transform.localScale.x > 0)
        {
            Flip();
        }
    }
}
