using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _health = 50;
    [SerializeField] ParticleSystem _hitEffect;
    [SerializeField] ParticleSystem _destroyEffect;
    [SerializeField] bool _applyCameraShake;
    [SerializeField] bool _isPlayer;
    [SerializeField] int score = 50;

    CameraShake _cameraShake;
    AudioPlayer _audioPlayer;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null )
        {
            TakeDamage(damageDealer.GetDamage());
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            PlayHitEffect();
            _audioPlayer.PlayDamageClip();
        }
    }

    void Die()
    {
        if (!_isPlayer)
        {
            _scoreKeeper.AddScore(score);
        }
        PlayDestroyEffect();
        _audioPlayer.PlayExplodeClip();
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (_hitEffect != null)
        {
            ParticleSystem instance = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void PlayDestroyEffect()
    {
        if (_destroyEffect != null )
        {
            ParticleSystem instance = Instantiate(_destroyEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (_cameraShake != null && _applyCameraShake)
        {
            _cameraShake.Play();
        }
    }

    public int GetHealth => _health;
}
