using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed;
    public Rigidbody2D rb2;
    private float xMove;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // Player Movement
    void Movement()
    {
        xMove = Input.GetAxis("Horizontal");
        if (xMove != 0)
        {
            rb2.velocity = new Vector2(xMove * PlayerSpeed, rb2.velocity.y);
        }
    }
}
