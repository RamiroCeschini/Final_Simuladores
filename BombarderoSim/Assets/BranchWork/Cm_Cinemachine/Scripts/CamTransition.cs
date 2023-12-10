using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransition : MonoBehaviour
{
    public GameObject[] cameraList;
    int Cameras = 3;

    private void Start()
    {
        for(int i = 0; i < Cameras; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }
        cameraList[0].gameObject.SetActive(true);
    }

    void TurnOffCameras()
    {
        for (int i = 0; i < Cameras; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Key 1 pressed");
            TurnOffCameras();
            cameraList[0].gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Key 2 pressed");
            TurnOffCameras();
            cameraList[1].gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Key 3 pressed");
            TurnOffCameras();
            cameraList[2].gameObject.SetActive(true);
        }
    }
}
