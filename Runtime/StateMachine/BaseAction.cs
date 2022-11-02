using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    public abstract class BaseAction : BaseSO
    {
        public abstract void Execute(StateMachine stateMachine);
    }
}