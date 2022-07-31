using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Animator myAnimator;

    private string nextScene;

    PlayerScript playerScript;
    private void Awake()
    {
        GameObject gameObject = GameObject.Find("Ji-Su");

        playerScript = gameObject.GetComponent<PlayerScript>();
    }

    public void HandleSceneTransition()
    {
        var currentScene = SceneManager.GetActiveScene();

        switch (currentScene.name)
        {
            case SceneConstants.Nivel1:
                myAnimator = GameObject.Find("Door").GetComponentInChildren<Animator>();
                myAnimator.SetBool(AnimationConstants.action, true);
                this.nextScene = SceneConstants.Nivel2;
                Invoke(nameof(GoToNextScene), 2f);
                break;
            case SceneConstants.Nivel2:
                if (playerScript.isPlayerOnExit) //isCorrectDoor
                {
                    this.nextScene = SceneConstants.Nivel3;
                    Invoke(nameof(GoToNextScene), 2f);
                }
                else
                {
                    ReloadLevel();
                }
                break;
            case SceneConstants.Nivel3:
                if(playerScript.isPlayerOnExit)
                {
                    this.nextScene = SceneConstants.Creditos;
                    Invoke(nameof(GoToNextScene), 2f);
                }
                else
                {
                    ReloadLevel();
                }
                break;
            case SceneConstants.Creditos:
                break;
        }
    }

    private static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToNextScene()
    {
        SceneManager.LoadScene(this.nextScene);
    }
}
