using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 15f;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    BoxCollider2D myBoxCollider;
    GameManager gameManager;

    public bool luz = false;
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        gameManager = GetComponent<GameManager>();

        luz = false;
    }

    void Update(){
        if (luz = true)
        {
            myAnimator.SetBool("isB&W", false);
        }else{
            myAnimator.SetBool("isB&W", true);
        }
    }

    public void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        myAnimator.SetBool(AnimationConstants.Walk, playerHasHorizontalSpeed);
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
        //gameManager.LevelManagement();
    }
}
