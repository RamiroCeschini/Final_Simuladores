using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatizationManager : MonoBehaviour
{
    private DataManager_TMP dataManager;

    private bool isSimulating = false;
    private bool firstSimulated = true;
    private bool lastData = false;

    public string randomData;

    private void Start()
    {
        dataManager = GetComponent<DataManager_TMP>();
    }
    public void StartSimulation()
    {
        if (randomData != "none")
        {
            if (!isSimulating)
            {
                isSimulating = true;
                dataManager.SimulationStarted();

                for (int i = 0; i < dataManager.dataHolderList.Count; i++) 
                {
                    if(randomData == dataManager.dataHolderList[i].dataType) 
                    {
                        dataManager.dataHolderList[i].dataSlider.value = dataManager.dataHolderList[i].dataSlider.minValue;
                        dataManager.SetData(dataManager.dataHolderList[i].dataSlider.value, dataManager.dataHolderList[i].dataType);
                    }
                }

                isSimulating = true;
                Simulation();
            }
        }
    }

    public void NewSimulation()
    {
        if (isSimulating) { Simulation(); }
    }

    private void Simulation()
    {
        if (firstSimulated)
        {
            firstSimulated = false;
            Result();
            return;
        }

        for (int i = 0; i < dataManager.dataHolderList.Count; i++)
        {
            if(randomData == dataManager.dataHolderList[i].dataType)
            {
                dataManager.dataHolderList[i].dataSlider.value += 1;
                dataManager.SetData(dataManager.dataHolderList[i].dataSlider.value, dataManager.dataHolderList[i].dataType);
                if (!lastData) { Result(); }
                if (dataManager.dataHolderList[i].dataSlider.value == dataManager.dataHolderList[i].dataSlider.maxValue)
                {
                    if (lastData)
                    {
                        Debug.Log("Whole Simulation Finished");
                        return;
                    }
                    lastData = true;
                }
            }
        }
        
    }



    public void Result()
    {
        float result = 0;
        for (int i = 0; i < dataManager.dataHolderList.Count; i++)
        {
            result += dataManager.dataHolderList[i].data;
        }
        Debug.Log("Result: " +  result);

    }

}
