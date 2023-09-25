using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int _damage = 10;

    public int GetDamage() => _damage;

    public void Hit()
    {
        Destroy(gameObject);
    }
}
