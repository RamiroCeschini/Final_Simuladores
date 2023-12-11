using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelData : AutoDataHolder
{
    [SerializeField] private FuelSystem fuel;
    private void Start()
    {
        StartMetod();
    }

    protected override void DataAction()
    {
        fuel.currentFuel = data;
    }
}
