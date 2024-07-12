using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Hide later in inspector because health and max health
    // will be a variable in player script

    // for now its 100/100
     public int health;
     public int maxHealth;

    // health UI
    public Slider healthSlider;
    public TMP_Text healthText;

    // stamina UI
    public Slider leftStaminaSlider;
    public Slider rightStaminaSlider;



    // other
    private ThirdPersonController playerController;
    private bool canFade;

    void Awake()
    {
        playerController = FindObjectOfType<ThirdPersonController>();

        leftStaminaSlider.maxValue = playerController.maxStamina;
        rightStaminaSlider.maxValue = playerController.maxStamina;
        canFade = false;
    }

    void Update()
    {
        // sets slider value and maxValue to health
        healthSlider.GetComponent<Slider>().value = health;
        healthSlider.GetComponent<Slider>().maxValue = maxHealth;

        // it will look like:  health / maxHealth
        healthText.GetComponent<TMP_Text>().text = health.ToString() + '/' + maxHealth.ToString();
        
        // CHANGE IF NEEDED
        if(health > maxHealth) health = maxHealth;

        leftStaminaSlider.value = playerController.stamina;
        rightStaminaSlider.value = playerController.stamina;


        // Fading in animation if statement
        if (playerController.stamina >= playerController.maxStamina && !canFade)
        {
            canFade = true;

            // start animation
            StartCoroutine(SmoothFadeStamina(.5f, true));
        }
        else if (playerController.stamina < playerController.maxStamina && !canFade)
        {
            canFade = true;

            StartCoroutine(SmoothFadeStamina(.5f, false));
        }

    }
    IEnumerator SmoothFadeStamina (float timeFading, bool isFading)
    {
        // that is required for that smooth animation
        Image leftStaminaBackground = leftStaminaSlider.transform.GetChild(0).GetComponent<Image>();
        Image rightStaminaBackground = rightStaminaSlider.transform.GetChild(0).GetComponent<Image>();

        Image leftStaminaFill = leftStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        Image rightStaminaFill = rightStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();


        // if its supposed to fade out, else fade in
        if (isFading)
        {
            leftStaminaBackground.CrossFadeAlpha(0, timeFading, true);
            rightStaminaBackground.CrossFadeAlpha(0, timeFading, true);

            leftStaminaFill.CrossFadeAlpha(0, timeFading, true);
            rightStaminaFill.CrossFadeAlpha(0, timeFading, true);
        }
        else
        {
            leftStaminaBackground.CrossFadeAlpha(1, timeFading, true);
            rightStaminaBackground.CrossFadeAlpha(1, timeFading, true);

            leftStaminaFill.CrossFadeAlpha(1, timeFading, true);
            rightStaminaFill.CrossFadeAlpha(1, timeFading, true);
        }
       
        yield return new WaitForSeconds(timeFading);
        canFade = false;
    }
}
