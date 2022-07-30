using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public GameObject press;

    private void Start(){
        press.SetActive(false);
        Invoke("Continua", 15f);
    }

    private void Continua(){
        press.SetActive(true);
        if (Input.anyKey){
            SceneManager.LoadScene("Menu");
        }
    }
}
