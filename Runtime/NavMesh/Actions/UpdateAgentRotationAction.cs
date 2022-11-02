using UnityEngine;
using UnityEngine.AI;

using TalusGameSystems.StateMachine;

namespace TalusGameSystems.NavMesh
{
    [CreateAssetMenu(fileName = "New Update Agent Rotation Action", menuName = "Systems/NavMesh/Actions/Update Agent Rotation")]
    public class UpdateAgentRotationAction : BaseAction
    {
        public bool UpdateRotation;
        
        public override void Execute(StateMachine.StateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            agent.updateRotation = UpdateRotation;
        }
    }
}
