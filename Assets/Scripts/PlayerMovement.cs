using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 10f;

    float horizontalMove = 0f;
    bool jump = false;

    [SerializeField]
    Animator animator;

    void Update()
    {
        horizontalMove = InputManager.Instance.AxisHorizontal * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (InputManager.Instance.AxisVertical)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
