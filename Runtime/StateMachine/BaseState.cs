using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    public abstract class BaseState : BaseSO
    {
        public abstract void OnEnter(StateMachine stateMachine);
        public abstract void OnExit(StateMachine stateMachine);
        public abstract void OnUpdate(StateMachine stateMachine);
        public abstract void OnFixedUpdate(StateMachine stateMachine);
    }
}