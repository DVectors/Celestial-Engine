using System;
using Player.Kirby;
using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class KirbyStateMachine : MonoBehaviour, IStateMachine
{
    //Collisions
    private BoxCollider2D _boxCollider;
    
    // State Machine
    private KirbyStateMachineFactory _factory;
    private KirbyBaseState _currentState;
    
    //Input
    private PlayerInput _playerInput;
    private InputAction _move;
    private InputAction _jump;
    
    
    //Public getters and setters
    public KirbyBaseState CurrentState { get => _currentState; set => _currentState = value; }
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        
        //Input Setup
        _playerInput = GameObject.FindWithTag("Controller Manager").GetComponent<PlayerInput>();
        _playerInput.SwitchCurrentActionMap("Player");
        _move = _playerInput.actions["Move"];
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
