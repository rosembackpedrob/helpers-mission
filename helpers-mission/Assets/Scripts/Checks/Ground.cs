using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;
    private float friction;
    
    //Using OnCollision Methods to Evaluate collisions and get the ground friction
    private void OnCollisionEnter2D(Collision2D collision) {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }
    
    //OnCollisionExit to reset those values
    private void OnCollisionExit2D(Collision2D other) {
        onGround = false;
        friction = 0;
    }

    //Method to determine if the point colliding with the GameObject is the ground
    private void EvaluateCollision(Collision2D collision)
    {
        //iterate through each contact point and check if normal > 0.9f (one being a flat surface)
        for(int i=0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
        }
    }
    //method to set the friction, retrieve physicsmaterial through the collision
    private void RetrieveFriction(Collision2D collision)
    {
        PhysicsMaterial2D material = collision.collider.sharedMaterial; //the friction materials are on colliders

        friction = 0;

        if (material != null)
        {
            friction = material.friction;
        }
    }

    //To use the onGround and friction variables in other components, two Get Methods to retrieve their values
    public bool GetOnGround()
    {
        return onGround;
    }

    public float GetFriction()
    {
        return friction;
    }
}
