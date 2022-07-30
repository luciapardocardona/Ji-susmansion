using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Animator myAnimator;
    private void Awake()
    {
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
                if (true) //isCorrectDoor
                {
                    GoTo(SceneConstants.Nivel3);
                }
                else
                {
                    //GoTo(SceneConstants.Nivel2);

                }

                break;
        }
    }

    private void GoToNivel2()
    {
        GoTo(SceneConstants.Nivel2);
    }

    private void GoTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
