using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombReleaseTmp : MonoBehaviour
{
    public GameObject bomb;
    public Joint joint;
    public Rigidbody rb;
   
    public void ReleaseBomb()
    {
        Debug.Log("shoot");
        joint.breakForce = 0f;
        joint.breakTorque = 0f;
        rb.useGravity = true;
        rb.AddForce(0, -1, 0);
    }
}
