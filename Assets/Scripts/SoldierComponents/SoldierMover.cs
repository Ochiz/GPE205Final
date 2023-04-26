using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMover : Mover
{
    //variable declaration
    private Rigidbody rb;
    private Transform tf;
    // Start is called before the first frame update
    public override void Start()
    {
        //get statements
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // function to move pawn
    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }
    //function to rotate pawn
    public override void Rotate(float turnSpeed)
    {
        turnSpeed = turnSpeed * Time.deltaTime;
        tf.Rotate(0, turnSpeed, 0);
    }
}
