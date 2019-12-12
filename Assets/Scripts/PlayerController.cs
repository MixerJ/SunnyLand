using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2;
    // 处理动画
    public Animator anim;
    // player碰撞体
    public Collider2D cl2;
    // 玩家移动速度
    public float PlayerSpeed;
    // 玩家跳跃高度
    public float PlayerJumpHigher;
    // 移动
    private float xMove;
    // 反转人物面对显示方向
    private float faceMove;
    // 获取图层
    public LayerMask ground;


    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }

    // Player Movement
    void Movement()
    {
        xMove = Input.GetAxis("Horizontal"); ;
        faceMove = Input.GetAxisRaw("Horizontal");
        if (xMove != 0)
        {
            rb2.velocity = new Vector2(xMove * PlayerSpeed * Time.deltaTime, rb2.velocity.y);
            //anim.SetBool(, false);
            anim.SetFloat("running", Mathf.Abs(faceMove));
        }

        if (faceMove != 0)
        {
            transform.localScale = new Vector3(faceMove, 1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb2.velocity = new Vector2(rb2.velocity.x, PlayerJumpHigher * Time.deltaTime);
            anim.SetBool("jumping", true);
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("idleing", false);
        if (anim.GetBool("jumping"))
        {
            if (rb2.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (cl2.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idleing", true);
        }
    }
}
