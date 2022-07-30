using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    public bool isCorrectDoor = false;

    GameManager GameManager;

    private void Awake()
    { 
        this.GameManager = mainCamera.GetComponent<GameManager>();
    }
}
