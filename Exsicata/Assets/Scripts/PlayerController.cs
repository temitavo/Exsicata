using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    public Rigidbody rb;
    private SpriteRenderer playerSprite;

    private Vector2 playerMovementNorm;

    [SerializeField] private float playerSpeed;

    [SerializeField] private float jumpHeight;
    public bool isJumping;
    public float mass;
    public float fallMass;
    public bool isGrounded;



    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        isJumping = false;
        mass = rb.mass;
        isGrounded = true;

    }

    void Update()
    {
        FlipManager();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (playerInput.playerMovement == Vector2.zero)
        {
            StopPlayer();
        }
    }

    private void MovePlayer()
    {
        playerMovementNorm = playerInput.playerMovement.normalized * playerSpeed * Time.deltaTime;
        rb.velocity = new Vector3(playerMovementNorm.x, rb.velocity.y, playerMovementNorm.y);
    }

    public void StopPlayer()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    public void FlipManager()
    {
        if(playerInput.playerMovement.x != 0)
        {
            if(playerInput.playerMovement.x > 0)
            {
                playerSprite.flipX = true;
            }
            else if(playerInput .playerMovement.x < 0)
            {
                playerSprite.flipX = false;
            }
        }
    }

    public void JumpPlayer()
    {
        if (isGrounded)
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * Physics.gravity.y * -2) * rb.mass;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isJumping = true;

        }
    }
}
