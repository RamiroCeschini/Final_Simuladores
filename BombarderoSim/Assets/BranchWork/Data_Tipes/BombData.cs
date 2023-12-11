using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombData : AutoDataHolder
{
    [SerializeField] private DamageDetector bomb;
    private void Start()
    {
        StartMetod();
    }

    protected override void DataAction()
    {
        bomb.bomPeso = data;
    }
}
