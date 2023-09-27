using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _projectileSpeed = 10;
    [SerializeField] float _projectileLifetime = 5;
    [SerializeField] float _baseFiringRate = .2f;

    [Header("AI")]
    [SerializeField] bool _useAI;
    [SerializeField] float _firingRateVariance = 0f;
    [SerializeField] float _minimumFiringRate = .1f;

    [HideInInspector] public bool IsFiring;

    Coroutine _firingCoroutine;
    AudioPlayer _audioPlayer;

    void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (_useAI)
        {
            IsFiring = true;
        }
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
            float timeToNextProjectile = Random.Range(
                _baseFiringRate - _firingRateVariance,
                _baseFiringRate + _firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, _minimumFiringRate, float.MaxValue);

            _audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
