using UnityEngine;
using UnityEngine.AI;

using Sirenix.OdinInspector;

using TalusFramework.References;

using TalusGameSystems.StateMachine;

namespace TalusGameSystems.NavMesh
{
    [CreateAssetMenu(fileName = "New Look Target Action", menuName = "Systems/NavMesh/Actions/Look Target")]
    public class RotateToTargetAction : BaseAction
    {
        [LabelWidth(50)]
        public FloatReference Speed;
        
        public override void Execute(StateMachine.StateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            
            Transform agentTransform = agent.transform;
            
            Vector3 direction = (agent.steeringTarget - agentTransform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            agentTransform.rotation = Quaternion.Lerp(agentTransform.rotation, lookRotation, Time.deltaTime * Speed.Value);
        }
    }
}
