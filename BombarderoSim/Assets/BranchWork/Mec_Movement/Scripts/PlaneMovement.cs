using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float currentAngle;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartPlane();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StopPlane();
        }
    }

    public void StartPlane()
    {
        rb.velocity = new Vector3(-Mathf.Sin(currentAngle * Mathf.Deg2Rad),0,- Mathf.Cos(currentAngle * Mathf.Deg2Rad)) * speed;
    }

    public void StopPlane()
    {
        rb.velocity = Vector3.zero;
    }

    public void BarrelRotationX(float rotationX)
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationX, transform.localEulerAngles.z);
        currentAngle = rotationX;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ZLimit"))
        {
            Debug.Log("BombDrop");
        }
    }
}
