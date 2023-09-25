using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _health = 50;

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null )
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();

        }
    }

    void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
