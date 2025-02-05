using System;
using System.Collections;
using UnityEngine;

public class MagicBookAtack : MonoBehaviour
{
    [Header("Magic Book Atack Stats")]
    [SerializeField] private float speedAtack = 2f;
    [SerializeField] private float shotDelay  = 0.3f;
    [SerializeField] private int countBulletInAtack = 3;
    
    
    [Header("GameObjects")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject player;
    private float _timer;
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= speedAtack)
        {
            try
            {
                StartCoroutine(Atack());
                _timer = 0;
            }
            catch (MissingReferenceException e)
            {
                Debug.Log(e);
            }
        }
    }

    private IEnumerator Atack()
    {
        var bulletDirection = player.transform.position - transform.position;

        for (int i = 0; i < countBulletInAtack; i++)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(bulletDirection));
            
            yield return new WaitForSeconds(shotDelay);
        }
    }
}
