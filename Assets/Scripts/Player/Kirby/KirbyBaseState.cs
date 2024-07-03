namespace Player.Kirby
{
    public abstract class KirbyBaseState
    {
        protected KirbyStateMachine _context;
        protected KirbyStateMachineFactory _factory;

        public KirbyBaseState(KirbyStateMachine context, KirbyStateMachineFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
        public abstract void TransitionSwitchStates();
        public abstract void AnimateState();
        
        protected void SwitchStates(KirbyBaseState newState)
        {
            ExitState();
            newState.EnterState();
            _context.CurrentState = newState;
        }
    }
}