using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 5;
    [SerializeField] float _paddingLeft, _paddingRight, _paddingTop, _paddingBottom;
    Vector2 _rawInput;

    Vector2 _minBounds;
    Vector2 _maxBounds;
    Shooter _shooter;

    void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    
    void Move()
    {
        Vector2 delta = _rawInput * _playerSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + _paddingLeft, _maxBounds.x - _paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + _paddingBottom, _maxBounds.y - _paddingTop);
        transform.position = newPosition;
    }

    void OnMove(InputValue inputValue) => _rawInput = inputValue.Get<Vector2>();

    void OnFire(InputValue inputValue) 
    { 
        if (_shooter != null)
        {
            _shooter.IsFiring = inputValue.isPressed;
        }
    }
}
