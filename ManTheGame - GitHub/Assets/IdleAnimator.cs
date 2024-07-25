using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimator : MonoBehaviour
{
    public Transform cameraAngle;
    public Transform spriteAngle;
    public Animator animator;

    bool frontSprite;
    bool frontSideRight;
    bool frontSideLeft;
    bool sideRight;
    bool sideLeft;
    bool behindSideRight;
    bool behindSideLeft;
    bool behindSprite;

    public float generalAngle;
    public float cameraAngleFloat;
    public float spriteAngleFloat;

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
        //the next 2 lines are just a test
        cameraAngleFloat = cameraAngle.rotation.y;
        spriteAngleFloat = spriteAngle.rotation.y;

        //the difference between the camera y rotation and the sprite y rotation is calculated and called "generalAngle"
        generalAngle = cameraAngle.rotation.y - spriteAngle.rotation.y;

        //if generalAngle is greater than a certain number and smaller than the same number multiplied by -1 an animation is triggered that will change the sprite rendered
        //only the front one has been done
        #region directions

        #region Front

        #region Example
        //in this case, if generalAngle is a number between 23 and -23 it meens that you're watching the sprite from the front and renders the front-sprite
        if (generalAngle < 24 && generalAngle > -24)
        {
            frontSprite = true;
            CheckSpriteBools();
        }
        #endregion

        #endregion

        #region Behind

        #endregion

        #region SideRight

        #endregion

        #endregion
    }
}
