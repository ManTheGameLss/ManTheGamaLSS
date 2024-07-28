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
    private void CheckSpriteBools()
    {
        //this void makes it so that only one direction-animation is played at a time so that it doesn't show the side-sprite when your supposed to see the front one ( that was an example )

        if (frontSprite)
        {
            frontSideRight = false;
            frontSideLeft = false;
            sideLeft = false;
            behindSideRight = false;
            behindSideLeft = false;
            sideRight = false;
            behindSprite = false;
        }

        if (frontSideRight)
        {
            frontSprite = false;
            frontSideLeft = false;
            sideLeft = false;
            behindSideRight = false;
            behindSideLeft = false;
            sideRight = false;
            behindSprite = false;
        }

        if (frontSideLeft)
        {
            frontSprite = false;
            frontSideRight = false;
            sideLeft = false;
            behindSideRight = false;
            behindSideLeft = false;
            sideRight = false;
            behindSprite = false;
        }

        if (sideLeft)
        {
            frontSprite = false;
            frontSideRight = false;
            frontSideLeft = false;
            behindSideRight = false;
            behindSideLeft = false;
            sideRight = false;
            behindSprite = false;
        }

        if (sideRight)
        {
            frontSprite = false;
            frontSideRight = false;
            frontSideLeft = false;
            behindSideRight = false;
            behindSideLeft = false;
            sideLeft = false;
            behindSprite = false;
        }

        if (behindSideLeft)
        {
            frontSprite = false;
            frontSideRight = false;
            frontSideLeft = false;
            behindSideRight = false;
            sideRight = false;
            sideLeft = false;
            behindSprite = false;
        }

        if (behindSideRight)
        {
            frontSprite = false;
            frontSideRight = false;
            frontSideLeft = false;
            behindSideLeft = false;
            sideRight = false;
            sideLeft = false;
            behindSprite = false;
        }

        if (behindSprite)
        {
            frontSprite = false;
            frontSideRight = false;
            frontSideLeft = false;
            behindSideLeft = false;
            sideRight = false;
            sideLeft = false;
            behindSideRight = false;
        }
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
            CheckSpriteBools();
        }
        else
        {
            frontSprite = false;
        }
        
        #endregion

        #endregion

        #region frontSideRight

        if (generalAngle < 337.5 && generalAngle > 292.5)
        {
            frontSideRight = true;
            CheckSpriteBools();
        }
        else
        {
            frontSideRight = false;
        }

        #endregion

        #region SideRight

        if (generalAngle < 292.5 && generalAngle > 247.5)
        {
            sideRight = true;
            CheckSpriteBools();
        }
        else
        {
            sideRight = false;
        }

        #endregion

        #region behindSideRight

        if (generalAngle < 247.5 && generalAngle > 202.5)
        {
            behindSideRight = true;
            CheckSpriteBools();
        }
        else
        {
            behindSideRight = false;
        }

        #endregion

        #region Behind

        if (generalAngle < 202.5 && generalAngle > 157.5)
        {
            behindSprite = true;
            CheckSpriteBools();
        }
        else
        {
            behindSprite = false;
        }

        #endregion

        #region behindSideLeft

        if (generalAngle < 157.5 && generalAngle > 112.5)
        {
            behindSideLeft = true;
            CheckSpriteBools();
        }
        else
        {
            behindSideLeft = false;
        }

        #endregion

        #region sideLeft

        if (generalAngle < 112.5 && generalAngle > 67.5)
        {
            sideLeft = true;
            CheckSpriteBools();
        }
        else
        {
            sideLeft = false;
        }

        #endregion

        #region frontSideLeft

        if (generalAngle < 67.5 && generalAngle > 22.5)
        {
            frontSideLeft = true;
            CheckSpriteBools();
        }
        else
        {
            frontSideLeft = false;
        }

        #endregion

        #endregion
    }
}
