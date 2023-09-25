using System;
using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _projectileSpeed = 10;
    [SerializeField] float _projectileLifetime = 5;
    [SerializeField] float _firingRate = .2f;

    public bool IsFiring;

    Coroutine _firingCoroutine;

    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (IsFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!IsFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = transform.up * _projectileSpeed;
            }

            Destroy(instance, _projectileLifetime);
            yield return new WaitForSeconds(_firingRate);
        }
    }
}
