using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Systems/State Machine/Transition")]
    public class Transition : BaseSO
    {
        [Required] public BaseDecision Decision;
        [Required] public BaseState TargetState;

        public bool CheckDecision(StateMachine stateMachine)
        {
            return Decision.Decide(stateMachine);
        }
    }
}