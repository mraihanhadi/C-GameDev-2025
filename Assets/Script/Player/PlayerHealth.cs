using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats stats;
    public float maxHealth;
    public float currentHealth;
    public UnityEngine.UI.Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = stats.Health;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(5);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            GainHP(5);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        if(currentHealth <= 0)
        {
            Died();
        }
        UpdateHealthBar();
    }

    void GainHP(float amount)
    {
        currentHealth = currentHealth + amount;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth/maxHealth;
    }

    void Died()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
