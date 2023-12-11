using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleData : AutoDataHolder
{
    [SerializeField] private Transform planeTransform;
    [SerializeField] private PlaneMovement plane;
    private void Start()
    {
        StartMetod();
    }

    protected override void DataAction()
    {
        planeTransform.localEulerAngles = new Vector3(transform.localEulerAngles.x, data , transform.localEulerAngles.z);
        plane.currentAngle = data;
    }
}
