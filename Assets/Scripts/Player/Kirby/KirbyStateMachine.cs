using System;
using System.Numerics;
using Player.Kirby;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class KirbyStateMachine : MonoBehaviour, IStateMachine
{
    //Collisions
    private BoxCollider2D _boxCollider;
    
    // Animator
    private Animator _animator;
    
    // Sprite Renderer
    private SpriteRenderer _renderer;
    
    // State Machine
    private KirbyStateMachineFactory _factory;
    private KirbyBaseState _currentState;
    
    //Input
    private PlayerInput _playerInput;
    private InputAction _moveVector;
    private InputAction _jump;
    
    // Physics
    private Vector2 _cMoveVector;
    private Vector2 _velocity;
    private float _direction;
    private float _speed = 5f;
    private float _jumpForce = 10f;
    
    //Layermask
    private LayerMask _groundLayer;
    
    //Bools
    private bool _inputDisabled = false;
    private bool _onCutscene = false;
    
    //Public getters and setters
    public KirbyBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public BoxCollider2D BoxCollider { get => _boxCollider; set => _boxCollider = value; }
    public Vector2 MoveVector { get => !_onCutscene ? _moveVector.ReadValue<Vector2>() : _cMoveVector; set => _cMoveVector = value; }
    public float Direction { get => _direction; set => _direction = value; }
    public Vector2 Velocity { get => _velocity; set => _velocity = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    public InputAction Jump { get => _jump; set => _jump = value; }
    public Animator KirbyAnimator { get => _animator; set => _animator = value; }
    public LayerMask GroundLayer { get => _groundLayer; set => _groundLayer = value; }
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        
        //Input Setup
        _playerInput = GameObject.FindWithTag("Controller Manager").GetComponent<PlayerInput>();
        _playerInput.SwitchCurrentActionMap("Player");
        _moveVector = _playerInput.actions["Move"];
        Debug.Log("_moveVector: " + _moveVector.name);
        _jump = _playerInput.actions["Jump"];
        
        //State Machine setup
        _factory = new KirbyStateMachineFactory(this);
        _currentState = _factory.Idle();
        _currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        SetSpriteOrientation();
        _currentState.UpdateState();
    }

    private void LateUpdate()
    {
        _currentState.AnimateState();
    }

    private void SetSpriteOrientation()
    {
        if (_direction < 0f)
        {
            _renderer.flipX = true;
        }
        else if (_direction > 0f)
        {
            _renderer.flipX = false;
        }
    }
    

    public void SetOnCutscene(bool value)
    {
        throw new NotImplementedException();
    }

    public void SetCMoveVector(Vector2 value)
    {
        throw new NotImplementedException();
    }
}
