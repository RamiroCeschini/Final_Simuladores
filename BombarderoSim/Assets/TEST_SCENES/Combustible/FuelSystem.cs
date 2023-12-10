using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] private float maxFuel = 100f;
    [SerializeField] private float fuelConsumptionRate = 5f; 
    private PlaneMovement planeMovement;
    public float currentFuel;
    private bool isPlaneMoving = false;

    private void Start()
    {
        planeMovement = GetComponent<PlaneMovement>();
        CalculateConsumptionRate();
    }

    private void Update()
    {
        if (isPlaneMoving)
        {
            ConsumeFuel();
        }
    }
    public void SetPlaneMoving(bool moving)
    {
        isPlaneMoving = moving;
    }

    public void ConsumeFuel()
    {
        if (currentFuel > 0f)
        {
            float fuelConsumed = fuelConsumptionRate * Time.deltaTime;
            currentFuel = Mathf.Max(0f, currentFuel - fuelConsumed);
            //Debug.Log("Combustible restante: " + currentFuel.ToString("F2") + " %");
        }
        else
        {
            planeMovement.StopPlane();
        }
    }

    private void CalculateConsumptionRate()
    {
        fuelConsumptionRate += planeMovement.Speed * 0.01f;
        Debug.Log(fuelConsumptionRate);
        fuelConsumptionRate += planeMovement.BombWeight * 0.01f;
        Debug.Log(fuelConsumptionRate);
    }

    public float GetCurrentFuelPercentage()
    {
        return currentFuel / maxFuel;
    }

    public void Refuel(float amount)
    {
        currentFuel = Mathf.Min(maxFuel, currentFuel + amount);
    }
}