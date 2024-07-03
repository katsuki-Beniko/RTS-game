using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
        GameApp.CameraManager.SetPos(transform.position);
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if(h == 0)
        {
            ani.Play("Character_Idle");
        }
        else
        {
            if ((h > 0 && transform.localScale.x < 0) ||(h < 0 && transform.localScale.x > 0))
            {
                Flip();
            }
        
            Vector3 pos = transform.position + Vector3.right * h * moveSpeed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, -32, 24);
            transform.position = pos;
            GameApp.CameraManager.SetPos(transform.position);
            ani.Play("Character_running_right");
        }
    }

    //×ªÏò
    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
