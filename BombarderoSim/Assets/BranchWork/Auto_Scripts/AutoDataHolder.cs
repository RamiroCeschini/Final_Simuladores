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
    public TextMeshProUGUI dataText;
    public Slider dataSlider;

    private void Start()
    {
        dataSlider.onValueChanged.AddListener(delegate { OnSliderChanged(); });
    }

    private void OnSliderChanged()
    {
        data = dataSlider.value;
        dataText.text = dataType + ": " + data;
    }

}
