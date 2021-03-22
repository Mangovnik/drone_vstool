using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class CustomContinuousMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Slider speedSlider;

    public InputActionMap controls;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tmp = controls["MoveHorizontally"].ReadValue<Vector2>();
        Debug.Log(tmp);
        float tmp2 = controls["MoveVertically"].ReadValue<float>();
        Debug.Log(tmp2);
    }

    void OnDisable()
    {
        Debug.Log("Continuous disabled.");
        controls.Disable();
    }

    private void OnEnable()
    {
        Debug.Log("Continuous enabled.");
        controls.Enable();
    }

    public void setSpeedFromUI()
    {
        speed = speedSlider.value;
        Debug.Log(speed);
    }
}
