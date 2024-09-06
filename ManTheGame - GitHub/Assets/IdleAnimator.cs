using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimator : MonoBehaviour
{
    public Transform cameraAngle;
    public Transform spriteAngle;
    public Animator animator;
    public ThirdPersonController thirdPersonController;

    public Transform frontSideRightTransform;
    public Transform sideRightTransform;
    public Transform behindSideRightTransform;

    #region State Bools

    bool idle;
    bool walking;
    bool inAir;
    bool attacking;

    #endregion

    #region SideBools

    bool sideFront;
    bool sideBack;
    bool sideFrontSideRight;
    bool sideBackSideLeft;
    bool sideFrontSideLeft;
    bool sideBackSideRight;
    bool sideSideRight;
    bool sideSideLeft;

    bool generalSideBack;
    bool generalSideFront;
    bool generalSide;

    public float dotter;

    #endregion

    #region IdleBools

    bool frontSprite;
    bool frontSideRight;
    bool frontSideLeft;
    bool sideRight;
    bool sideLeft;
    bool behindSideRight;
    bool behindSideLeft;
    bool behindSprite;

    #endregion

    #region WalkingBools

    bool walkFront;
    bool walkFrontSideRight;
    bool walkSideRight;
    bool walkBehindSideRight;
    bool walkBehind;
    bool walkBehindSideLeft;
    bool walkSideLeft;
    bool walkFrontSideLeft;

    #endregion

    #region ThirdPersonControllerBools

    bool playerIsMoving;
    bool playerIsInAir;
    bool noIdle;

    //stops the camera rotation (this is intended for future development) - USE WHILE ATTACKING
    public bool stopBecauseYes;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        frontSprite = false;
        frontSideRight = false;
        frontSideLeft = false;
        sideRight = false;
        sideLeft = false;
        behindSideRight = false;
        behindSideLeft = false;
        behindSprite = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorBools();
        CheckTPCBools();
        LockCamera();
        GetStates();
        SetCameraRotationValues();
        GetAllRotations();
    }

    //IMPORTANT
    void GetAllRotations()
    {
        GetIdleRotations();
        GetWalkingRotations();
    }

    void GetStates()
    {
        #region Idle

        if (!playerIsInAir && !playerIsMoving)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }

        #endregion

        #region Walking

        if (!playerIsInAir && playerIsMoving)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        #endregion

        #region In Air

        if (playerIsInAir)
        {
            inAir = true;
        }
        else
        {
            inAir = false;
        }

        #endregion

        #region Attacking

        #endregion
    }

    void LockCamera()
    {
        //if (playerIsInAir)
        //{
          //  stopBecauseYes = true;
        //}
        //else
        //{
          //  stopBecauseYes = false;
        //}
    }

    void GetIdleRotations()
    {
        if (idle)
        {
            #region directions

            #region Front

            #region Example

            if (sideFront)
            {
                frontSprite = true;
            }
            else
            {
                frontSprite = false;
            }

            #endregion

            #endregion

            #region frontSideLeft

            if (sideFrontSideLeft)
            {
                frontSideLeft = true;
            }
            else
            {
                frontSideLeft = false;
            }

            #endregion

            #region SideLeft

            if (sideSideLeft)
            {
                sideLeft = true;
            }
            else
            {
                sideLeft = false;
            }

            #endregion

            #region behindSideLeft

            if (sideBackSideLeft)
            {
                behindSideLeft = true;
            }
            else
            {
                behindSideLeft = false;
            }

            #endregion

            #region Behind

            if (sideBack)
            {
                behindSprite = true;
            }
            else
            {
                behindSprite = false;
            }

            #endregion

            #region behindSideRight

            if (sideBackSideRight)
            {
                behindSideRight = true;
            }
            else
            {
                behindSideRight = false;
            }

            #endregion

            #region sideRight

            if (sideSideRight)
            {
                sideRight = true;
            }
            else
            {
                sideRight = false;
            }

            #endregion

            #region frontSideRight

            if (sideFrontSideRight)
            {
                frontSideRight = true;
            }
            else
            {
                frontSideRight = false;
            }

            #endregion

            #endregion
        }
        else
        {
            frontSideLeft = false;
            frontSideRight = false;
            behindSideLeft = false;
            behindSideRight = false;
            frontSprite = false;
            behindSprite = false;
            sideLeft = false;
            sideRight = false;
        }
    }

    void CheckTPCBools()
    {
        //checks if the player is moving
        if (thirdPersonController.isMoving == true)
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }

        //checks if the player is in air
        if (!thirdPersonController.Grounded == true )
        {
            playerIsInAir = true;
        }
        else
        {
            playerIsInAir = false;
        }

        //stops the camera rotation
        if (stopBecauseYes)
        {
            thirdPersonController.LockCameraPosition = true;
        }
        else
        {
            thirdPersonController.LockCameraPosition = false;
        }
    }

    void GetWalkingRotations()
    {
        if (walking)
        {
            #region Directions

            #region Front

            if (sideFront)
            {
                walkFront = true;
            }
            else
            {
                walkFront = false;
            }

            #endregion

            #region Back

            if (sideBack)
            {
                walkBehind = true;
            }
            else
            {
                walkBehind = false;
            }

            #endregion

            #region FrontSideRight

            if (sideFrontSideRight)
            {
                walkFrontSideRight = true;
            }
            else
            {
                walkFrontSideRight = false;
            }

            #endregion

            #region SideRight

            if (sideSideRight)
            {
                walkSideRight = true;
            }
            else
            {
                walkSideRight = false;
            }

            #endregion

            #region BackSideRight

            if (sideBackSideRight)
            {
                walkBehindSideRight = true;
            }
            else
            {
                walkBehindSideRight = false;
            }

            #endregion

            #region BackSideLeft

            if (sideBackSideLeft)
            {
                walkBehindSideLeft = true;
            }
            else
            {
                walkBehindSideLeft = false;
            }

            #endregion

            #region SideLeft
            
            if (sideSideLeft)
            {
                walkSideLeft = true;
            }
            else
            {
                walkSideLeft = false;
            }

            #endregion

            #region FrontSideLeft

            if (sideFrontSideLeft)
            {
                walkFrontSideLeft = true;
            }
            else
            {
                walkFrontSideLeft = false;
            }

            #endregion

            #endregion
        }
        else
        {
            walkFrontSideLeft = false;
            walkFrontSideRight = false;
            walkBehind = false;
            walkFront = false;
            walkSideLeft = false;
            walkSideRight = false;
            walkBehindSideLeft = false;
            walkBehindSideRight = false;
        }

    }

    void SetAnimatorBools()
    {
        #region Idle

        //front
        if (frontSprite)
        {
            animator.SetBool("front", true);
        }
        else
        {
            animator.SetBool("front", false);
        }

        //frontSideRight
        if (frontSideRight)
        {
            animator.SetBool("frontSide_right", true);
        }
        else
        {
            animator.SetBool("frontSide_right", false);
        }

        //sideRight
        if (sideRight)
        {
            animator.SetBool("side_right", true);
        }
        else
        {
            animator.SetBool("side_right", false);
        }

        //behindSideRight
        if (behindSideRight)
        {
            animator.SetBool("behindSide_right", true);
        }
        else
        {
            animator.SetBool("behindSide_right", false);
        }

        //behind
        if (behindSprite)
        {
            animator.SetBool("behind", true);
        }
        else
        {
            animator.SetBool("behind", false);
        }

        //behindSideLeft
        if (behindSideLeft)
        {
            animator.SetBool("behindSide_left", true);
        }
        else
        {
            animator.SetBool("behindSide_left", false);
        }

        //sideLeft
        if (sideLeft)
        {
            animator.SetBool("side_left", true);
        }
        else
        {
            animator.SetBool("side_left", false);
        }

        //frontSideLeft
        if (frontSideLeft)
        {
            animator.SetBool("frontSide_left", true);
        }
        else
        {
            animator.SetBool("frontSide_left", false);
        }

        #endregion

        #region Walking

        if (walkBehind)
        {
            animator.SetBool("BackWalking", true);
        }
        else
        {
            animator.SetBool("BackWalking", false);
        }

        if (walkFront)
        {
            animator.SetBool("FrontWalking", true);
        }
        else
        {
            animator.SetBool("FrontWalking", false);
        }

        if (walkBehindSideRight)
        {
            animator.SetBool("BackSideRightWalk", true);
        }
        else
        {
            animator.SetBool("BackSideRightWalk", false);
        }

        if (walkBehindSideLeft)
        {
            animator.SetBool("BackSideLeftWalk", true);
        }
        else
        {
            animator.SetBool("BackSideLeftWalk", false);
        }

        if (walkFrontSideRight)
        {
            animator.SetBool("FrontSideRightWalk", true);
        }
        else
        {
            animator.SetBool("FrontSideRightWalk", false);
        }

        if (walkFrontSideLeft)
        {
            animator.SetBool("FrontSideLeftWalk", true);
        }
        else
        {
            animator.SetBool("FrontSideLeftWalk", false);
        }

        if (walkSideRight)
        {
            animator.SetBool("SideRightWalk", true);
        }
        else
        {
            animator.SetBool("SideRightWalk", false);
        }

        if (walkSideLeft)
        {
            animator.SetBool("SideLeftWalk", true);
        }
        else
        {
            animator.SetBool("SideLeftWalk", false);
        }

        #endregion
    }

    void SetCameraRotationValues()
    {
        Vector3 direzione = Vector3.Normalize(
            cameraAngle.position - spriteAngle.position);

        float dot = Vector3.Dot(lhs: spriteAngle.forward, rhs: direzione);

        dotter = dot;

        //.707 = 45°
        //.3535 = 22.5°

        sideFront = dot > 0.75;
        sideBack = dot < -0.75;
        sideBackSideLeft = dot < -0.25 && dot > -0.75 && !sideBackSideRight;
        sideFrontSideLeft = dot > 0.25 && dot < 0.75 && !sideFrontSideRight;
        sideSideLeft = dot > -0.25 && dot < 0.25 && !sideSideRight;



        Vector3 direzione2 = Vector3.Normalize(
            cameraAngle.position - sideRightTransform.position);

        float dot2 = Vector3.Dot(lhs: sideRightTransform.forward, rhs: direzione2);

        sideSideRight = dot2 > 0.75;



        Vector3 direzione3 = Vector3.Normalize(
            cameraAngle.position - frontSideRightTransform.position);

        float dot3 = Vector3.Dot(lhs: frontSideRightTransform.forward, rhs: direzione3);

        sideFrontSideRight = dot3 > 0.75;



        Vector3 direzione4 = Vector3.Normalize(
            cameraAngle.position - behindSideRightTransform.position);

        float dot4 = Vector3.Dot(lhs: behindSideRightTransform.forward, rhs: direzione4);

        sideBackSideRight = dot4 > 0.75;

    }
}
