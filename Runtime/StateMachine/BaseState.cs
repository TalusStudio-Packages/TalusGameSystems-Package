using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    public abstract class BaseState : BaseSO
    {
        public abstract void Execute(StateMachine stateMachine);
    }
}