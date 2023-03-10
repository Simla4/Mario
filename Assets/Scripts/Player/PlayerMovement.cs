using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb2D;
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed = 3;
    
    private float horizontalSpeed;
    public bool isJumping = false;
    
    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnPlayerJump += JumpPlayer;
        EventManager.OnPlayerInGround += ChangeJumpState;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerJump -= JumpPlayer;
        EventManager.OnPlayerInGround -= ChangeJumpState;
    }

    private void Update()
    {
        GetInput();
        MovePlayer();   
    }

    #endregion

    #region OtherMethods

    private void GetInput()
    {
        horizontalSpeed = Input.GetAxis("Horizontal") * speed;

    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.right * (horizontalSpeed * Time.deltaTime));
    }

    private void JumpPlayer()
    {
        if (!isJumping)
        {
            isJumping = true;
            
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }

    private void ChangeJumpState()
    {
        isJumping = false;
    }

    #endregion
}
