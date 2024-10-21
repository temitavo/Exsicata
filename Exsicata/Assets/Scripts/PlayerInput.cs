using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private bool canMove;
    public PlayerController playerController;

    public Vector2 playerMovement;

    public float jumpButtonPressedTime;
    public float jumpButtonPressWindow;

    private static PlayerInput instance;

    private bool interactPressed;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one PlayerInput in the scene.");
        }
        instance = this;

        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        canMove = true;
        interactPressed = false;

}

void Update()
    {
        Interact();

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        if (canMove)
        {
            MovementManager();
            JumpManager();
            JumpHeightController();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    private void MovementManager()
    {
        playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void JumpManager()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerController.JumpPlayer();
            jumpButtonPressedTime = 0;
        }
    }

    private void JumpHeightController()
    {
        if (playerController.isJumping)
        {
            jumpButtonPressedTime += Time.deltaTime;

            if (jumpButtonPressedTime < jumpButtonPressWindow && (Input.GetKeyUp(KeyCode.Space)))
            {
                playerController.rb.mass = playerController.fallMass;
            }

            if (playerController.rb.velocity.y < 0)
            {
                playerController.rb.mass = playerController.mass;
                playerController.isJumping = false;

            }
        }
    }

    public void SetCanMove(bool canMoveVar)
    {
        canMove = canMoveVar;
    }

    public static PlayerInput GetInstance()
    {
        return instance;
    }

    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public void Interact()
    {
        // If the player should interact...
        if (Input.GetKeyDown(KeyCode.Space) && playerController.isGrounded) // && !PauseMenuManager.GetInstance().isPaused
        {
            interactPressed = true;
            Debug.Log("Interact.");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            interactPressed = false;
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exited game.");
        Application.Quit();
    }
}
