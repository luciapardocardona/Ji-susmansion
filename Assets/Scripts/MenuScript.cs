using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject controles, play;
    private void Start(){
        controles.SetActive(false);
        play.SetActive(true);
    }
    
    public void Level1(){
        controles.SetActive(true);
        play.SetActive(false);
        Invoke("Inicia", 2f);
        
    }

    private void Inicia(){
        SceneManager.LoadScene(SceneConstants.Nivel1);
    }

    public void Quit(){
        Application.Quit();
    }
}
