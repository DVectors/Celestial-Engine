using UnityEngine;

namespace Player.Kirby.States
{
    public class KirbyWalkingState : KirbyBaseState
    {
        public KirbyWalkingState(KirbyStateMachine context, KirbyStateMachineFactory factory) : base(context, factory)
        {
        }

        public override void EnterState()
        {

        }

        public override void UpdateState()
        {
            _context.Direction = _context.MoveVector.x;
            _context.transform.Translate(new Vector2(_context.Direction, 0f) * (_context.Speed * Time.deltaTime));
            
            TransitionSwitchStates();
        }

        public override void ExitState()
        {

        }

        public override void TransitionSwitchStates()
        {
            Debug.Log("Move: " + _context.MoveVector.magnitude);
            if (_context.MoveVector.x == 0f)
            {
                SwitchStates(_factory.Idle());
            }
        }

        public override void AnimateState()
        {
            _context.KirbyAnimator.Play("kirby_walk");
        }
    }
}