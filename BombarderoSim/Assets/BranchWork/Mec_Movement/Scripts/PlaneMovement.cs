using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public float currentAngle;
    [SerializeField] private Rigidbody bomRb;
    private bool isMoving;
    private Rigidbody rb;
    private FuelSystem fuelSystem;
    [SerializeField] private BombReleaseTmp bombRelease;
    [SerializeField] private SliderContoler dataManager;

    private float flightStartTime;
    public float flightTime;
    public float Speed { get { return speed; }}
    public float BombWeight { get { return bomRb.mass; }}

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fuelSystem = GetComponent<FuelSystem>();
    }

    public void StartPlane()
    {
        if (CanMove())
        {
            fuelSystem.SetPlaneMoving(true);
            rb.velocity = new Vector3(-Mathf.Sin(currentAngle * Mathf.Deg2Rad), 0, -Mathf.Cos(currentAngle * Mathf.Deg2Rad)) * speed;
            isMoving = true;
            flightStartTime = Time.time;
        }
    }
    private bool CanMove()
    {
        return fuelSystem.GetCurrentFuelPercentage() > 0f && !isMoving;
    }

    public void StopPlane()
    {
        fuelSystem.SetPlaneMoving(false);
        rb.velocity = Vector3.zero;
        if (bomRb != null) { bomRb.velocity = Vector3.zero; }
        isMoving = false;
        flightTime = Time.time - flightStartTime;
        dataManager.flightTime = flightTime;
        dataManager.SaveResultData();
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
            bombRelease.ReleaseBomb();
        }
    }
}
