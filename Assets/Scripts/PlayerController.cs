using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED_MULT = 100;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private LayerMask floorMask;

    private Rigidbody2D rigidbody;
    private Animator anim;
    private SpriteRenderer render;
    private BoxCollider2D boxColl;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        int xMoveDir = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        rigidbody.velocity = new Vector2(xMoveDir * speed * Time.deltaTime * SPEED_MULT, rigidbody.velocity.y);
        anim.SetFloat("xSpeed", Mathf.Abs(xMoveDir));
        FlipXIfNeeded(xMoveDir);
    }

    private void FlipXIfNeeded(int moveDir)
    {
        if (moveDir != 0)
        {
            render.flipX = moveDir < 0;
        }
    }

    private void Update()
    { 
        TestForSpecificKeys();
    }

    private void TestForSpecificKeys()
    {
        if (Input.GetKey(KeyCode.Space) && anim.GetBool("isGrounded"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            anim.SetBool("isGrounded", false);
        }
        anim.SetBool("isDucking", Input.GetKey(KeyCode.S) && anim.GetBool("isGrounded") && anim.GetFloat("xSpeed") == 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("isGrounded", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("isGrounded", false);
    }
}
