using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 玩家移动速度
    public float PlayerSpeed;
    // 玩家跳跃高度
    public float PlayerJumpHigher;
    public Rigidbody2D rb2;
    // 移动
    private float xMove;
    // 反转人物面对显示方向
    private float faceMove;

    // Update is called once per frame
    void FixedUpdate() => Movement();

    // Player Movement
    void Movement()
    {
        xMove = Input.GetAxis("Horizontal");;
        faceMove = Input.GetAxisRaw("Horizontal");
        if (xMove != 0)
        {
            rb2.velocity = new Vector2(xMove * PlayerSpeed * Time.deltaTime, rb2.velocity.y);
        }

        if(faceMove != 0)
        {
            transform.localScale = new Vector3(faceMove, 1, 1);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            rb2.velocity = new Vector2(rb2.velocity.x, PlayerJumpHigher * Time.deltaTime);
        }
    }
}
