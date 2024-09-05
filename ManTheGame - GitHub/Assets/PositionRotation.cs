using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRotation : MonoBehaviour
{
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = playerTransform.position;
        //transform.rotation = Quaternion.Euler(0f, playerTransform.rotation.eulerAngles.y, 0f);
        transform.rotation = playerTransform.rotation;
    }
}
