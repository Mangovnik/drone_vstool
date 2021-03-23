using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/*
 * Class for loading controller models. Used in Hand Presence prefabs.
 */
public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;

    private const int LEFT_CONTROLLER_MODEL = 2;
    private const int RIGHT_CONTROLLER_MODEL = 1;
    private const int DEFAULT_CONTROLLER_MODEL = 0;

    // Start is called before the first frame update
    void Start()
    { 
        if (controllerCharacteristics == InputDeviceCharacteristics.Right)
        {
            Instantiate(controllerPrefabs[RIGHT_CONTROLLER_MODEL], transform);
        }
        else if (controllerCharacteristics == InputDeviceCharacteristics.Left)
        {
            Instantiate(controllerPrefabs[LEFT_CONTROLLER_MODEL], transform);
        }
        else
        {
            Debug.LogError("Did not find corresponding controller model.");
            Instantiate(controllerPrefabs[DEFAULT_CONTROLLER_MODEL], transform);
        }

    }
}
