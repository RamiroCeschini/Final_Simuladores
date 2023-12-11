using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosYData : AutoDataHolder
{
    [SerializeField] private Transform planeTransform;
    private void Start()
    {
        StartMetod();
    }

    protected override void DataAction()
    {
        planeTransform.position = new Vector3 (planeTransform.position.x, data * 10, planeTransform.position.z);
    }
}
