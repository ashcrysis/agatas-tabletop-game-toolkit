using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private bool isMoving = false;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    private float lastHInput = 0f;
    private float lastVInput = 0f;
    private void Start()
    {
        moveSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>().baseMovementSpeed;
        playerTransform = transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (moveDirection != Vector2.zero)
        {
            rb.linearVelocity = moveDirection * moveSpeed;
            lastHInput = horizontalInput;
            lastVInput = verticalInput;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        isMoving = moveDirection != Vector2.zero;
        animator.SetBool("isMoving", isMoving);

        animator.SetInteger("x", isMoving ? (int)horizontalInput : (int)lastHInput);
        animator.SetInteger("y", isMoving ? (int)verticalInput : (int)lastVInput);

        if (horizontalInput != 0) 
        {
            spriteRenderer.flipX = horizontalInput < 0;
        }
    }

    
}
