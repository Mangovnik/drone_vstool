using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraShortcutsController : MonoBehaviour
{
    public Transform rig;
    public GameObject shortcutPrefab;

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
}
