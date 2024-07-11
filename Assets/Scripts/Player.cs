using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] private LayerMask platformsLayer;

    private BoxCollider2D jumpBoxColider;
    private PlayerAtackTypesListSO atackTypesList;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float lookDirection = 1;
    private bool isGrounded;

    private void Awake()
    {
        Instance = this;

        rigidbody2D = GetComponent<Rigidbody2D>();
        atackTypesList = GameAssets.Instance.playerAtackTypesList;
        jumpBoxColider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        HandleMovement();

        HandleAtacks();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rigidbody2D.velocity = new Vector2(horizontalInput * moveSpeed, rigidbody2D.velocity.y);

        if (horizontalInput != 0) // Rotates player in the direction of movement
        {
            lookDirection = horizontalInput;
            transform.localScale = new Vector2(lookDirection, 1);
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rigidbody2D.velocity.x));
        animator.SetFloat("yVelocity", rigidbody2D.velocity.y);

        HandleJumping();
    }
    private void HandleAtacks()
    {
        // Punch if player is grounded
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            PlayerAtackTypesSO randomAtack = GetRandomAtack();
            PlayerAtack.Create(transform.position, GetLookDirection(), randomAtack);
            animator.SetTrigger(randomAtack.typeOfPunch.ToString());
        }
    }

    private void HandleJumping()
    {
        isGrounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", false);
        }
        animator.SetBool("isJumping", !isGrounded);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(jumpBoxColider.bounds.center, jumpBoxColider.bounds.size, 0f, Vector2.down, .1f, platformsLayer);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
    public float GetLookDirection()
    {
        return transform.localScale.x;
    }
    private PlayerAtackTypesSO GetRandomAtack()
    {
        PlayerAtackTypesSO randomAtack = atackTypesList.list[UnityEngine.Random.Range(0, atackTypesList.list.Count)];
        return randomAtack;
    }


}
