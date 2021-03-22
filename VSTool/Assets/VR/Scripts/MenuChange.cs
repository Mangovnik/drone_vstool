using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChange : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void ChangeMenuFromBaseToSettings()
    {
        transform.Find("Base Menu").gameObject.SetActive(false);
        transform.Find("Settings Menu").gameObject.SetActive(true);
    }

    public void ChangeMenuFromSettingsToBase()
    {
        transform.Find("Settings Menu").gameObject.SetActive(false);
        transform.Find("Base Menu").gameObject.SetActive(true);
    }
}
