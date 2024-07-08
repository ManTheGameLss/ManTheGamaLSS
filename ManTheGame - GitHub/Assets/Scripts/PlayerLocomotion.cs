using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerManager playerManager;
    AnimatorManager animatorManager;
    InputManager inputManager;

    Vector3 moveDirection;
    public Transform cameraObject;
    public Rigidbody playerRigidBody;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingVelocity;
    public float rayCastHeightOffset = 0.5f;
    public LayerMask groundLayer;

    [Header("Movement Flags")]
    public bool isSprinting;
    public bool isWalking;
    public bool isGrounded;
    public bool isJumping;

    [Header("Movement Speeds")]
    public float walkingSpeed = 0.75f;
    public float runningSpeed = 2f;
    public float sprintingSpeed = 4f;
    //NON SO PK, MA QUESTE QUA SONO DIVENTATE PIù VELOCI/LENTE A CASO:
    //public float walkingSpeed = 0.5f;
    //public float runningSpeed = 1.5f;
    //public float sprintingSpeed = 3;
    public float rotationSpeed = 15;
    [Tooltip("Amount how much player will jitter. if you dont want it, put 0.01 here :D")]
    public float jittering = 0.01f;

    [Header("Jump Speeds")]
    public float jumpHeight = 3;
    public float gravityIntensity = -5; //la gravità deve sempre essere negativa

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<AnimatorManager>();
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();

        //if (playerManager.isInteracting)
          //  return;

        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        //if (isJumping)
        // return;
        if (!isGrounded && !isJumping && inAirTimer > 0.5f)
            return;

        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        if (!isGrounded && isJumping)
        {
            playerRigidBody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
        }
        else if (!isGrounded && !isJumping)
        {
            //playerRigidBody.velocity = moveDirection * 0f;
            playerRigidBody.AddForce(-Vector3.up * fallingVelocity * inAirTimer * 5);
        }
        else if (isGrounded)
        {
            moveDirection.y = jittering;
        }
       


        if (isJumping)
            return;

        if (isSprinting)
        {
            moveDirection = moveDirection * sprintingSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)
            {
                moveDirection = moveDirection * runningSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkingSpeed;
            }
        }

        if (isWalking)
        {
            moveDirection = moveDirection * walkingSpeed;
        }
        else
        {
            if (inputManager.moveAmount > 1)
            {
                moveDirection = moveDirection * sprintingSpeed;
            }
            else if (inputManager.moveAmount > 0.5f && inputManager.moveAmount < 1.1f)
            {
                moveDirection = moveDirection * runningSpeed;
            }
        }

        //if sprinting, select sprintingSpeed
        //if running, select runningSpeed
        //if walking, select walkingSpeed

        Vector3 movementVelocity = moveDirection;
        playerRigidBody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        if (!isGrounded)
            return;

        if (isJumping)
            return;

        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotaion = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotaion, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        Vector3 targetPosition;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;
        targetPosition = transform.position;

        if (!isGrounded && !isJumping) // "!" significa "false" per un bool
        { 
            if (!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Fall", true);
            }

            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidBody.AddForce(transform.forward * leapingVelocity);
            playerRigidBody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if (!isGrounded && !playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Land", true); // "true" significa che non si può uscire dall'animazione finché non è finita
            }

            Vector3 rayCastHitPoint = hit.point;
            targetPosition.y = rayCastHitPoint.y;
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && !isJumping)
        {
            if (playerManager.isInteracting || inputManager.moveAmount > 0)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
            }
            else
            {
                transform.position = targetPosition;
            }
        }
    }

    public void HandleJumping()
    {
        if (isGrounded && !isJumping)
        {
            animatorManager.animator.SetBool("isJumping", true);
            animatorManager.PlayTargetAnimation("Jump", false); //comando per eseguire le animazioni

            Vector3 playerVelocity;

            float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            playerVelocity = moveDirection;
            playerVelocity.Normalize();
            playerVelocity.y = jumpingVelocity;
            playerRigidBody.velocity = playerVelocity;
        }
    }

    public void HandleDodging()
    {
        if (playerManager.isInteracting)
            return;

        animatorManager.PlayTargetAnimation("Dodge", true, true);
    }
}
