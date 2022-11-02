using UnityEngine;
using UnityEngine.AI;

using Sirenix.OdinInspector;

using TalusFramework.References;

using TalusGameSystems.StateMachine;

namespace TalusGameSystems.NavMesh
{
    [CreateAssetMenu(fileName = "New Update Agent Rotation Action", menuName = "Systems/NavMesh/Actions/Update Agent Rotation")]
    public class UpdateAgentRotationAction : BaseAction
    {
        [LabelWidth(100f)]
        public BoolReference UpdateRotation;
        
        public override void Execute(StateMachine.StateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            agent.updateRotation = UpdateRotation;
        }
    }
}
