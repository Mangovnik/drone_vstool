using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShortcutsController : MonoBehaviour
{
    public Transform rig;
    public GameObject shortcutPrefab;

    public void hideShortcuts()
    {
        DroneShortcutController[] drones = FindObjectsOfType<DroneShortcutController>();

        foreach (DroneShortcutController item in drones) {
            item.hideUI();
        }

    }

    public void showShortcuts()
    {
        DroneShortcutController[] drones = FindObjectsOfType<DroneShortcutController>();

        foreach (DroneShortcutController item in drones) {
            item.showUI();
        }
    }
}
