using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderContoler : MonoBehaviour
{
    [SerializeField] private List<AutoDataHolder> autoDataHolders;

    public void UnableSliders(bool active)
    {
        foreach (AutoDataHolder holder in autoDataHolders)
        {
            holder.dataSlider.interactable = active;
        }
    }
}
