using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{   //Variables de Movimiento
    [Header("Movimiento")]
    [SerializeField] private int _playerSpeed;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _speedMultiplier;
    private float _newSpeed;

    //Variables de disparo
    [Header("Disparo")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _shootCooldown;
    private float _isShooting;
    private float _shootTimer;

    //Logica de movimiento
    private Vector2 _input;
    private Vector2 _fixedInput; 
    private Vector2 _currentVelocity = Vector2.zero;
    private float _isRunning;

    //componentes
    private Rigidbody2D _rb2D;
    private PlayerInput _playerInput;
    private Animator _animator;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        readInput();
        ApplySpeed();
        //Shoot();

        _shootTimer += Time.deltaTime;
        if(_shootTimer >= _shootCooldown)
        {
            _shootTimer = 0;
            Shoot();

        }
        _animator.SetFloat("InputX", _input.x);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void readInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>();
        _isRunning = _playerInput.actions["Run"].ReadValue<float>();
        _isShooting = _playerInput.actions["Shoot"].ReadValue<float>();

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
    private void Shoot()
    {
        if(_isShooting != 0)
        {
            Debug.Log("Disparando");
            Instantiate(_bullet, transform.position, transform.rotation);
        } 
    }
}
