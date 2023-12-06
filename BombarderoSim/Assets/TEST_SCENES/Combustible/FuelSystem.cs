using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] private float maxFuel = 100f;
    [SerializeField] private float fuelConsumptionRate = 5f; // Ajusta según sea necesario
    private float currentFuel;
    private bool isPlaneMoving = false;
    private void Start()
    {
        currentFuel = maxFuel;
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
            Debug.Log("Combustible restante: " + currentFuel.ToString("F2") + " %");
        }
        else
        {
            // El combustible está agotado, detener el avión
            GetComponent<PlaneMovement>().StopPlane();
        }
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