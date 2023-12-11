using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderContoler : MonoBehaviour
{
    [SerializeField] private List<AutoDataHolder> autoDataHolders;
    [SerializeField] private TextMeshProUGUI textResults;
    [SerializeField] private RectTransform textRect;
    private string atemptData;
    public float totalDamage;
    public float fuelLeft = 0;
    public float flightTime = 0;

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
        }

        dataAdded += "\r\n" + "Result:" + "\r\n" + "Total Damage: " + totalDamage + "\r\n" +"Fuel Left: " + fuelLeft +  "\r\n" + "Flight Time: " + flightTime + "\r\n" + "\r\n";
        atemptData += dataAdded;
        textResults.text = atemptData;
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textRect.sizeDelta.y + 150 * PlayerPrefs.GetInt("CantidadIntentos"));
    }
    public void SetTextPrefs()
    {
        PlayerPrefs.SetInt("CantidadIntentos", CantidadIntentos() + 1);
        PlayerPrefs.SetString("Intento" + PlayerPrefs.GetInt("CantidadIntentos"), atemptData);

        for (int i = 0; i < PlayerPrefs.GetInt("CantidadIntentos"); i++)
        {
            textResults.text += PlayerPrefs.GetString("Intento" + i);
        }
    }

    private int CantidadIntentos()
    {
        if (PlayerPrefs.HasKey("CantidadIntentos"))
        {
            return PlayerPrefs.GetInt("CantidadIntentos");
        }

        else
        {
            return 0;
        }
    }
}
