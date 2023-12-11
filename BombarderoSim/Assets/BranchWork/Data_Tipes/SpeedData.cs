using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedData : AutoDataHolder
{
    [SerializeField] private PlaneMovement planeMovement;

    private void Start()
    {
        StartMetod();
    }

    protected override void DataAction()
    {
        planeMovement.speed = data;
    }
}
