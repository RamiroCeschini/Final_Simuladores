using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TMP_CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject Canvas1;
    [SerializeField] private GameObject Canvas2;
    [SerializeField] private Scrollbar scrollBarResults;
    private bool currentCanvas = false;
    public void ChangeResultCanvas()
    {
        if (!currentCanvas)
        {
            Canvas1.SetActive(false);
            Canvas2.SetActive(true);
            scrollBarResults.value = 1;
            currentCanvas = true;
        }
        else
        {
            Canvas2.SetActive(false);
            Canvas1.SetActive(true);
            currentCanvas = false;
        }
    }
    public void ChangeCanvas()
    {
        if (!currentCanvas)
        {
            Canvas1.SetActive(false);
            Canvas2.SetActive(true);
            currentCanvas = true;
        }
        else
        {
            Canvas2.SetActive(false);
            Canvas1.SetActive(true);
            currentCanvas = false;
        }
    }


}
