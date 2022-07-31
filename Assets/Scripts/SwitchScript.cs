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
        ToggleLight(true);
    }

    public void ToggleLight(bool comesFromStart = false)
    {
        foreach (var item in onLightOn)
        {
            item.SetActive(isLightOn);
            if (!comesFromStart)
            {
                sound.PlayOneShot(soundAction);
            }
        }
        foreach (var item in onLightOff)
        {
            item.SetActive(!isLightOn);
            if (!comesFromStart)
            {
                sound.PlayOneShot(soundAction);
            }
        }
    }
}
