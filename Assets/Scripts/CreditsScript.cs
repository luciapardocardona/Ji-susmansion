using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    void Update(){
        if (Input.anyKey){
            SceneManager.LoadScene("Menu");
        }
    }
}
