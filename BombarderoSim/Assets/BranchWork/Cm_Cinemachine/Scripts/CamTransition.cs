using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransition : MonoBehaviour
{
    public GameObject[] cameraList;

    private void Start()
    {
        for(int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }
        cameraList[0].gameObject.SetActive(true);
    }

    void TurnOffCameras()
    {
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }
    }

    public void ChangerCamera(int cameraNumber)
    {
        if (cameraNumber < cameraList.Length)
        {
            TurnOffCameras();
            cameraList[cameraNumber].gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

}
