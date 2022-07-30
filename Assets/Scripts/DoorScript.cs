using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    PlayerScript Player;
    private void Awake()
    {
        Player = GetComponent<PlayerScript>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagConstants.Player))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Testing");
                Invoke(nameof(Player.ANivel2), 0.1f);

            }
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Invoke(nameof(Player.ANivel2), 0.1f);
        //}
    }
}
