using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Text healthBar;

    // Displaying healthbar on UI
    void Start()
    {
        healthBar = GetComponent<Text>();
    }
    void Update()
    {
        healthBar.text = "HP: " + Player.health;
    }
}
