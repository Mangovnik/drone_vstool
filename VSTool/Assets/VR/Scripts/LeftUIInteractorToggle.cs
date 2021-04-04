using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftUIInteractorToggle : MonoBehaviour
{
    public GameObject leftUIInteractor1;
    public GameObject leftUIInteractor2;

    public InputAction showInteractor1;
    public InputAction showInteractor2;

    private void OnEnable()
    {
        showInteractor1.Enable();
        showInteractor2.Enable();
    }

    private void OnDisable()
    {
        showInteractor1.Disable();
        showInteractor2.Disable();
    }

    private void Awake()
    {
        showInteractor1.performed += showInteractorAction1;
        showInteractor1.canceled += hideInteractorAction1;

        showInteractor2.performed += showInteractorAction2;
        showInteractor2.canceled += hideInteractorAction2;
    }

    private void showInteractorAction2(InputAction.CallbackContext obj)
    {
        leftUIInteractor2.SetActive(true);
    }

    private void hideInteractorAction2(InputAction.CallbackContext obj)
    {
        leftUIInteractor2.SetActive(false);
    }

    private void hideInteractorAction1(InputAction.CallbackContext obj)
    {
        leftUIInteractor1.SetActive(false);
    }

    private void showInteractorAction1(InputAction.CallbackContext obj)
    {
        leftUIInteractor1.SetActive(true);
    }
}
