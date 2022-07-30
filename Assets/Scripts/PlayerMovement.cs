using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] GameManager gameManager;

    PlayerScript playerScript;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    BoxCollider2D myBoxCollider;
    SpriteRenderer sprite;
    SwitchScript switchScript;
    private bool thereIsSwitch;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        playerScript = GetComponent<PlayerScript>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        string scene = SceneManager.GetActiveScene().name;
        thereIsSwitch = scene == SceneConstants.Nivel1 || scene == SceneConstants.Nivel3;
        if (thereIsSwitch)
        {
            switchScript = GameObject.Find("Scenario").GetComponent<SwitchScript>();
        }
        TogglePlayerColor();
    }

    public void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        myAnimator.SetBool(AnimationConstants.Walk, playerHasHorizontalSpeed);


        if (myRigidbody.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            sprite.flipX = true;
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        LayerMask groundLayer = LayerMask.GetMask(LayerConstants.Ground);
        if (value.isPressed && myBoxCollider.IsTouchingLayers(groundLayer))
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            myAnimator.SetTrigger(AnimationConstants.hasJump);
        }
    }
    void OnAction(InputValue value)
    {
        if (playerScript.isPlayerTouchingDoor)
        {
            gameManager.HandleSceneTransition();
        }
        else if (playerScript.isPlayerOnSwitch)
        {
            switchScript.isLightOn = true;
            switchScript.ToggleLight();
            TogglePlayerColor();

        }
    }

    private void TogglePlayerColor()
    {
        if (thereIsSwitch)
        {
            myAnimator.SetBool("isB&W", !switchScript.isLightOn);
        }
        else
        {
            myAnimator.SetBool("isB&W", false);
        }
    }
}
