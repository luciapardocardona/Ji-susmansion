using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int jump = 10, vel = 8;
    Rigidbody2D myRigidbody;
    float enX;
    public SpriteRenderer sprite;
    public Animator animacion;
    public AudioClip soundsalto;
    AudioSource sonido;
    GameObject padre;
    CapsuleCollider2D capsule;

    PlayerMovement movement;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        sonido = GetComponent<AudioSource>();
        capsule = GetComponent<CapsuleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.Run();
    }
}
