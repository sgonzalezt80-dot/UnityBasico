using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    private Vector2 _input;

    private PlayerInput _playerInput; 

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>(); 
    }

    void Update()
    {
        readInput();

        Debug.Log("Input : " + _input);
    }

    private void readInput()
    {
        _input = _playerInput.actions["Move"].ReadValue<Vector2>(); 
    }
}
