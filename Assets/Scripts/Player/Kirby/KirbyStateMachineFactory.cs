using System.Collections.Generic;
using Player.Kirby;
using Player.Kirby.States;
using Player.States;
using UnityEngine;

public class KirbyStateMachineFactory
{
    private KirbyStateMachine _context;
    private Dictionary<PlayerStates, KirbyBaseState> _states = new Dictionary<PlayerStates, KirbyBaseState>();

    public KirbyStateMachineFactory(KirbyStateMachine context)
    {
        _context = context;

        _states[PlayerStates.IDLE] = new KirbyIdleState(context, this);
        _states[PlayerStates.WALKING] = new KirbyWalkingState(context, this);
        _states[PlayerStates.RUNNING] = new KirbyRunningState(context, this);
        _states[PlayerStates.JUMPING] = new KirbyJumpingState(context, this);
        _states[PlayerStates.FALLING] = new KirbyFallingState(context, this);
        _states[PlayerStates.LANDING] = new KirbyLandingState(context, this);
    }

    public KirbyBaseState Idle()
    {
        return _states[PlayerStates.IDLE];
    }
    
    public KirbyBaseState Walking()
    {
        return _states[PlayerStates.WALKING];
    }
    
    public KirbyBaseState Running()
    {
        return _states[PlayerStates.RUNNING];
    }
    
    public KirbyBaseState Jumping()
    {
        return _states[PlayerStates.JUMPING];
    }
    
    public KirbyBaseState Falling()
    {
        return _states[PlayerStates.FALLING];
    }
    
    public KirbyBaseState Landing()
    {
        return _states[PlayerStates.LANDING];
    }
}
