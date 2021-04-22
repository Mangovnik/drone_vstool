using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraShortcutListController : MonoBehaviour
{
    public GameObject itemPrefab;
    private Transform cameraShortcutController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        cameraShortcutController = FindObjectOfType<CameraShortcutsController>().transform;
    }

    private void OnEnable()
    {
        int count = cameraShortcutController.childCount;
        Transform parent = transform.Find("List View/Scroll Area/List");
        GameObject item;
        CameraShortcutController shortcut;

        for (int i = 0; i < count; i++)
        {
            shortcut = cameraShortcutController.GetChild(i).GetComponent<CameraShortcutController>();
            item = Instantiate(itemPrefab, parent);
            item.name = "CameraShortcutItem";
            item.transform.Find("Teleport Button").GetComponent<Button>().onClick.AddListener(shortcut.teleportRigToShortcut);

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { shortcut.pointerEnterA((PointerEventData) data); });
            item.transform.Find("Teleport Button").GetComponent<EventTrigger>().triggers.Add(entry);

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerExit;
            entry.callback.AddListener((data) => { shortcut.pointerExitA((PointerEventData) data); });
            item.transform.Find("Teleport Button").GetComponent<EventTrigger>().triggers.Add(entry);

            item.transform.Find("Delete Button").GetComponent<Button>().onClick.AddListener(shortcut.delete);
            item.transform.Find("Delete Button").GetComponent<Button>().onClick.AddListener(item.GetComponent<CameraShortcutItem>().delete);
            item.transform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();
            item.transform.Find("Distance").GetComponent<Text>().text = shortcut.distance.ToString("0.0") + " m";
            item.GetComponent<CameraShortcutItem>().shortcut = shortcut;
        }
    }
}
