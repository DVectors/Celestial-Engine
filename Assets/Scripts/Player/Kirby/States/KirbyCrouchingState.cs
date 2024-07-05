namespace Player.Kirby.States
{
    public class KirbyCrouchingState : KirbyBaseState
    {
        public KirbyCrouchingState(KirbyStateMachine context, KirbyStateMachineFactory factory) : base(context, factory)
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
            if (_context.MoveVector.y == 0f)
            {
                SwitchStates(_factory.Idle());
            }
        }

        public override void AnimateState()
        {
            _context.KirbyAnimator.Play("kirby_crouch");
        }
    }
}