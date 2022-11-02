using UnityEngine;
using UnityEngine.AI;

using Sirenix.OdinInspector;

using TalusFramework.Collections;

using TalusGameSystems.StateMachine;

namespace TalusGameSystems.NavMesh.Actions
{
    [CreateAssetMenu(fileName = "New Patrol Action", menuName = "Systems/NavMesh/Actions/Patrol")]
    public class PatrolAction : BaseAction
    {
        [Required, AssetList]
        private GameObjectCollection Patrols;

        private int _NextPatrolPoint = 0;

        public override void Execute(StateMachine.StateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            agent.SetDestination(Patrols[_NextPatrolPoint].transform.position);
            
            if (agent.pathPending)
            {
                return;
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                _NextPatrolPoint = (_NextPatrolPoint + 1) % Patrols.Count;
            }
        }
    }
}
