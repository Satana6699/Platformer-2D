using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float damageTraps = 10f;
    [SerializeField] private Slider healthBar;
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            health = 0f;
            Death();
        }
        
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar is null)
        {
            return;
        }
        
        healthBar.value = health;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            TakeDamage(damageTraps);
        }
    }
}
