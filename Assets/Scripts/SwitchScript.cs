using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject[] onLightOn, onLightOff;
    public bool isLightOn = false;

    void Start()
    {
        ToggleLight();
    }

    public void ToggleLight()
    {
        foreach (var item in onLightOn)
        {
            item.SetActive(isLightOn);
        }
        foreach (var item in onLightOff)
        {
            item.SetActive(!isLightOn);
        }
    }
}
