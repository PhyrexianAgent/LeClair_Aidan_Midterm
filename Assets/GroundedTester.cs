using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedTester : MonoBehaviour
{
    private bool isGrounded = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public void SetToNotGrounded()
    {
        isGrounded = false;
    }
}
