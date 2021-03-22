using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapUIToLeftController : MonoBehaviour
{
    public GameObject leftController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = leftController.transform.position;
        transform.rotation = leftController.transform.rotation;
    }
}
