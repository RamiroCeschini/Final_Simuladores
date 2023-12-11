using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropData : AutoDataHolder
{
    [SerializeField] private Transform dropZone;
    private void Start()
    {
        StartMetod();
    }

    protected override void DataAction()
    {
        dropZone.position = new Vector3(dropZone.position.x, dropZone.position.y, data);
    }
}
