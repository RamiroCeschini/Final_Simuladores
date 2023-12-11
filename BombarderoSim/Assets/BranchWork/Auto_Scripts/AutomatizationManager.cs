using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutomatizationManager : MonoBehaviour
{
    private DataManager_TMP dataManager;

    [SerializeField] private TextMeshProUGUI textResults;
    [SerializeField] private RectTransform textRect;
    [SerializeField] private GameObject startButton;
    [SerializeField] private PlaneMovement planeMov;
    [SerializeField] private SliderContoler sliderManager;
    [SerializeField] private TMP_CanvasManager canvasManager;
    [SerializeField] private CanvasConteiner canvasConteiner;

    private bool lastData = false;
    public string randomData;

    private void Start()
    {
        dataManager = GetComponent<DataManager_TMP>();
        if (PlayerPrefs.HasKey("HasSimulated"))
        {
            startButton.SetActive(false);
            sliderManager.UnableSliders(false);
            Invoke("RepeatingSimulation", 2f);
        }
        if (PlayerPrefs.HasKey("SimulationEnded"))
        {
            lastData = true;
        }
    }

    private void RepeatingSimulation()
    {
        randomData = PlayerPrefs.GetString("RandomData");
        SetValues();
        Simulation();
    }

    private void SetValues()
    {
        for (int i = 0; i < dataManager.dataHolderList.Count; i++) 
        {
            dataManager.dataHolderList[i].data = PlayerPrefs.GetFloat(dataManager.dataHolderList[i].dataType);
            dataManager.SetData(PlayerPrefs.GetFloat(dataManager.dataHolderList[i].dataType), dataManager.dataHolderList[i].dataType);
        }
    }

    public void CreateHasSimulatedPref()
    {
        PlayerPrefs.SetInt("HasSimulated", 1);
    }
    public void StartSimulationLogic()
    {
        planeMov.StartPlane();
        sliderManager.SaveAtemptData();
        sliderManager.UnableSliders(false);
    }

    public void StartSimulation()
    {
        if (randomData != "none")
        {
            if (!PlayerPrefs.HasKey("HasSimulated"))
            {
                startButton.SetActive(false);
                dataManager.SimulationStarted();

                for (int i = 0; i < dataManager.dataHolderList.Count; i++) 
                {
                    if(randomData == dataManager.dataHolderList[i].dataType) 
                    {
                        dataManager.dataHolderList[i].dataSlider.value = dataManager.dataHolderList[i].dataSlider.minValue;
                        dataManager.SetData(dataManager.dataHolderList[i].dataSlider.value, dataManager.dataHolderList[i].dataType);
                    }
                }
                Simulation();
            }
        }
    }


    private void Simulation()
    {
        if (!PlayerPrefs.HasKey("HasSimulated"))
        {
            CreateHasSimulatedPref();
            StartSimulationLogic();
            return;
        }

        for (int i = 0; i < dataManager.dataHolderList.Count; i++)
        {
            if(randomData == dataManager.dataHolderList[i].dataType)
            {
                dataManager.dataHolderList[i].dataSlider.value += 1;
                dataManager.SetData(dataManager.dataHolderList[i].dataSlider.value, dataManager.dataHolderList[i].dataType);
                if (!lastData) { StartSimulationLogic(); }
                if (dataManager.dataHolderList[i].dataSlider.value == dataManager.dataHolderList[i].dataSlider.maxValue)
                {
                    if (lastData)
                    {
                        SimulationEnded();
                        return;
                    }
                    PlayerPrefs.SetInt("SimulationEnded", 1);
                }
            }
        }
        
    }

    private void SimulationEnded()
    {
        sliderManager.SetText();
        canvasManager.ChangeResultCanvas(canvasConteiner);
    }




}
