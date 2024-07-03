using UnityEngine;

namespace StateMachine
{
    public interface IStateMachine
    {
        void SetOnCutscene(bool value);
        void SetCMoveVector(Vector2 value);
    }
}