using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScript : MonoBehaviour
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
    
    //private void OnTriggerStay2D(Collider2D other) {
        //if (other.gameObject.tag == "Interruptor"){
            //if (Input.GetKeyDown(KeyCode.O)){
                //other.SendMessage("Activar");
            //}
        //}
    //}
}
