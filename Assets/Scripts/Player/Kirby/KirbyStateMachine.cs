using System;
using Player.Kirby;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private bool _inputDisabled = false;
    private bool _onCutscene = false;
    
    // Physics
    private Vector2 _cMoveVector;
    private Vector2 _velocity;
    private float _speed = 5f;
    private float _jumpForce = 10f;
    
    //Layermask
    private LayerMask _groundLayer;
    
    //Public getters and setters
    public KirbyBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public BoxCollider2D BoxCollider { get => _boxCollider; set => _boxCollider = value; }
    public Vector2 MoveVector { get => !_onCutscene ? _moveVector.ReadValue<Vector2>() : _cMoveVector; set => _cMoveVector = value; }
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
        _currentState.UpdateState();
    }

    private void LateUpdate()
    {
        _currentState.AnimateState();
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
