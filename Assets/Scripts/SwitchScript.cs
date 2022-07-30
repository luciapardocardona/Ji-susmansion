using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject on, off;
    
    void Start()
    {
        on.SetActive(false);
        off.SetActive(true);
    }

    public void Activar(){
        on.SetActive(true);
        off.SetActive(false);
    }
}
