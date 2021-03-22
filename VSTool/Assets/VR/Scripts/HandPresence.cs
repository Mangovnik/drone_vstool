using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private const int LEFT_CONTROLLER_MODEL = 2;
    private const int RIGHT_CONTROLLER_MODEL = 1;
    private const int DEFAULT_CONTROLLER_MODEL = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        //if(devices.Count > 0)
        //{

            
            if (controllerCharacteristics == InputDeviceCharacteristics.Right)
            {
                spawnedController = Instantiate(controllerPrefabs[RIGHT_CONTROLLER_MODEL], transform);
            }
            else if (controllerCharacteristics == InputDeviceCharacteristics.Left)
            {
                spawnedController = Instantiate(controllerPrefabs[LEFT_CONTROLLER_MODEL], transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model.");
                spawnedController = Instantiate(controllerPrefabs[DEFAULT_CONTROLLER_MODEL], transform);
            }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if(primaryButtonValue)
        {
            Debug.Log("Pressing Primary Button");
        }

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f)
        {
            Debug.Log("Trigger pressed " + triggerValue);
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if (primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("Primary Touchpad " + primary2DAxisValue);
        }
    }
}
