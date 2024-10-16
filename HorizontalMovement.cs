using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField]private float Movement_Speed = 5f;
    [SerializeField]private float input;
    [SerializeField]private Rigidbody2D sonicbody;
    [SerializeField]private Turning turn;
    [SerializeField]private float deceleration = 15f;
    [SerializeField]private float acceleration = 10f;
    private float currentSpeed = 0f;
    void Start()
    {
        sonicbody = GetComponent<Rigidbody2D>();   
        turn = GetComponent<Turning>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");

        if(input != 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, input * Movement_Speed, acceleration * Time.deltaTime);
        } else {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }
        Debug.Log("CurrentSpeed: " + currentSpeed)
        sonicbody.velocity = new Vector2(currentSpeed, sonicbody.velocity.y);

        turn.TurnPlayerAround(input);
    }
}
