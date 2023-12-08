using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager_TMP : MonoBehaviour
{
    public float dato1;
    public float dato2;
    public float dato3;
    
    [SerializeField] private TextMeshProUGUI dato1Text;
    [SerializeField] private TextMeshProUGUI dato2Text;
    [SerializeField] private TextMeshProUGUI dato3Text;

    [SerializeField] private Slider dato1Slider;
    [SerializeField] private Slider dato2Slider;
    [SerializeField] private Slider dato3Slider;

    private AutomatizationManager automatizationManager;

    private void Start()
    {
        automatizationManager = GetComponent<AutomatizationManager>();
        SetDato1(0);
        SetDato2(0);
        SetDato3(0);
    }

    public void SetDato1(float dataValue)
    {
        dato1Text.text = "Dato 1: " + dataValue.ToString();
        dato1 = dataValue;
    }
    public void SetDato2(float dataValue)
    {
        dato2Text.text = "Dato 2: " + dataValue.ToString();
        dato2 = dataValue;
    }
    public void SetDato3(float dataValue)
    {
        dato3Text.text = "Dato 3: " + dataValue.ToString();
        dato3 = dataValue;
    }

    public void PickDato1()
    {
        dato1Slider.gameObject.SetActive(false);
        automatizationManager.randomData = "Dato1";

        dato2Slider.gameObject.SetActive(true);
        dato3Slider.gameObject.SetActive(true);
    }
    public void PickDato2()
    {
        dato2Slider.gameObject.SetActive(false);
        automatizationManager.randomData = "Dato2";

        dato1Slider.gameObject.SetActive(true);
        dato3Slider.gameObject.SetActive(true);
    }
    public void PickDato3()
    {
        dato3Slider.gameObject.SetActive(false);
        automatizationManager.randomData = "Dato3";

        dato1Slider.gameObject.SetActive(true);
        dato2Slider.gameObject.SetActive(true);
    }

    public void SimulationStarted()
    {
        dato1Slider.gameObject.SetActive(true);
        dato2Slider.gameObject.SetActive(true);
        dato3Slider.gameObject.SetActive(true);

        dato1Slider.interactable = false;
        dato2Slider.interactable = false;
        dato3Slider.interactable = false;
    }
}
