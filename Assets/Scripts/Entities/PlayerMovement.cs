using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 10f;

    float horizontalMove = 0f;

    public float jumpTime;
    float jumpTimeCounter;
    bool isJumping = false;
        

    [SerializeField]
    Animator animator;

    void Update()
    {
        horizontalMove = InputManager.Instance.AxisHorizontal * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (InputManager.Instance.PressedJump)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            controller.Jump();
            animator.SetBool("IsJumping", true);
        }

        if (InputManager.Instance.HeldJump && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                Debug.Log("jumpTimeCounte: " + jumpTimeCounter);
                controller.Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (InputManager.Instance.ReleasedJump)
        {
            isJumping = false;
            Debug.Log("jumpTimeCounte: released " + jumpTimeCounter);
        }
        

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false);
        //isJumping = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
