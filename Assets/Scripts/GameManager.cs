using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Animator myAnimator;
    AudioSource sound;

    private string nextScene;
    public AudioClip soundWoodDoor, soundMetalDoor;

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
                sound.PlayOneShot(soundMetalDoor);
                break;
            case SceneConstants.Nivel2:
                if (playerScript.isPlayerOnExit) //isCorrectDoor
                {
                    myAnimator = GameObject.Find("Purple Door").GetComponentInChildren<Animator>();
                    myAnimator.SetBool(AnimationConstants.action, true);
                    this.nextScene = SceneConstants.Nivel3;
                    Invoke(nameof(GoToNextScene), 2f);
                    sound.PlayOneShot(soundWoodDoor);
                }
                else
                {
                    myAnimator = GameObject.Find("Green Door").GetComponentInChildren<Animator>();
                    myAnimator.SetBool(AnimationConstants.action, true);
                    //Invoke(nameof(GoToNextScene), 2f);
                    ReloadLevel();
                    sound.PlayOneShot(soundWoodDoor);
                }
                break;
            case SceneConstants.Nivel3:
                if(playerScript.isPlayerOnExit)
                {
                    myAnimator = GameObject.Find("Green Door").GetComponentInChildren<Animator>();
                    myAnimator.SetBool(AnimationConstants.action, true);
                    this.nextScene = SceneConstants.FinalBueno;
                    Invoke(nameof(GoToNextScene), 2f);
                    sound.PlayOneShot(soundWoodDoor);
                }
                else
                {
                    myAnimator = GameObject.Find("Purple Door").GetComponentInChildren<Animator>();
                    myAnimator.SetBool(AnimationConstants.action, true);
                    this.nextScene = SceneConstants.FinalMalo;
                    Invoke(nameof(GoToNextScene), 2f);
                    //Invoke(nameof(GoToNextScene), 2f);
                    //ReloadLevel();
                    sound.PlayOneShot(soundWoodDoor);
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
