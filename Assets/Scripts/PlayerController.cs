using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ����ƶ��ٶ�
    public float PlayerSpeed;
    // �����Ծ�߶�
    public float PlayerJumpHigher;
    public Rigidbody2D rb2;
    // �ƶ�
    private float xMove;
    // ��ת���������ʾ����
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
