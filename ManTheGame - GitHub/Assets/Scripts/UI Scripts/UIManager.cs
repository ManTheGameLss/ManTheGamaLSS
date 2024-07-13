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

    public Color colorRed;
    public Color colorWhite;

    // other
    private ThirdPersonController playerController;
    [HideInInspector] private bool canFade;
    [HideInInspector] private bool fadeColor;

    void Awake()
    {
        playerController = FindObjectOfType<ThirdPersonController>();

        leftStaminaSlider.maxValue = playerController.maxStamina;
        rightStaminaSlider.maxValue = playerController.maxStamina;

        canFade = false;
        fadeColor = false;
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

        // applying stamina value
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

        if (playerController.isRegenerating && !fadeColor)
        {
            fadeColor = true;

            StartCoroutine(FadeColorStamina(colorRed, .5f));
        }
        if (!playerController.isRegenerating && !fadeColor)
        {
            fadeColor = true;

            StartCoroutine(FadeColorStamina(colorWhite, .5f));
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

    // Used to fade fill color of stamina bar
    IEnumerator FadeColorStamina (Color colorToApply, float duration)
    {

        Image leftStaminaBackground = leftStaminaSlider.transform.GetChild(0).GetComponent<Image>();
        Image rightStaminaBackground = rightStaminaSlider.transform.GetChild(0).GetComponent<Image>();

        Image leftStaminaFill = leftStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        Image rightStaminaFill = rightStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();

        

        leftStaminaFill.CrossFadeColor(colorToApply, duration, true, true);
        rightStaminaFill.CrossFadeColor(colorToApply, duration, true, true);

        yield return new WaitForSeconds(duration);
        fadeColor = false;
    }
}
