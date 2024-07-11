using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Hide in inspector because health and max health
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

    private ThirdPersonController playerController;

    void Awake()
    {
        playerController = FindObjectOfType<ThirdPersonController>();

        leftStaminaSlider.maxValue = playerController.maxStamina;
        rightStaminaSlider.maxValue = playerController.maxStamina;
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
    }
}
