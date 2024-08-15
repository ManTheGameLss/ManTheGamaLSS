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

    public bool walkFront;
    bool walkFrontSideRight;
    bool walkSideRight;
    bool walkBehindSideRight;
    bool walkBehind;
    bool walkBehindSideLeft;
    bool walkSideLeft;
    bool walkFrontSideLeft;

    #endregion

    #region ThirdPersonControllerBools

    float generalAngle;
    public bool playerIsMoving;
    bool playerIsInAir;
    bool noIdle;

    //stops the camera rotation (this is intended for future development)
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
        GetIdleRotations();
        SetAnimatorBools();
        CheckTPCBools();
        GetWalkingRotations();
        LockCamera();
        GetGeneralRotations();
        GetStates();
    }

    void GetStates()
    {
        #region Idle

        if (!playerIsInAir && !playerIsMoving && !noIdle)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }

        #endregion

        #region Walking

        if (!playerIsInAir && playerIsMoving && noIdle)
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

    void GetGeneralRotations()
    {
        //the difference between the camera y rotation and the sprite y rotation is calculated and called "generalAngle"
        generalAngle = cameraAngle.rotation.eulerAngles.y - spriteAngle.rotation.eulerAngles.y;

        //if generalAngle is greater than a certain number and smaller than the same number multiplied by -1 an animation is triggered that will change the sprite rendered
        //only the front one has been done
        #region directions

        //rotationg to the left makes generalAngle go up, rotationg to the right makes it go down

        #region Front

        #region Example
        //in this case, if generalAngle is a number between 23 and -23 it meens that you're watching the sprite from the front and renders the front-sprite
        if ((generalAngle < 22.5 && generalAngle > 0) || (generalAngle < 360 && generalAngle > 337.5))
        {
            sideFront = true;
        }
        else
        {
            sideFront = false;
        }

        #endregion

        #endregion

        #region frontSideLeft

        if (generalAngle < 337.5 && generalAngle > 292.5)
        {
            sideFrontSideLeft = true;
        }
        else
        {
            sideFrontSideLeft = false;
        }

        #endregion

        #region SideLeft

        if (generalAngle < 292.5 && generalAngle > 247.5)
        {
            sideSideLeft = true;
        }
        else
        {
            sideSideLeft = false;
        }

        #endregion

        #region behindSideLeft

        if (generalAngle < 247.5 && generalAngle > 202.5)
        {
            sideBackSideLeft = true;
        }
        else
        {
            sideBackSideLeft = false;
        }

        #endregion

        #region Behind

        if (generalAngle < 202.5 && generalAngle > 157.5)
        {
            sideBack = true;
        }
        else
        {
            sideBack = false;
        }

        #endregion

        #region behindSideRight

        if (generalAngle < 157.5 && generalAngle > 112.5)
        {
            sideBackSideRight = true;
        }
        else
        {
            sideBackSideRight = false;
        }

        #endregion

        #region sideRight

        if (generalAngle < 112.5 && generalAngle > 67.5)
        {
            sideSideRight = true;
        }
        else
        {
            sideSideRight = false;
        }

        #endregion

        #region frontSideRight

        if (generalAngle < 67.5 && generalAngle > 22.5)
        {
            sideFrontSideRight = true;
        }
        else
        {
            sideFrontSideRight = false;
        }

        #endregion

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
        #region front
        //DEVI CREARE UN BOOL CHIAMATO "ALLOW WALK..." PER OGNI DIREZIONE. IL BOOL SERVIRà COME CONDIZIONE IN MODO DA POTER DETECTARE SE BISOGNA FARE L'ANIMAZIONE DI AVANTI O ALTRE DIREZIONI MA NON ATTIVARE I BOOL IDLE COSì CHE NON RENDERIZZINO GLI IDLE SPRITE
        if ((playerIsMoving && frontSprite && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir && walkFront && frontSprite))
        {
            noIdle = true;
            walkFront = true;
        }
        else
        {
            walkFront = false;
            noIdle = false;
        }

        #endregion

        #region frontSideRight

        if ((playerIsMoving && frontSideRight && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir))
        {
            noIdle = true;
            walkFrontSideRight = true;
        }
        else
        {
            walkFrontSideRight = false;
            noIdle = false;
        }

        #endregion

        #region sideRight

        if ((playerIsMoving && sideRight && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir))
        {
            noIdle = true;
            walkSideRight = true;
        }
        else
        {
            walkSideRight = false;
            noIdle = false;
        }

        #endregion

        #region behindSideRight

        if ((playerIsMoving && behindSideRight && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir))
        {
            noIdle = true;
            walkBehindSideRight = true;
        }
        else
        {
            walkBehindSideRight = false;
            noIdle = false;
        }

        #endregion

        #region behind

        if ((playerIsMoving && behindSprite && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir))
        {
            noIdle = true;
            walkBehind = true;
        }
        else
        {
            walkBehind = false;
            noIdle = false;
        }

        #endregion

        #region behindSideLeft

        if ((playerIsMoving && behindSideLeft && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir))
        {
            noIdle = true;
            walkBehindSideLeft = true;
        }
        else
        {
            walkBehindSideLeft = false;
            noIdle = false;
        }

        #endregion

        #region sideLeft

        if ((playerIsMoving && sideLeft && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir))
        {
            noIdle = true;
            walkSideLeft = true;
        }
        else
        {
            walkSideLeft = false;
            noIdle = false;
        }

        #endregion

        #region frontSideLeft

        if ((playerIsMoving && frontSideLeft && !playerIsInAir) || (playerIsMoving && noIdle && !playerIsInAir))
        {
            noIdle = true;
            walkFrontSideLeft = true;
        }
        else
        {
            walkFrontSideLeft = false;
            noIdle = false;
        }

        #endregion


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
    }
}
