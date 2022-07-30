using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField]
    Camera mainCamera;

    GameManager GameManager;

    public bool isPlayerTouchingDoor = false;
    private void Awake()
    { 
        this.GameManager = mainCamera.GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagConstants.Player))
        {
            isPlayerTouchingDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagConstants.Player))
        {
            isPlayerTouchingDoor = false;
        }
    }
}
