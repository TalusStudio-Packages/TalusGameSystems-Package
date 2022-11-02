using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Systems/State Machine/Transition")]
    public class Transition : BaseSO
    {
        [Required, AssetList] public BaseDecision Decision;
        [Required, AssetList] public BaseState TargetState;

        public bool IsSatisfy(StateMachine stateMachine)
        {
            return Decision.Decide(stateMachine);
        }
    }
}