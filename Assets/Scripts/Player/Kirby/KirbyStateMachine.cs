using Player.Kirby;
using UnityEngine;

public class KirbyStateMachine : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    
    // State Machine
    private KirbyStateMachineFactory _factory;
    private KirbyBaseState _currentState;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        
        //State Machine setup
        _factory = new KirbyStateMachineFactory(this);
        _currentState = _factory.Idle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
