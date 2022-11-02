using UnityEngine;

namespace TalusGameSystems.StateMachine
{
    [CreateAssetMenu(fileName = "New State", menuName = "Systems/State Machine/State")]
    public class State : BaseState
    {
        [SerializeField] BaseAction[] _actions;
        
        [SerializeField] BaseAction[] _transitions;
        
        public override void Execute(StateMachine stateMachine)
        {
            for (int i = 0; i < _actions.Length; ++i)
            {
                _actions[i].Execute(stateMachine);
            }
            
            for (int i = 0; i < _transitions.Length; ++i)
            {
                _transitions[i].Execute(stateMachine);
            }
        }
    }
}