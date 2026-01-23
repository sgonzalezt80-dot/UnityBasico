using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _speedMultiplier;
    private float _newSpeed; 
    
    private Vector2 _input;
    private Vector2 _fixedInput; 
    private Vector2 _currentVelocity = Vector2.zero;
    private float _isRunning;

    private Rigidbody2D _rb2D;
    private PlayerInput _playerInput; 

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        _playerInput = GetComponent<PlayerInput>(); 
    }

    void Update()
    {
        readInput();
        ApplySpeed();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void readInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
        _isRunning = _playerInput.actions["Run"].ReadValue<float>();
    }

    private void ApplySpeed()
    {
        if(_isRunning != 0)
        {
            _newSpeed = _playerSpeed * _speedMultiplier;
        }
        else
        {
            _newSpeed = _playerSpeed;
        }
    }

    private void Move()
    {
        //transform.position += new Vector3(_input.x, _input.y, 0)* _playerSpeed * Time.deltaTime; 

        //_rb2D.linearVelocity = new Vector3(_input.x, _input.y, 0) *_playerSpeed ;

        //_rb2D.MovePosition(_rb2D.position + new Vector2(_input.x, _input.y) * _playerSpeed * Time.fixedDeltaTime); 

        //_rb2D.AddForce(new Vector2(_input.x, _input.y) * _playerSpeed);
        
            //SmoothDamp(posActual, posObjetivo, ref velActual, tiempoLlegar)
        _fixedInput = Vector2.SmoothDamp(_fixedInput, _input, ref _currentVelocity, _smoothTime);

        _rb2D.MovePosition(_rb2D.position + _fixedInput * _newSpeed * Time.fixedDeltaTime);
    }
}
