using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatizationManager : MonoBehaviour
{
    private DataManager_TMP dataManager;
    private bool isSimulating = false;

    private float dato1Value;
    private float dato2Value;
    private float dato3Value;

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

                if (randomData == "Dato1")
                {
                    dato2Value = dataManager.dato2;
                    dato3Value = dataManager.dato3;

                    dataManager.SetDato1(0);
                    dato1Value = dataManager.dato1;
                }
                else if (randomData == "Dato2")
                {
                    dato1Value = dataManager.dato1;
                    dato3Value = dataManager.dato3;

                    dataManager.SetDato2(0);
                    dato2Value = dataManager.dato2;
                }
                else if (randomData == "Dato3")
                {
                    dato1Value = dataManager.dato1;
                    dato2Value = dataManager.dato2;

                    dataManager.SetDato3(0);
                    dato3Value = dataManager.dato3;
                }

                InvokeRepeating("Simulation", 0f, 1f);
            }
        }
    }

    private void Simulation()
    {
        Result();
        if (randomData == "Dato1")
        {
            dataManager.SetDato1(dato1Value + 1);
            dato1Value = dataManager.dato1;
        }
        else if (randomData == "Dato2")
        {
            dataManager.SetDato2(dato2Value + 1);
            dato2Value = dataManager.dato2;
        }
        else if (randomData == "Dato3")
        {
            dataManager.SetDato3(dato3Value + 1);
            dato3Value = dataManager.dato3;
        }
        isSimulating = false;
    }



    public void Result()
    {
        float result = dato1Value + dato2Value + dato3Value;
        Debug.Log("Result: " +  result);
    }

}
