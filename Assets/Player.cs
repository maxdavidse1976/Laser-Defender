using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 5;
    Vector2 _rawInput;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 delta = _rawInput;
        transform.position += delta * _playerSpeed * Time.deltaTime;
    }

    void OnMove(InputValue inputValue) 
    { 
        _rawInput = inputValue.Get<Vector2>();
        Debug.Log(_rawInput);
    }
}
