using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class snapping UI to controller.
 */
public class SnapUIToRightController : MonoBehaviour
{
    public GameObject rightController;

    // Update is called once per frame
    void Update()
    {
        transform.position = rightController.transform.position;
        transform.rotation = rightController.transform.rotation;
    }
}
