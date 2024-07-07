using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    public Transform targetTransform; //The object the camera will follow
    public Transform cameraPivot;
    public Transform cameraTransform; // default camera position ( no collision )
    public LayerMask collisionLayers;
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;

    public float cameraCollisionOffset = 0.2f; //camera collision jump-distance
    public float minimumCollisionOffset = 0.2f;
    public float cameraCollisionRadius = 0.2f;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 0.1f; //rotate left and right
    public float cameraPivotSpeed = 0.1f; //rotate up and down

    public float lookAngle; //up and down camera
    public float pivotAngle; //left and right camera
    public float minimumPivotAngle = -35;
    public float maximumPivotAngle = 35;

    private void Awake()
    {
        playerLocomotion = FindObjectOfType<PlayerLocomotion>();
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;

        // lock mouse and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        HandleCameraCollisions();

        if (playerLocomotion.isGrounded == false)
            return;

        RotateCamera();
    }

    private void FollowTarget()
    {
        Vector3 targetPostion = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPostion;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation; //"localRotation" � la rotazione  dell'oggetto e non la sua rotazione in relazione al resto del mondo
    }

    private void HandleCameraCollisions()
    {
        Vector3 player_to_cam = cameraTransform.position - cameraPivot.position;
        RaycastHit hit;
        float targetPosition = defaultPosition;

        if (Physics.Raycast(cameraPivot.transform.position, player_to_cam, out hit, cameraCollisionRadius, collisionLayers, QueryTriggerInteraction.Ignore))
        {
            float distance = Vector3.Distance(cameraTransform.position, hit.point);
            targetPosition =- distance - cameraCollisionOffset;
        }
       

        if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
        {
          targetPosition = targetPosition - minimumCollisionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
