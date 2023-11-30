using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombReleaseTmp : MonoBehaviour
{
    public GameObject bomb;
    public BombDrop dataBomb;
    public Joint joint;
    public Rigidbody rb;
   
    public void ReleaseBomb()
    {
        joint.breakForce = 0f;
        rb.AddForce(0, -1, 0);
    }
}
