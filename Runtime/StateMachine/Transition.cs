using UnityEngine;

using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Systems/State Machine/Transition")]
    public class Transition : BaseSO
    {
        public BaseDecision Decision;
        public BaseState TargetState;

        public void Execute(StateMachine stateMachine)
        {
            if (Decision.Decide(stateMachine) && stateMachine.CurrentState != TargetState)
            {
                stateMachine.CurrentState = TargetState;
            }
        }
    }
}