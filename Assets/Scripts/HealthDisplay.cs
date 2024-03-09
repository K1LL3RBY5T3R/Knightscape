using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealth; 

    // Update is called once per frame
    void Update()
    {
        float normalizedHealth = playerHealth.currentHealth / (float)playerHealth.maxHealth; // Sets the health value on the healthbar to a percentage of the health between 0 and 1 
        healthSlider.value = normalizedHealth;
    }
}

