using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosXData : AutoDataHolder
{
    [SerializeField] private Transform planeTransform;
    private void Start()
    {
        StartMetod();
    }

    protected override void DataAction()
    {
        planeTransform.position = new Vector3(data * -10, planeTransform.position.y, planeTransform.position.z);
    }
}
