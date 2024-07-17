using StarterAssets;
using System.Collections;
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
    public bool IsFading;
    public bool isChangingColor;
    public bool isTransparent;

    void Awake ()
    {
        playerController = FindObjectOfType<ThirdPersonController>();

        leftStaminaSlider.maxValue = playerController.maxStamina;
        rightStaminaSlider.maxValue = playerController.maxStamina;

        IsFading = false;
        isChangingColor = false;
    }

    void Update ()
    {
        // sets slider value and maxValue to health
        healthSlider.GetComponent<Slider>().value = health;
        healthSlider.GetComponent<Slider>().maxValue = maxHealth;

        // it will look like:  health / maxHealth
        healthText.GetComponent<TMP_Text>().text = health.ToString() + '/' + maxHealth.ToString();


        // CHANGE IF NEEDED
        if (health > maxHealth)
            health = maxHealth;

        // applying stamina value
        leftStaminaSlider.value = playerController.stamina;
        rightStaminaSlider.value = playerController.stamina;

        



        // Fading in animation if statement
        if (playerController.stamina >= playerController.maxStamina && !IsFading)
        {
            IsFading = true;

            // start animation
            StartCoroutine(SmoothFadeStamina(.5f, true));
        }


        else if (!IsFading && isTransparent)
        {
            IsFading = true;

            StartCoroutine(SmoothFadeStamina(.5f, false));
        }





        // Fade color stamina logic 
        if (playerController.isRegenerating && !isChangingColor && !isTransparent)
        {
            isChangingColor = true;
            Debug.Log("imma put some red shit rn :fire_emoji:");
            StartCoroutine(FadeColorStamina(colorRed, .5f));
            
        }
        else if (!playerController.isRegenerating && !isChangingColor && !isTransparent)
        {
            isChangingColor = true;

            StartCoroutine(FadeColorStamina(colorWhite, .5f));
        }

    }



    IEnumerator SmoothFadeStamina (float timeFading, bool isFadingIn)
    {
        // that is required for that smooth animation
        Image leftStaminaBackground = leftStaminaSlider.transform.GetChild(0).GetComponent<Image>();
        Image rightStaminaBackground = rightStaminaSlider.transform.GetChild(0).GetComponent<Image>();

        Image leftStaminaFill = leftStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        Image rightStaminaFill = rightStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();


        // if its supposed to fade out, else fade in
        if (isFadingIn)
        {
            leftStaminaBackground.CrossFadeAlpha(0, timeFading, true);
            rightStaminaBackground.CrossFadeAlpha(0, timeFading, true);

            leftStaminaFill.CrossFadeAlpha(0, timeFading, true);
            rightStaminaFill.CrossFadeAlpha(0, timeFading, true);
            isTransparent = true;
        }
        else
        {
            leftStaminaBackground.CrossFadeAlpha(1, timeFading, true);
            rightStaminaBackground.CrossFadeAlpha(1, timeFading, true);

            leftStaminaFill.CrossFadeAlpha(1, timeFading, true);
            rightStaminaFill.CrossFadeAlpha(1, timeFading, true);
            isTransparent = false;
        }

        yield return new WaitForSeconds(timeFading);
        IsFading = false;
    }

    // Used to fade fill color of stamina bar
    IEnumerator FadeColorStamina (Color colorToApply, float duration)
    {
        Image leftStaminaFill = leftStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        Image rightStaminaFill = rightStaminaSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();



        leftStaminaFill.CrossFadeColor(colorToApply, duration, true, true);
        rightStaminaFill.CrossFadeColor(colorToApply, duration, true, true);

        yield return new WaitForSeconds(duration);
        isChangingColor = false;
    }
}
