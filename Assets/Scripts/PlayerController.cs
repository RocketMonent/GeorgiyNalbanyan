using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    private AudioSource audioSource;
    private float jumpForce = 700f;
    private float gravityModifier = 1.8f;
    private bool isOnGround = true;
    public bool isGameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()       
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && isGameOver == false)  
        {
            rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            audioSource.PlayOneShot(jumpSound, 1.5f);
            animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            isGameOver = true;
            animator.SetBool("Death_b",true);
            animator.SetInteger("DeathType_int",1);
            audioSource.PlayOneShot(crashSound, 1f);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
