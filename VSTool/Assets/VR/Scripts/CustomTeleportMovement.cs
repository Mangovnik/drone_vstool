using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class CustomTeleportMovement : MonoBehaviour
{
    public Slider maximalTeleportSlider;
    public GameObject ui;
    public Text text;
    public Transform teleportTarget;
    public InputAction distance;
    public InputAction activate;
    public InputAction teleport;

    private bool activated = false;

    private void Awake() {
        activate.performed += activateAction;
        activate.canceled += activateCanceled;
        teleport.performed += teleportAction;
    }

    private void teleportAction(InputAction.CallbackContext obj) {
        transform.position = teleportTarget.position;
    }

    private void activateCanceled(InputAction.CallbackContext obj) {
        teleportTarget.gameObject.SetActive(false);
        ui.SetActive(false);
        teleportTarget.localPosition = Vector3.zero;
        activated = false;
    }

    private void activateAction(InputAction.CallbackContext obj) {
        teleportTarget.gameObject.SetActive(true);
        ui.SetActive(true);
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated) {
            Vector2 stickValue = distance.ReadValue<Vector2>();
            float tmp = stickValue.magnitude * maximalTeleportSlider.value;
            teleportTarget.localPosition = Vector3.forward * tmp;

            text.text = Vector3.Distance(transform.position, teleportTarget.position).ToString("0.0") + " m";
        }
    }

    private void OnDisable()
    {
        Debug.Log("Teleport disabled.");
        distance.Disable();
        activate.Disable();
        teleport.Disable();
    }

    private void OnEnable()
    {
        Debug.Log("Teleport enabled.");
        distance.Enable();
        activate.Enable();
        teleport.Enable();
    }
}
