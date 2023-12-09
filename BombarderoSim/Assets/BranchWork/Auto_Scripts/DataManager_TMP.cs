using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager_TMP : MonoBehaviour
{
    public List<AutoDataHolder> dataHolderList;

    private AutomatizationManager automatizationManager;

    private void Start()
    {
        automatizationManager = GetComponent<AutomatizationManager>();
        for (int i = 0; i < dataHolderList.Count; i++)
        {
            SetData(0, dataHolderList[i].dataType);
        }
    }

    public void SetData(float dataValue, string dataT)
    {
        for (int i = 0; i < dataHolderList.Count; i++)
        {
            if (dataHolderList[i].dataType == dataT) 
            {
                dataHolderList[i].dataText.text = dataHolderList[i].dataType + ": " + dataHolderList[i].data;
                dataHolderList[i].data = dataValue;
            }
        }
    }

    public void PickData(string dataT)
    {
        for (int i = 0; i < dataHolderList.Count; i++)
        {
            if (dataHolderList[i].dataType == dataT)
            {
                dataHolderList[i].dataSlider.gameObject.SetActive(false);
                automatizationManager.randomData = dataHolderList[i].dataType;
            }
            else
            {
                dataHolderList[i].dataSlider.gameObject.SetActive(true);
            }
        }
    }

    public void SimulationStarted()
    {
        foreach (var dataHolder in dataHolderList)
        {
            dataHolder.dataSlider.gameObject.SetActive(true);
            dataHolder.dataSlider.interactable = false;
        }
    }
}
