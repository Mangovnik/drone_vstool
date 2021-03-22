using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomTeleportMovement : MonoBehaviour
{
    public float maximalTeleportDistance = 10.0f;
    public Slider maximalTeleportSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        Debug.Log("Teleport disabled.");
    }

    private void OnEnable()
    {
        Debug.Log("Teleport enabled.");
    }

    public void setMaximalTeleportDistanceFromUI()
    {
        maximalTeleportDistance = maximalTeleportSlider.value;
        Debug.Log(maximalTeleportDistance);
    }
}
