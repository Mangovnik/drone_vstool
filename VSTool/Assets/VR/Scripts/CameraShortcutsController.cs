using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraShortcutsController : MonoBehaviour
{
    public Transform rig;
    public GameObject shortcutPrefab;

    private int position = -1;
    public InputAction forward;
    public InputAction backward;

    public void hideShortcuts()
    {
        int c = transform.childCount;

        for (int i = 0; i < c; i++)
        {
            transform.GetChild(i).GetComponent<CameraShortcutController>().hideUI();
        }
    }

    public void showShortcuts()
    {
        int c = transform.childCount;

        for (int i = 0; i < c; i++)
        {
            transform.GetChild(i).GetComponent<CameraShortcutController>().showUI();
        }
    }

    public void createShortcut()
    {
        Instantiate(shortcutPrefab, rig.position, transform.rotation, transform);
    }

    private void OnEnable()
    {
        forward.Enable();
        backward.Enable();
    }

    private void OnDisable()
    {
        forward.Disable();
        backward.Disable();
    }

    private void Awake()
    {
        forward.performed += forwardAction;
        backward.performed += backwardAction;
    }

    private void backwardAction(InputAction.CallbackContext obj)
    {
        int count = transform.childCount;
        if(count == 0)
        {
            return;
        }
        
        if(position >= count || position <= 0)
        {
            position = count - 1;
        }
        else
        {
            position -= 1;
        }

        Debug.Log(position);

        transform.GetChild(position).GetComponent<CameraShortcutController>().teleportRigToShortcut();
    }

    private void forwardAction(InputAction.CallbackContext obj)
    {
        int count = transform.childCount;
        if (count == 0)
        {
            return;
        }

        if (position >= count - 1 )
        {
            position = 0;
        }
        else
        {
            position += 1;
        }

        Debug.Log(position);

        transform.GetChild(position).GetComponent<CameraShortcutController>().teleportRigToShortcut();
    }
}
