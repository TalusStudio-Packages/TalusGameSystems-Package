using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    public abstract class BaseDecision : BaseSO
    {
        public abstract bool Decide(StateMachine stateMachine);
    }
}
