using UnityEngine;

namespace TalusGameSystems.StateMachine
{
    [CreateAssetMenu(fileName = "New State", menuName = "Systems/State Machine/State")]
    public class State : BaseState
    {
        [Header("Actions")]
        [SerializeField] private BaseAction[] _enterActions;
        [SerializeField] private BaseAction[] _exitActions;
        [SerializeField] private BaseAction[] _updateActions;
        
        [Header("Transitions")]
        [SerializeField] BaseAction[] _transitions;

        public override void OnEnter(StateMachine stateMachine)
        {
            PlayActions(_enterActions, stateMachine);
        }

        public override void OnExit(StateMachine stateMachine)
        {
            PlayActions(_exitActions, stateMachine);
        }

        public override void OnUpdate(StateMachine stateMachine)
        {
            PlayActions(_updateActions, stateMachine);

            for (int i = 0; i < _transitions.Length; ++i)
            {
                _transitions[i].Execute(stateMachine);
            }
        }

        private void PlayActions(BaseAction[] actions, StateMachine stateMachine)
        {
            for (int i = 0; i < actions.Length; ++i)
            {
                actions[i].Execute(stateMachine);
            }
        }
    }
}