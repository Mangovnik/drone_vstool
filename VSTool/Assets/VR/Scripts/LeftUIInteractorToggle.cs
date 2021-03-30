using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftUIInteractorToggle : MonoBehaviour
{
    public GameObject leftUIInteractor;

    public InputAction showInteractor;
    public InputAction hideInteractor;

    private void OnEnable()
    {
        showInteractor.Enable();
        hideInteractor.Enable();
    }

    private void OnDisable()
    {
        showInteractor.Disable();
        hideInteractor.Disable();
    }

    private void Awake()
    {
        showInteractor.performed += showInteractorAction;
        hideInteractor.performed += hideInteractorAction;
        showInteractor.canceled += hideInteractorAction;
    }

    private void hideInteractorAction(InputAction.CallbackContext obj)
    {
        leftUIInteractor.SetActive(false);
    }

    private void showInteractorAction(InputAction.CallbackContext obj)
    {
        leftUIInteractor.SetActive(true);
    }
}
