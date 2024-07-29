using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimator : MonoBehaviour
{
    public Transform cameraAngle;
    public Transform spriteAngle;
    public Animator animator;

    public bool frontSprite;
    public bool frontSideRight;
    public bool frontSideLeft;
    public bool sideRight;
    public bool sideLeft;
    public bool behindSideRight;
    public bool behindSideLeft;
    public bool behindSprite;

    public float generalAngle;
   

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
            frontSprite = true;
        }
        else
        {
            frontSprite = false;
        }
        
        #endregion

        #endregion

        #region frontSideLeft

        if (generalAngle < 337.5 && generalAngle > 292.5)
        {
            frontSideLeft = true;
        }
        else
        {
            frontSideLeft = false;
        }

        #endregion

        #region SideLeft

        if (generalAngle < 292.5 && generalAngle > 247.5)
        {
            sideLeft = true;
        }
        else
        {
            sideLeft = false;
        }

        #endregion

        #region behindSideLeft

        if (generalAngle < 247.5 && generalAngle > 202.5)
        {
            behindSideLeft = true;
        }
        else
        {
            behindSideLeft = false;
        }

        #endregion

        #region Behind

        if (generalAngle < 202.5 && generalAngle > 157.5)
        {
            behindSprite = true;
        }
        else
        {
            behindSprite = false;
        }

        #endregion

        #region behindSideRight

        if (generalAngle < 157.5 && generalAngle > 112.5)
        {
            behindSideRight = true;
        }
        else
        {
            behindSideRight = false;
        }

        #endregion

        #region sideRight

        if (generalAngle < 112.5 && generalAngle > 67.5)
        {
            sideRight = true;
        }
        else
        {
            sideRight = false;
        }

        #endregion

        #region frontSideRight

        if (generalAngle < 67.5 && generalAngle > 22.5)
        {
            frontSideRight = true;
        }
        else
        {
            frontSideRight = false;
        }

        #endregion

        #endregion

        SetAnimatorBools();
    }

    void SetAnimatorBools()
    {
        //front
        if (frontSprite)
        {
            animator.SetBool("fron", true);
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
    }
}
