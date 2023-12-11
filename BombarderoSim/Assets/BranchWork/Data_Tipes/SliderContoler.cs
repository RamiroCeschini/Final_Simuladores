using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderContoler : MonoBehaviour
{
    [SerializeField] private List<AutoDataHolder> autoDataHolders;
    [SerializeField] private Buttons buttons;
    [SerializeField] private TextMeshProUGUI textResults;
    [SerializeField] private RectTransform textRect;
    [SerializeField] private Scrollbar scrollbar;
    public bool hasDamageData = false;
    public bool hasTimeData = false;
    private string atemptData;
    private string resultData;
    public float totalDamage;
    public float flightTime;

    [SerializeField] private bool isAutomatic;

    private bool dataCollected = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            CleanData();
        }
    }
    public void UnableSliders(bool active)
    {
        foreach (AutoDataHolder holder in autoDataHolders)
        {
            holder.dataSlider.interactable = active;
        }
    }

    public void SaveAtemptData()
    {
        string dataAdded = "Simulation N° " + CantidadIntentos() + "\r\n";

        for (int i = 0; i < autoDataHolders.Count; i++)
        {
            dataAdded += autoDataHolders[i].dataType + ": " + autoDataHolders[i].data + "   ";
            PlayerPrefs.SetFloat(autoDataHolders[i].dataType, autoDataHolders[i].data);
        }
        atemptData += dataAdded;
        if (dataCollected) { SetTextPrefs(); if (isAutomatic) { buttons.RestartAutoSimulation(); }; }
        dataCollected = true;
    }

    public void SaveResultData()
    {
        if (hasDamageData && hasTimeData)
        {
            string resultAdded = "";
            resultAdded += "\r\n" + "Result:" + "\r\n" + "Total Damage: " + totalDamage + "\r\n" + "Flight Time: " + flightTime + "\r\n" + "\r\n";
            resultData += resultAdded;
            if (dataCollected) { SetTextPrefs(); if (isAutomatic) { buttons.RestartAutoSimulation(); }; }
            dataCollected = true;

            
        }
    }
    private void SetTextPrefs()
    {
        PlayerPrefs.SetInt("CantidadIntentos", CantidadIntentos() + 1);
        PlayerPrefs.SetString("Intento" + PlayerPrefs.GetInt("CantidadIntentos"), atemptData + resultData);
    }
    public void SetText()
    {
        string resultsTextTmp = "";
        for (int i = 1; i < PlayerPrefs.GetInt("CantidadIntentos") +1; i++)
        {
            resultsTextTmp += PlayerPrefs.GetString("Intento" + i);
            textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textRect.sizeDelta.y + 250);
        }
        textResults.text = resultsTextTmp;
        scrollbar.value = 1;
    }
    private int CantidadIntentos()
    {
        if (PlayerPrefs.HasKey("CantidadIntentos"))
        {
            return PlayerPrefs.GetInt("CantidadIntentos");
        }

        else
        {
            return 1;
        }
    }

    private void CleanData()
    {
        PlayerPrefs.DeleteAll();
    }
}
