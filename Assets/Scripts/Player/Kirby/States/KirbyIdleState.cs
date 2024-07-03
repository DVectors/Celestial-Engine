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
            Debug.Log("Move: " + _context.MoveVector.magnitude);
            if (_context.MoveVector.magnitude > 0.1f)
            {
                SwitchStates(_factory.Walking());
            }
        }

        public override void AnimateState()
        {
            _context.KirbyAnimator.Play("kirby_idle");
        }
    }
}