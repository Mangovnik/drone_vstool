using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderIncrement : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void Increment()
    {
        slider.value += 1.0f;
    }

    public void Decrement()
    {
        slider.value -= 1.0f;
    }
}
