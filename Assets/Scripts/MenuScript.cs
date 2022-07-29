using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject controles;
    private void Start(){
        controles.SetActive(false);
    }
    
    public void Level1(){
        controles.SetActive(true);
        Invoke("Inicia", 2f);
    }

    private void Inicia(){
        SceneManager.LoadScene("Nivel1");
    }

    void Update(){
        Salir();
    }

    private void Salir(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void Quit(){
        Application.Quit();
    }
}
