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
            var direction = new Vector2(_context.MoveVector.x, _context.MoveVector.y);
            _context.transform.Translate(direction * (_context.Speed * Time.deltaTime));
            
            TransitionSwitchStates();
        }

        public override void ExitState()
        {

        }

        public override void TransitionSwitchStates()
        {
            Debug.Log("Move: " + _context.MoveVector.magnitude);
            if (_context.MoveVector.magnitude < 0.1f)
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