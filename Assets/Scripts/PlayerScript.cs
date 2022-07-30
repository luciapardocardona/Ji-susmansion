using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int jump = 10, vel = 8; 
    Rigidbody2D rb;
    float enX;
    public SpriteRenderer sprite; //Vamos a hacer un flip al player
    bool bloqueo;//, girado;
    public Animator animacion;
    public AudioClip soundsalto;
    AudioSource sonido;
    GameObject padre;
    CapsuleCollider2D capsule;

    void Start()
    {
        sonido = GetComponent<AudioSource>();
        capsule = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        bloqueo = false;
    }
    void Update() {
        if (!bloqueo){
            Jump();
        }

        if (rb.velocity.x > 0){
            sprite.flipX = false;
            //girado = false; // para poder lanzar objetos
            capsule.offset = new Vector2(-0.27f, 0);
        }else if (rb.velocity.x < 0){
            sprite.flipX = true;
            //girado = true; // para poder lanzar objetos
            capsule.offset = new Vector2(0.27f, 0);
        }
        
        AnimarPlayer();
    }


    private void AnimarPlayer(){
        if (bloqueo){
            animacion.Play(AnimationConstants.Idle);
        }else{
            if (Input.GetKey(KeyCode.E)){
                animacion.Play(AnimationConstants.MoradoPrender);
            }else if (((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))) && (Ground())){
                animacion.Play("Walk");
            }else if (!Ground()){
                animacion.Play("Jump");
            }else{ 
                animacion.Play("Idle");
            }
        }
    }

    void FixedUpdate(){
        if (!bloqueo){
            enX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(enX * vel, rb.velocity.y);
        }
    }

    private void Jump(){
        if (((Input.GetKeyDown(KeyCode.W))) && Ground()){
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            sonido.PlayOneShot(soundsalto);
        }
    }

    private bool Ground(){
        RaycastHit2D toca = Physics2D.Raycast(transform.position, Vector2.down, 1.45f);
        if (toca.collider == null){ // Si no toca ninguna
            return false;
        }else{ // Si toca alguna
            return true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        //if (other.gameObject.CompareTag(TagConstants.Interruptor)){
        //    if (Input.GetKeyDown(KeyCode.E)){
        //        other.SendMessage("Activar");
        //    }
        //}
        //if (other.gameObject.CompareTag(TagConstants.Door))
        //{
        //    if(Input.GetKeyDown(KeyCode.E)){
        //        Invoke(nameof(ANivel2), 0.1f);
        //    }
        //}
    }

   
}
