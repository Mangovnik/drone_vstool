﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapUIToRightController : MonoBehaviour
{
    public GameObject rightController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rightController.transform.position;
        transform.rotation = rightController.transform.rotation;
    }
}
