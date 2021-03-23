using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * Class Controling showing and hiding menu. Attached to "VR UI/Left controller menu"
 */
public class ToggleMenu : MonoBehaviour
{
    // Object with ray to toggle with the menu; "VR Rig/Camera Offset/Right UI Interactor"
    public GameObject rightHandRay;

    // Action for toggling menu.
    public InputAction toggleMenuAction;

    // state of menu. Visible = true ; Hidden = false
    private bool isVisible = false;

    private void Awake()
    {
        // Perfom GripPressed() on action;
        toggleMenuAction.performed += GripPressed;
    }

    private void OnEnable()
    {
        toggleMenuAction.Enable();
    }

    private void OnDisable()
    {
        toggleMenuAction.Disable();
    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        if(isVisible)
        {
            turnOffMenu();
        }
        else
        {
            turnOnMenu();
        }
    }

    private void turnOnMenu()
    {
        transform.Find("Base Menu").gameObject.SetActive(true);
        rightHandRay.SetActive(true);
        isVisible = true;
    }

    private void turnOffMenu()
    {
        int c = transform.childCount;

        rightHandRay.SetActive(false);
        for(int i = 0; i < c; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        isVisible = false;
    }

}
