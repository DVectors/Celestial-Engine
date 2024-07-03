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
        public abstract void SwitchStates();
        public abstract void AnimateState();
    }
}