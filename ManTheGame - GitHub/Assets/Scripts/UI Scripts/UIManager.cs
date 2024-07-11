using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Hides in inspector because health and max health
    // will be a variable in player script

    // for now its 100/100
     public int health;
     public int maxHealth;

    // health UI
    public Slider healthSlider;
    public TMP_Text healthText;

    void Awake()
    {

        // it will look like health / maxHealth
        healthText.GetComponent<TMP_Text>().text = health.ToString() + '/' + maxHealth.ToString();


        // Change to void Update if max health will be changed
        healthSlider.GetComponent<Slider>().maxValue = maxHealth;
    }

    void Update()
    {
        healthSlider.GetComponent<Slider>().value = health;
        
    }
}
