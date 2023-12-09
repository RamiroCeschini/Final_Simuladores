using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TMP_CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject SliderCanvas;
    [SerializeField] private GameObject DataCanvas;
    [SerializeField] private Scrollbar scrollBarResults;
    private bool currentCanvas = false;
    public void ChangeCanvas()
    {
        if (!currentCanvas)
        {
            SliderCanvas.SetActive(false);
            DataCanvas.SetActive(true);
            scrollBarResults.value = 1;
            currentCanvas = true;
        }
        else
        {
            DataCanvas.SetActive(false);
            SliderCanvas.SetActive(true);
            currentCanvas = false;
        }
    }

}
