using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float timeLive = 2f;

    private void Start()
    {
        Invoke(nameof(Destroy), timeLive);
    }
    
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerStats = other.gameObject.GetComponent<PlayerStats>();
            playerStats?.TakeDamage(damage);
        }

        Death();
    }
}
