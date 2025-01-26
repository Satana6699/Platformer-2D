using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float damage = 5f;
    [SerializeField] private float atackSpeed = 0.3f;
    
    private BoxCollider _boxCollider;
    private Animator _animator;
    
    private bool _isAttacking = false;
    
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _boxCollider.enabled = false;
    }

    public void Atack()
    {
        if (_isAttacking)
        {
            return;
        }
        
        Debug.Log("Atack");

        _animator.SetTrigger("Atack");
        _isAttacking = true;
    }

    // Использовать в ивенте анимации после замаха и начала удара
    public void StartHit()
    {
        _boxCollider.enabled = true;
    }
    
    // Использовать в конце удара
    public void EndHit()
    {
        _boxCollider.enabled = false;
    }

    // Использовать в конце анимации атаки
    public void EndAtacking()
    {
        Invoke(nameof(SetIsAttacking), atackSpeed);
    }

    private void SetIsAttacking()
    {
        _isAttacking = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Нанесение урона врагу
        }
    }
}
