using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator ani;
    float horizontalMove = 0f;
    bool jump = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;                 //moves left and right
        if (Input.GetButtonDown("Jump"))                                            //jumping
        {
            jump = true;
            ani.SetBool("Jump", true);
        }
        ani.SetFloat("Speed", Mathf.Abs(horizontalMove));                           //running animation
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, jump);          //the actual jump
        jump = false;
    }
    public void OnLanding()
    {
        ani.SetBool("Jump", false);                                                 //jumping animation
    }
}
