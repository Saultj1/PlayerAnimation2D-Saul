using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    //Velocidad de los per
    float movementSpeed = 3;
    //Repredentar la ubicación
    Vector2 movement = new Vector2();

    Rigidbody2D rb2d;

    Animator animator;
    string animationState = "AnimationState";

    enum CharStates
    {
            walkWest=3,
            walkEast =1,
            walkSouth=2,
            walkNorth=4,
            idleSouth=5
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateState();
    }
    private void UpdateState()
    {
        if (movement.x > 0)
        { //ESTE
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0)
        { //OESTE
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0)
        { //NORTE
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0)
        { //SUR
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);//IDLE
        }
        
        
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rb2d.velocity = movement * movementSpeed;
    }
}
