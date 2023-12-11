using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStats : MonoBehaviour
{
    public DamageDetector detector;
    
    public void OnCollisionEnter(Collision collision)
    {
        detector.Explosion();
    }
}
