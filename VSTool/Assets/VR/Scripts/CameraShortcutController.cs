using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class CameraShortcutController : MonoBehaviour
{
    public float endNoRenderDistance = 10.0f;
    public float startRegularRenderDistance = 15.0f;
    public float endRegularRenderDistance = 150.0f;
    public float endFarRenderDistance = 250.0f;
    public float maxScale = 0.0004f;
    public float minScale = 0.0002f;
    
    private GameObject rig;
    private Image icon;
    private Text label;
    private GameObject canvas;
    private float distance;
    
    private Vector3 newScale;
    private Color newAlpha;

    private void Awake()
    {
        rig = GameObject.Find("VR Rig");
        label = transform.GetComponentInChildren<Text>();
        icon = transform.GetComponentInChildren<Image>();
        newScale = new Vector3(0, 0, 0);
        newAlpha = new Color(0, 0, 0, 1);
        transform.GetComponentInChildren<Canvas>().worldCamera = rig.transform.GetComponentInChildren<Camera>();
        canvas = transform.Find("Shortcut UI").gameObject;

        Vector3 tmp = rig.GetComponent<XRRig>().cameraGameObject.transform.eulerAngles;
        transform.Find("Camera View").Rotate(0.0f, tmp.y, 0.0f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        updateDistance();
        rotateCanvas();
        scaleCanvas();
    }

    private void rotateCanvas()
    {
        canvas.transform.LookAt(rig.transform);
        canvas.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
    }

    private void updateDistance()
    {
        distance = Vector3.Distance(transform.position, rig.transform.position);
        label.text = distance.ToString("0.0") + " m";
    }

    private void scaleCanvas()
    {
        float tmp;
        if (distance < endNoRenderDistance)
        {
            tmp = distance * maxScale;
            newScale.Set(tmp, tmp, tmp);
            newAlpha.a = 0.0f;
        }
        else if (distance < startRegularRenderDistance)
        {
            tmp = distance * maxScale;
            newScale.Set(tmp, tmp, tmp);
            newAlpha.a = (distance - endNoRenderDistance) / (startRegularRenderDistance - endNoRenderDistance);
        }
        else if (distance < endRegularRenderDistance)
        {
            tmp = distance * maxScale;
            newScale.Set(tmp, tmp, tmp);
            newAlpha.a = 1.0f;
        }
        else if (distance < endFarRenderDistance)
        {
            float pointOnOriginInterval = (distance - endRegularRenderDistance) / (endFarRenderDistance - endRegularRenderDistance);
            float pointOnTargetInterval = (maxScale - minScale) * pointOnOriginInterval;
            tmp = (maxScale - pointOnTargetInterval) * distance;

            newScale.Set(tmp, tmp, tmp);
            newAlpha.a = 1.0f;
        }
        else
        {
            tmp = distance * minScale;
            newScale.Set(tmp, tmp, tmp);
            newAlpha.a = 1.0f;
        }

        canvas.transform.localScale = newScale;
        label.color = newAlpha;
        icon.color = newAlpha;
    }

    public void teleportRigToShortcut()
    {
        Vector3 camera = new Vector3(0.0f, rig.GetComponent<XRRig>().cameraGameObject.transform.eulerAngles.y, 0.0f);
        Vector3 viewPoint = transform.Find("Camera View").eulerAngles;
        Vector3 angle = camera - viewPoint;

        GameObject.Find("Environment").transform.Rotate(angle);

        rig.transform.position = transform.position;
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    public void hideUI()
    {
        canvas.SetActive(false);
    }

    public void showUI()
    {
        canvas.SetActive(true);
    }
}
