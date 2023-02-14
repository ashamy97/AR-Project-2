using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController3D : MonoBehaviour
{
    public Material carBodymaterial;
    public GameObject colors3DUI;
    bool UIStatus = false;
    
    public void RedColor()
    {
        //change car bosy material to Red

        carBodymaterial.color = new Color(0.990566f, 0.02491982f, 0.02491982f, 1);
    }

    public void WhiteColor()
    {
        //change car bosy material to White
        carBodymaterial.color = new Color(1f, 1f, 1f, 1);
    }

    public void BlueColor()
    {
        //change car bosy material to Blue
        carBodymaterial.color = new Color(0.05873967f ,0.06568105f ,0.9339623f ,1);
    }

    public void Toggle3DUI()
    {
        if (UIStatus == true)
        {
            colors3DUI.SetActive(false);
            UIStatus = false;
        }
        else
        {
            colors3DUI.SetActive(true);
            UIStatus = true;
        }
    }
}
