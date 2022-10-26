using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED_MULT = 100;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpSpeed = 5;

    public Transform cameraTransform;
    public Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        int xMoveDir = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        rigidbody.velocity = new Vector2(xMoveDir * speed * Time.deltaTime * SPEED_MULT, rigidbody.velocity.y);

    }

    private void Update()
    {
        TestForSpecificKeys();
    }

    private void TestForSpecificKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
        }
    }
}
