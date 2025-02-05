using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float damageTraps = 10f;
    [SerializeField] private Image healthBar;

    private float _maxHealth;
    private float _healthAnim;

    private void Awake()
    {
        _maxHealth = health;
        _healthAnim = health;
    }
    
    private void Update()
    {
        UpdateHealthBar();
        if (_healthAnim > health)
        {
            _healthAnim -= 0.3f;
        }
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            health = 0f;
            _healthAnim = 0;
            UpdateHealthBar();
            Death();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar is null)
        {
            return;
        }
        
        healthBar.fillAmount = _healthAnim / _maxHealth;
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
        if (other.CompareTag("DeathZone"))
        {
            Death();
        }
    }
}
