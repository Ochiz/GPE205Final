using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class SoldierPawn : Pawn
{
    private float nextShootTime;
    
    // Start is called before the first frame update
    public override void Start()
    {
        nextShootTime = Time.time;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }
    //functions to move tank below
    public override void MoveForward(bool sprint)
    {
        if (sprint)
        {
            mover.Move(transform.forward, sprintSpeed);
        }
        else
        {
            mover.Move(transform.forward, moveSpeed);
        }

    }
    
    public override void MoveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public override void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            shooter.Shoot(bulletPrefab, fireForce, damageDone, bulletLifespan);
            nextShootTime = Time.time + secondsPerShot;
        }
    }
}
