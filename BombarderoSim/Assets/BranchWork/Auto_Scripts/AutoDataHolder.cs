using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoDataHolder : MonoBehaviour
{
    public string dataType;
    [HideInInspector] public float data;
    [SerializeField] private float minData;
    [SerializeField] private float maxData;
    public TextMeshProUGUI dataText;
    public Slider dataSlider;


    protected void StartMetod()
    {
        dataSlider.onValueChanged.AddListener(delegate { OnSliderChanged(); });
        dataSlider.minValue = minData;
        dataSlider.maxValue = maxData;
    }

    private void OnSliderChanged()
    {
        data = dataSlider.value;
        dataText.text = dataType + ": " + data;
        DataAction();
    }

    protected virtual void DataAction() {  }
}
