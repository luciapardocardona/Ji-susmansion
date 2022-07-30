using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        playerScript = GetComponent<PlayerScript>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        switchScript = GameObject.Find("Scenario").GetComponent<SwitchScript>();
        TogglePlayerColor();
    }


    void Update()
    {
        //TogglePlayerColor();
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
            this.gameManager.HandleSceneTransition();
        }
        else if (playerScript.isPlayerOnSwitch)
        {
            //gameManager.ToggleSwitch();
        }
    }

    private void TogglePlayerColor()
    {
        myAnimator.SetBool("isB&W", !switchScript.isLightOn);
    }
}
