using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System;

public class CustomContinuousMovement : MonoBehaviour
{
    //public float speed = 10.0f;
    public Slider speedSlider;

    public InputAction horizontalMovement;
    public InputAction verticalMovement;
    public InputAction slowVerticalMovement;

    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        makeNewMoveVector();
        moveCamera();
    }

    private void moveCamera()
    {
        if(move != Vector3.zero)
        {
            Quaternion headYaw = Quaternion.Euler(0, GetComponent<XRRig>().cameraGameObject.transform.eulerAngles.y, 0);
            move = headYaw * move;
            transform.Translate(move * speedSlider.value * Time.deltaTime);
        }
    }

    private void makeNewMoveVector()
    {
        Vector2 horizontal = horizontalMovement.ReadValue<Vector2>();
        float vertical = verticalMovement.ReadValue<float>();
        float slowVertical = slowVerticalMovement.ReadValue<float>();

        if(vertical == 0.0f)
        {
            move.Set(horizontal.x, slowVertical/3.0f, horizontal.y);
        }
        else
        {
            move.Set(horizontal.x, vertical, horizontal.y);
        }
    }

    void OnDisable()
    {
        Debug.Log("Continuous disabled.");
        horizontalMovement.Disable();
        verticalMovement.Disable();
        slowVerticalMovement.Disable();
    }

    private void OnEnable()
    {
        Debug.Log("Continuous enabled.");
        horizontalMovement.Enable();
        verticalMovement.Enable();
        slowVerticalMovement.Enable();
    }
}
