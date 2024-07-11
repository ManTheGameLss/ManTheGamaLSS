using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public InputManager inputManager;
    public Animator animator;
    public PlayerManager playerManager;
    public PlayerLocomotion playerLocomotion;

    int horizontal;
    int vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerManager = GetComponent<PlayerManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
        inputManager = GetComponent<InputManager>();
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting, bool useRootMotion = false)
    {
        animator.SetBool("isInteracting", isInteracting);
        animator.SetBool("isUsingRootMotion", useRootMotion);
        animator.CrossFade(targetAnimation, 0.2f);
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting, bool isWalking)
    {
        float snappedHorizontal;
        float snappedVertical;

        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snappedHorizontal = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            snappedHorizontal = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion

        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            snappedVertical = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            snappedVertical = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }
        #endregion

        #region Sprint
        if (isSprinting)
        {
            snappedHorizontal = horizontalMovement;
            snappedVertical = 2;
        }
        #endregion

        // stuff i added ;)
        #region MoveForward
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("MoveForward", true);
        }
        else
        {
            animator.SetBool("MoveForward", false);
        }
        #endregion

        #region MoveBackwards
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("MoveBackwards", true);
        }
        else
        {
            animator.SetBool("MoveBackwards", false);
        }
        #endregion

        #region MoveLeft
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("MoveLeft", true);
        }
        else
        {
            animator.SetBool("MoveLeft", false);
        }
        #endregion

        #region MoveRight
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("MoveRight", true);
        }
        else
        {
            animator.SetBool("MoveRight", false);
        }
        #endregion

        if (isWalking)
        {
            snappedHorizontal = horizontalMovement;
            snappedVertical = 0.5f;
        }

        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }

    private void OnAnimatorMove()
    {
        if (playerManager.isUsingRootMotion)
        {
            Vector3 direction;

            direction = playerLocomotion.cameraObject.forward * inputManager.verticalInput;
            direction = direction + playerLocomotion.cameraObject.right * inputManager.horizontalInput;
            direction.Normalize();
            direction.y = 0;

            playerLocomotion.playerRigidBody.drag = 0;
            //Vector3 deltaPosition = animator.deltaPosition;
            //deltaPosition.y = 0;
            //Vector3 velocity = deltaPosition / Time.deltaTime;
            //playerLocomotion.playerRigidBody.velocity = velocity;
            playerLocomotion.playerRigidBody.AddForce(-direction * 20); //comando funziona fa ti fa solo andare in una direzione
            // solo quelle commentate sono originali
        }
    }
}
