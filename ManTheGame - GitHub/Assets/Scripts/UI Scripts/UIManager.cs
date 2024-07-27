using StarterAssets;
using System.Collections;
using TMPro;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Hide later in inspector because health and max health
    // will be a variable in player script

    // health UI
    [Header("health UI")]
    // for now its 100/100
    public int health;
    public int maxHealth;

    
    public Image healthBar;
    public TMP_Text healthText;

    public float lerpSpeed = 1;

    public Color health1Color;
    public Color health2Color;

    [Space]
    [Header("Stamina UI")]
    // stamina UI
    public Slider leftStaminaSlider;
    public Slider rightStaminaSlider;


    public Color stamina1Color;
    public Color stamina2Color;

    [Space]
    [Header("Pause menu")]

    public GameObject background;
    public GameObject pauseMenu;
    public bool isPauseActive;
    private ThirdPersonController playerController;

    public GameObject settingsMenu;

    [Space]
    [Header("Other Important stuff")]
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

        isPauseActive = false;
    }

    void Update ()
    {

        // makes sick lerping
        float _lerpSpeed = lerpSpeed * Time.deltaTime;
        float amountToFill = (float)health / (float)maxHealth;

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, amountToFill, _lerpSpeed);


        // makes sick Colors  (yea i dont know how to name it xD)

        Color color = Color.Lerp(health2Color, health1Color, amountToFill);

        healthBar.color = color;
        

        // it will look like:  health / maxHealth
        healthText.GetComponent<TMP_Text>().text = health.ToString() + '/' + maxHealth.ToString();


        // CHANGE IF NEEDED
        if (health > maxHealth)
        {
            health = maxHealth;
        }
            

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
            StartCoroutine(FadeColorStamina(stamina2Color, .5f));
            
        }
        else if (!playerController.isRegenerating && !isChangingColor && !isTransparent)
        {
            isChangingColor = true;

            StartCoroutine(FadeColorStamina(stamina1Color, .5f));
        }


        // Damaging the player

        // WARNING: REMOVE LATER IN DEVELOPMENT
        #region inputStuff
        if (Input.GetKeyDown(KeyCode.K))
        {
            DamageOnPurpose(5);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DamageOnPurpose(50);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            DamageOnPurpose(-20);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            DamageOnPurpose(-50);
        }

        // stuff for pause Menu

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuSwitching();
        }
            
        #endregion
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

    public void DamageOnPurpose (int healthAmount)
    {
        health -= healthAmount;
    }

    public void PauseMenuSwitching()
    {
        isPauseActive = !isPauseActive;

        if (isPauseActive)
        {
            background.SetActive(true);
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;  
        }
        else
        {
            background.SetActive(false);
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void TurnOnSettings ()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
