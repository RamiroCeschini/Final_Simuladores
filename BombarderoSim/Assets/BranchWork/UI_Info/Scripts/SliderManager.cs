using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public GameObject CylinderTest;
    public Text XEyeText;
    public Text YEyeText;
    public Text ZEyeText;
    public Vector3 startPosition;

    private void Start()
    {
        RotationZ(0f);
        PositionY(0f);
        startPosition = transform.position;
    }

    public void PositionY(float y)
    {
        CylinderTest.transform.position = startPosition + new Vector3 (0f, y, 0f);
    }
    
    public void RotationZ(float rotationZ)
    {
        CylinderTest.transform.localEulerAngles = new Vector3(-rotationZ, CylinderTest.transform.localEulerAngles.z);
        ZEyeText.text = rotationZ.ToString() + "°";
        Debug.Log("rot: " + rotationZ + "euler:" + CylinderTest.transform.localEulerAngles.z);
    }
}
