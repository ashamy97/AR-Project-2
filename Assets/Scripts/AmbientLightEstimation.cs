using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class AmbientLightEstimation : MonoBehaviour
{

    public ARCameraManager cameraManager;
    public Text warning;
    private Light lightComponent;

    private void OnEnable()
    {
        lightComponent = GetComponent<Light>();
        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    void OnCameraFrameReceived(ARCameraFrameEventArgs camFrameEvent)
    {
        ARLightEstimationData led=camFrameEvent.lightEstimation;

        if (led.averageBrightness.HasValue)
        {
            lightComponent.intensity = led.averageBrightness.Value;

            if (led.averageBrightness.Value < 0.1f)
            {
                //enable warning text
                warning.gameObject.SetActive(true);
            }
            else
            {
                //disable warning text
                warning.gameObject.SetActive(false);
            }
            
        }
        if (led.averageColorTemperature.HasValue)
        {
            lightComponent.colorTemperature = led.averageColorTemperature.Value;
        }
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }
}
