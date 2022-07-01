using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public ParticleSystem dust; //Particles

    [SerializeField] private InputController input = null; //generic input
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int maxAirJumps = 0;
    [SerializeField, Range(0f, 10f)] private float donwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 10f)] private float upwardMovementMultiplier = 1.7f;

    private Rigidbody2D rb;
    private Ground ground;
    private Vector2 velocity;
    
    private int jumpPhase;
    private float defaultGravityScale;

    private bool desiredJump;
    private bool onGround;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

        defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= input.RetrieveJumpInput(); // |= operator to retrieve and store te input

    }
    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = rb.velocity;

        if(onGround)
        {
            jumpPhase = 0;
        }

        if(desiredJump)
        {
            desiredJump = false;
            JumpAction();
            CreateDust();
        }

        if(rb.velocity.y > 0)
        {
            rb.gravityScale = upwardMovementMultiplier;
        }
        else if(rb.velocity.y < 0){
            rb.gravityScale = donwardMovementMultiplier;
        }
        else if(rb.velocity.y == 0){
            rb.gravityScale = defaultGravityScale;
        }

        rb.velocity = velocity;
    }

    private void JumpAction()
    {
        if(onGround || jumpPhase < maxAirJumps)
        {
            jumpPhase +=1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y *jumpHeight);
            if(velocity.y > 0f) //checking if jumpspeed doesn't goes negative because of the gravity
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;

        }
    }
    
    void CreateDust() 
    {
        dust.Play();
    }
}
