using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CheckboxScript : MonoBehaviour
{
    public Texture boxFull;
    public Texture boxCut;
    public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        bool isOnState = Convert.ToBoolean(PlayerPrefs.GetInt("sprintToogle Bool"));
        isOn = isOnState;

        switchCheckmark();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchCheckmark ()
    {

        RawImage boxChild = transform.GetChild(0).GetComponent<RawImage>();

        GameObject checkmarkObj = transform.GetChild(1).gameObject;

        isOn = !isOn;

        if (isOn == true)
        {
            checkmarkObj.SetActive(true);

            PlayerPrefs.SetInt("SprintToogle Bool", 1);
        }
        else
        {
            checkmarkObj.SetActive(false);
        }
    }
}
