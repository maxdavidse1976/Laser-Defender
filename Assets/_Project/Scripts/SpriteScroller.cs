using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 _moveSpeed;

    Vector2 _offset;
    Material _material;

    void Awake() => _material = GetComponent<SpriteRenderer>().material;

    void Update()
    {
        _offset = _moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += _offset;
    }
}
