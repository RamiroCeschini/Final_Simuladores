using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStats : MonoBehaviour
{
    public Rigidbody rb;
    

    // Start is called before the first frame update
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
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("BOOOOM");
        }
    }
}
