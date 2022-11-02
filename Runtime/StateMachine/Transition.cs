using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusGameSystems.StateMachine
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Systems/State Machine/Transition")]
    public class Transition : BaseSO
    {
        public BaseDecision Decision => _decision;
        
        [Required, AssetList] 
        [SerializeField] private BaseDecision _decision;

        public BaseState TargetState => _targetState;
        
        [Required, AssetList] 
        [SerializeField] private BaseState _targetState;

        public bool IsSatisfy(StateMachine stateMachine)
        {
            return _decision.Decide(stateMachine);
        }
    }
}