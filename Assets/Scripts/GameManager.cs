using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Animator myAnimator;
    private void Awake() {
        myAnimator = GameObject.Find("Scenario").GetComponent<Animator>();
    }
    
    public void HandleSceneTransition()
    {
        var currentScene = SceneManager.GetActiveScene();

        switch (currentScene.name)
        {
            case SceneConstants.Nivel1:
                myAnimator.SetBool(AnimationConstants.action, true);
                Invoke(nameof(ANivel2), 2f);
                break;
            case SceneConstants.Nivel2:
                break;
        }
    }

    private void ANivel2()
    {
        SceneManager.LoadScene(SceneConstants.Nivel2);
    }

    private void IrACreditos()
    {
        SceneManager.LoadScene(SceneConstants.Creditos);
    }
}
