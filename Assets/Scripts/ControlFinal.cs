using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlFinal : MonoBehaviour
{
    int segundos = 3;
    void Start()
    {
        Invoke("IrCreditos", segundos);
    }

    private void IrCreditos(){
        SceneManager.LoadScene(SceneConstants.Creditos);
    }
}
