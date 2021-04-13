using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigLockToDrone : MonoBehaviour
{
    public bool locked = false;
    public Transform drone;
    public InputAction unlock;

    // Update is called once per frame
    void Update()
    {
        if (locked) {
            transform.position = drone.position;
        }
    }

    private void OnEnable() {
        unlock.Enable();
    }

    private void OnDisable() {
        unlock.Disable();
    }

    private void Awake() {
        unlock.performed += unlockAction;
    }

    private void unlockAction(InputAction.CallbackContext obj) {
        locked = false;
    }
}
