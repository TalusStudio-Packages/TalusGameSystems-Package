using System.Collections.Generic;

using UnityEngine;

namespace TalusGameSystems.StateMachine
{
    [CreateAssetMenu(fileName = "New State", menuName = "Systems/State Machine/State")]
    public class State : BaseState
    {
        [SerializeField]
        public List<BaseAction> _actions;
        
        [SerializeField]
        public List<Transition> _transitions;
        
        public override void Execute(StateMachine stateMachine)
        {
            for (int i = 0; i < _actions.Count; ++i)
            {
                _actions[i].Execute(stateMachine);
            }
            
            for (int i = 0; i < _transitions.Count; ++i)
            {
                _transitions[i].Execute(stateMachine);
            }
        }
    }
}