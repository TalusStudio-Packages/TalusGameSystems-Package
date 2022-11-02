using Sirenix.OdinInspector;

using TalusFramework.References;

using UnityEngine;
using UnityEngine.AI;

using TalusGameSystems.StateMachine;

namespace TalusGameSystems.NavMesh
{
    [CreateAssetMenu(fileName = "New Chase Action", menuName = "Systems/NavMesh/Actions/Chase")]
    public class ChaseAction : BaseAction
    {
        [LabelWidth(40)]
        public GameObjectReference Target;
        
        public override void Execute(StateMachine.StateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            agent.SetDestination(Target.Value.transform.position);
        }
    }
}