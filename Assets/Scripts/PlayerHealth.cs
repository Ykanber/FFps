using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    ExpLwHealthUI ui;

    Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
        ui = FindObjectOfType<ExpLwHealthUI>();
    }

    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
            ui.ChangeHealthSlider((float)health / maxHealth);
            if (health <= 0)
            {
                player.deathCount++;
                Die();
            }
        }
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        health += amount;
        ui.ChangeHealthSlider((float)health / maxHealth);
    }

    public void Die()
    {
        player.SavePlayer();
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(1);
    }
}
