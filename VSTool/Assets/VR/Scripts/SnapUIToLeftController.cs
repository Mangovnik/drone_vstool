using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class snapping UI to controller.
 */
public class SnapUIToLeftController : MonoBehaviour
{
    public GameObject leftController;

    // Update is called once per frame
    void Update()
    {
        transform.position = leftController.transform.position;
        transform.rotation = leftController.transform.rotation;
    }
}
