using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    private Transform frustrum;
    private GameObject cameraPreview;
    private GameObject camera;
    private Color frustrumColor;
    public float distance;
    
    private Vector3 newScale;
    private Color newAlpha;

    private void Awake()
    {
        rig = GameObject.Find("VR Rig");
        label = transform.GetComponentInChildren<Text>();
        icon = transform.GetComponentInChildren<Image>();
        newScale = new Vector3(0, 0, 0);
        newAlpha = new Color(0, 0, 0, 1);
        frustrumColor = new Color(255, 0, 0, 1);
        transform.GetComponentInChildren<Canvas>().worldCamera = rig.transform.GetComponentInChildren<Camera>();
        canvas = transform.Find("Shortcut UI").gameObject;
        frustrum = transform.Find("Camera View/frustrum");
        cameraPreview = GameObject.Find("VR UI/Left Controller UI").GetComponent<CameraPreviewHolder>().cameraPreviewCanvas;
        camera = transform.Find("Camera View/Camera").gameObject;

        Vector3 tmp = rig.GetComponent<XRRig>().cameraGameObject.transform.eulerAngles;

        bool awaken = transform.parent.GetComponent<CameraShortcutsController>().awaken;
        if (awaken) {
            transform.Find("Camera View").Rotate(tmp.x, tmp.y, 0.0f, Space.World);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        updateDistance();
        rotateCanvas();
        scaleCanvas();
    }

    public void pointerEnterDelegate(PointerEventData data) {
        pointerEnterAction();
    }

    public void pointerExitDelegate(PointerEventData data) {
        pointerExitAction();
    }

    public void pointerEnterAction() {
        camera.SetActive(true);
        cameraPreview.SetActive(true);
    }

    public void pointerExitAction() {
        camera.SetActive(false);
        cameraPreview.SetActive(false);
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
            frustrumColor.a = 0.0f;
        }
        else if (distance < startRegularRenderDistance)
        {
            tmp = distance * maxScale;
            newScale.Set(tmp, tmp, tmp);
            newAlpha.a = (distance - endNoRenderDistance) / (startRegularRenderDistance - endNoRenderDistance);
            frustrumColor.a = newAlpha.a;
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
            frustrumColor.a = newAlpha.a;
        }
        else
        {
            tmp = distance * minScale;
            newScale.Set(tmp, tmp, tmp);
            newAlpha.a = 1.0f;
            frustrumColor.a = newAlpha.a;
        }

        canvas.transform.localScale = newScale;
        label.color = newAlpha;
        icon.color = newAlpha;
        frustrum.localScale = newScale * 250;
        for (int i = 0; i < frustrum.childCount; i++) {
            frustrum.GetChild(i).GetComponent<LineRenderer>().startColor = frustrumColor;
            frustrum.GetChild(i).GetComponent<LineRenderer>().endColor = frustrumColor;
            frustrum.GetChild(i).GetComponent<LineRenderer>().startWidth = tmp * 4;
            frustrum.GetChild(i).GetComponent<LineRenderer>().endWidth = tmp * 4;
        }
    }

    public void teleportRigToShortcut()
    {
        Vector3 camera = new Vector3(0.0f, rig.GetComponent<XRRig>().cameraGameObject.transform.eulerAngles.y, 0.0f);
        Vector3 viewPoint = new Vector3(0.0f, 0.0f, 0.0f); 
        viewPoint.y = transform.Find("Camera View").eulerAngles.y;
        Vector3 angle = camera - viewPoint;

        GameObject.Find("Environment").transform.Rotate(angle);
        GameObject.Find("Map").transform.Rotate(angle);

        rig.transform.position = transform.position;
    }

    public void delete()
    {
        Destroy(gameObject);
    }

    public void hideUI()
    {
        canvas.SetActive(false);
        frustrum.gameObject.SetActive(false);
    }

    public void showUI()
    {
        canvas.SetActive(true);
        frustrum.gameObject.SetActive(true);
    }
}
