using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public ParticleSystem dust; //Particles

    public Animator animator; //Animator
    
    [SerializeField] private InputController input = null; //generic input
    
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed -ground.GetFriction(), 0f);

        //fliping
        Vector3 characterScale = transform.localScale;
        if (direction.x < 0f)
        {
            characterScale.x = -1;
            CreateDust();
            
        }
        if (direction.x > 0f)
        {
            characterScale.x = 1;
            CreateDust();
        }
            transform.localScale = characterScale;
        
    }
    
    void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = rb.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        rb.velocity = velocity;

        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    //method/function for dust particle system

    void CreateDust() 
    {
        dust.Play();
    }
}
