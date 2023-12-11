using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TMP_CanvasManager : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollBarResults;
    private bool currentCanvas = false;
    public void ChangeResultCanvas(CanvasConteiner conteiner)
    {
        if (!currentCanvas)
        {
            conteiner.Canvas1.SetActive(false);
            conteiner.Canvas2.SetActive(true);
            scrollBarResults.value = 1;
            currentCanvas = true;
        }
        else
        {
            conteiner.Canvas2.SetActive(false);
            conteiner.Canvas1.SetActive(true);
            currentCanvas = false;
        }
    }
    public void ChangeCanvas(CanvasConteiner conteiner)
    {
        if (!currentCanvas)
        {
            conteiner.Canvas1.SetActive(false);
            conteiner.Canvas2.SetActive(true);
            currentCanvas = true;
        }
        else
        {
            conteiner.Canvas2.SetActive(false);
            conteiner.Canvas1.SetActive(true);
            currentCanvas = false;
        }
    }


}
