using System;
using Player.Kirby;
using StateMachine;
using UnityEngine;

public class KirbyStateMachine : MonoBehaviour, IStateMachine
{
    //Collisions
    private BoxCollider2D _boxCollider;
    
    // State Machine
    private KirbyStateMachineFactory _factory;
    private KirbyBaseState _currentState;
    
    //Public getters and setters
    public KirbyBaseState CurrentState { get => _currentState; set => _currentState = value; }
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        
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
