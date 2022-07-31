using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    private void Start(){
        Invoke("Continua", 15f);
    }

    private void Continua(){
        SceneManager.LoadScene("Menu");
    }
}
