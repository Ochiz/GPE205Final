using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Start();
    //functions to be overwritten
    public abstract void Move(Vector3 direction, float speed);
    public abstract void Rotate(float turnSpeed);
}
