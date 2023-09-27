using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip _shootingClip;
    [SerializeField] [Range(0f, 1f)] float _shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip _damageClip;
    [SerializeField] [Range(0f, 1f)] float _damageVolume = 1f;
    [SerializeField] AudioClip _explodeClip;
    [SerializeField] [Range(0f, 1f)] float _explodeVolume = 1f;

    private Vector3 _audioClipPosition = Camera.main.transform.position;

    public void PlayShootingClip()
    {
        PlayClip(_shootingClip, _shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(_damageClip, _damageVolume);
    }

    public void PlayExplodeClip()
    {
        PlayClip(_explodeClip, _explodeVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, _audioClipPosition, volume);
        }
    }
}
