using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tmp_RunInfo : MonoBehaviour
{
    public GameObject CylinderTest;
    public Text XEyeText;
    public Text YEyeText;
    public Text ZEyeText;

    private void Start()
    {
        RotationX(0f);
        RotationY(0f);
        RotationZ(0f);
    }

    public void RotationX(float rotationX)
    {
        CylinderTest.transform.localEulerAngles = new Vector3(CylinderTest.transform.localEulerAngles.x, rotationX, CylinderTest.transform.localEulerAngles.z);
        XEyeText.text = rotationX.ToString() + "°";
    }

    public void RotationY(float rotationY)
    {
        CylinderTest.transform.localEulerAngles = new Vector3(-rotationY, CylinderTest.transform.localEulerAngles.y, CylinderTest.transform.localEulerAngles.z);
        YEyeText.text = rotationY.ToString() + "°";
        Debug.Log("rot: " + rotationY + "euler:" + CylinderTest.transform.localEulerAngles.y);
    }

    public void RotationZ(float rotationZ)
    {
        CylinderTest.transform.localEulerAngles = new Vector3(-rotationZ, CylinderTest.transform.localEulerAngles.z);
        ZEyeText.text = rotationZ.ToString() + "°";
        Debug.Log("rot: " + rotationZ + "euler:" + CylinderTest.transform.localEulerAngles.z);
    }
}
