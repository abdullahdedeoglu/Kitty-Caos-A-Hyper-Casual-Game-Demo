using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTouchToMove : MonoBehaviour
{
    Touch touch;

    [Header("Moving Elements")]
    Vector2 initPos;
    Vector2 direction;
    Vector3 moveDirection;
    bool canMove = false;

    [Header("Components")]
    [SerializeField] private CharacterController controller;
    
    [Header("Physical Values")]    
    [SerializeField] public float speed = 5.0f;
    [SerializeField] private float gravity = 10.0f;
    [SerializeField] private float jumpForce = 3.0f;
    [SerializeField] private float stopForce = 2.0f;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject DowningEffect;

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(!gameManager.gameEnded && gameManager.gameStarted)
        {
            TouchMovement();
        }
    }

    private void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            canMove = true;
    
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                initPos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                direction = touch.deltaPosition;
            }
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(
                        touch.position.x - initPos.x,
                        0,
                        touch.position.y - initPos.y
                 );
                //calculate rotation
                SetRotation();
                moveDirection = moveDirection * speed;
            }
        }
        else
        {
            canMove = false;
            moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, Time.deltaTime * stopForce);
        }
        JumpManagement();
        CalculateGravity();
        animator.SetBool("canMove", canMove);
        controller.Move(moveDirection.normalized * Time.deltaTime);
    }


    public void SetRotation()
    {
        Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
        transform.rotation = targetRotation;
    }

    public void CalculateGravity()
    {
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
    }

    private void JumpManagement()
    {
        if (Input.GetMouseButtonUp(0) && controller.isGrounded)
        {
            Instantiate(DowningEffect, transform.position, Quaternion.identity);
            moveDirection.y += jumpForce;
        }
    }

    public void setSpeed()
    {
        speed = PlayerPrefs.GetFloat("speed", speed);
    }
}
