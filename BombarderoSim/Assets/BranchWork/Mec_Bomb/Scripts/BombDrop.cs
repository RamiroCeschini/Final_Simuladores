using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombDrop : MonoBehaviour
{
    public float BombWeight;
    
    // Start is called before the first frame update
    void Start()
    {
        BombsWeight(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BombsWeight(float weight)
    {
        BombWeight = weight * 0.4f + 8;
        
    }
    
}
