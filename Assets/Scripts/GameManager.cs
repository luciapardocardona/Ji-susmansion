using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ANivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }

    private void IrACreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
