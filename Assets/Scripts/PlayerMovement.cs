using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D playerRb;
    public bool[] knowledge = new bool[6];
    public Animator animator;

    Vector2 movement;
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            knowledge[0] = false;
        }
        


    }
    // Update is called once per frame

    private void Update()
    {
        //Get arrow keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("xInput", movement.x);
        animator.SetFloat("yInput", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        //Move
        playerRb.MovePosition(playerRb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    
    }
