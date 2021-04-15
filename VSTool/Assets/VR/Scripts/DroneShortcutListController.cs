using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneShortcutListController : MonoBehaviour
{
    public GameObject itemPrefab;

    private void OnEnable()
    {
        Transform parent = transform.Find("List View/Scroll Area/List");
        GameObject item;
        int i = 0;

        DroneShortcutController[] drones = FindObjectsOfType<DroneShortcutController>();
        foreach (DroneShortcutController drone in drones) {
            item = Instantiate(itemPrefab, parent);
            item.name = "DroneShortcutItem";
            item.transform.Find("Teleport Button").GetComponent<Button>().onClick.AddListener(drone.teleportRigToShortcut);
            item.transform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();
            i++;
            item.transform.Find("Distance").GetComponent<Text>().text = drone.distance.ToString("0.0") + " m";
            item.GetComponent<DroneShortcutItem>().shortcut = drone;
        }
    }
}
