using System;
using UnityEngine;

namespace Player.Kirby.States
{
    public class KirbyIdleState : KirbyBaseState
    {
        public KirbyIdleState(KirbyStateMachine context, KirbyStateMachineFactory factory) : base(context, factory)
        {
        }

        public override void EnterState()
        {

        }

        public override void UpdateState()
        {
            TransitionSwitchStates();
        }

        public override void ExitState()
        {

        }

        public override void TransitionSwitchStates()
        {
            if (_context.MoveVector.x  < 0f || _context.MoveVector.x > 0f)
            {
                Debug.Log("Move X: " + _context.MoveVector.x);
                SwitchStates(_factory.Walking());
            }

            if (_context.MoveVector.y < 0f)
            {
                Debug.Log("Move Y: " + _context.MoveVector.y);
                SwitchStates(_factory.Crouching());
            }
        }

        public override void AnimateState()
        {
            _context.KirbyAnimator.Play("kirby_idle");
        }
    }
}