using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2;
    // ������
    public Animator anim;
    // player��ײ��
    public Collider2D cl2;
    // ����ƶ��ٶ�
    public float PlayerSpeed;
    // �����Ծ�߶�
    public float PlayerJumpHigher;
    // �ƶ�
    private float xMove;
    // ��ת���������ʾ����
    private float faceMove;
    // ��ȡͼ��
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
