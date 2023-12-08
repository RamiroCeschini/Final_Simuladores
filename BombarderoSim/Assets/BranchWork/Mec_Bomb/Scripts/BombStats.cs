using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStats : MonoBehaviour
{
    public Rigidbody rb;
    public DamageDetector detector;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Weight(float weight)
    {
        rb.mass = weight;
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        detector.Explosion();
    }
}
