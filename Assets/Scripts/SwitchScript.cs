using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    
    AudioSource sound;
    public GameObject[] onLightOn, onLightOff;
    public bool isLightOn = false;
    public AudioClip soundAction;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        ToggleLight();
    }

    public void ToggleLight()
    {
        foreach (var item in onLightOn)
        {
            item.SetActive(isLightOn);
            sound.PlayOneShot(soundAction);
        }
        foreach (var item in onLightOff)
        {
            item.SetActive(!isLightOn);
            sound.PlayOneShot(soundAction);
        }
    }
}
