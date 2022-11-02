using UnityEngine;
using UnityEngine.AI;

using TalusFramework.References;

using Sirenix.OdinInspector;

using TalusGameSystems.StateMachine;

namespace TalusGameSystems.NavMesh.Actions
{
    [CreateAssetMenu(fileName = "New Agent Activity Action", menuName = "Systems/NavMesh/Actions/Agent Activity")]
    public class SetAgentActivityAction : BaseAction
    {
        [LabelWidth(60)]
        public BoolReference IsStopped;

        public override void Execute(StateMachine.StateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            agent.isStopped = IsStopped;
        }
    }
}
