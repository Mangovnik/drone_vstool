using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShortcutItem : MonoBehaviour
{
    public CameraShortcutController shortcut;
    private Text text;

    private void Awake()
    {
        text = transform.Find("Distance").GetComponent<Text>();
    }
    private void Update()
    {
        text.text = shortcut.distance.ToString("0.0") + " m";
    }

    private void OnDisable()
    {
        delete();
    }

    public void delete()
    {
        Destroy(transform.gameObject);
    }
}
