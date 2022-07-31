using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Animator myAnimator;

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
                Invoke(nameof(GoToNivel2), 2f);
                break;
            case SceneConstants.Nivel2:
                if (playerScript.isPlayerOnExit) //isCorrectDoor
                {
                    GoToScene(SceneConstants.Nivel3);
                }
                else
                {
                    ReloadLevel();
                }
                break;
            case SceneConstants.Nivel3:
                if(playerScript.isPlayerOnExit)
                {
                    GoToScene(SceneConstants.Creditos);
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

    private void GoToNivel2()
    {
        GoToScene(SceneConstants.Nivel2);
    }

    private void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
