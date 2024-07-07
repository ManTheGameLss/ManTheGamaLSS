using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    PlayerLocomotion playerLocomotion;

    // Start is called before the first frame update

    private void Awake()
    {
        playerLocomotion = FindObjectOfType<PlayerLocomotion>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerLocomotion.transform.position;
        transform.rotation = playerLocomotion.transform.rotation;
    }
}
