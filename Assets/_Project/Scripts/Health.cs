using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _health = 50;
    [SerializeField] ParticleSystem _hitEffect;
    [SerializeField] ParticleSystem _destroyEffect;
    [SerializeField] bool _applyCameraShake;

    CameraShake _cameraShake;

    private void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
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
            PlayDestroyEffect();
            Destroy(gameObject);
        }
        else
        {
            PlayHitEffect();
        }
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
}
