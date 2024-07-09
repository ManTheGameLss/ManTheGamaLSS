using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;

    public Vector2 movementImput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool b_Input;
    public bool c_Input;
    public bool y_Input;
    public bool jump_Input;
    public bool is_moving;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementImput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.B.performed += i => b_Input = true;
            playerControls.PlayerActions.B.canceled += i => b_Input = false;
            playerControls.PlayerActions.C.performed += i => c_Input = true;
            playerControls.PlayerActions.C.canceled += i => c_Input = false;
            playerControls.PlayerActions.Jump.performed += i => jump_Input = true;
            playerControls.PlayerActions.Y.performed += i => y_Input = true;

            playerControls.PlayerMovement.Movement.performed += i => is_moving = true;
            playerControls.PlayerMovement.Movement.canceled += i => is_moving = false;
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
       HandleMovementInput();
       HandleSprintingInput();
       HandleWalkingInput();
       HandleJumpInput();
       //HandleDodgingInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementImput.y;
        horizontalInput = movementImput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting, playerLocomotion.isWalking);
    }

    private void HandleSprintingInput()
    {
        if (b_Input && moveAmount > 0.5f) //quando si usa un bool senza "==", allora "== true" è sottinteso
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleWalkingInput()
    {
        if (c_Input && moveAmount <= 1 && moveAmount > 0)
        {
            playerLocomotion.isWalking = true;
        }
        else
        {
            playerLocomotion.isWalking = false;
        }
    }

    private void HandleJumpInput()
    {
        if (jump_Input)
        {
            jump_Input = false;
            playerLocomotion.HandleJumping();
        }
    }

    private void HandleDodgingInput()
    {
        if (y_Input)
        {
            y_Input = false;
            playerLocomotion.HandleDodging();
        }
    }
}
