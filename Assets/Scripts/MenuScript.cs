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
        SetFullScreen();
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

    void SetFullScreen(bool isFullScreen = false){
        Screen.fullScreen = isFullScreen;
    }
}
