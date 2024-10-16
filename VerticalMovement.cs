using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float JumpForce = 5f;
    private bool isGrounded;
    private Rigidbody2D sonicbody;

    void Start()
    {
        sonicbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void Update()
    {
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            sonicbody.velocity = new Vector2(sonicbody.velocity.x, JumpForce);
        }
    }


}
