using UnityEngine;
using UnityEngine.AI;

using Sirenix.OdinInspector;

using TalusFramework.Collections;

using TalusGameSystems.StateMachine;

namespace TalusGameSystems.NavMesh
{
    [CreateAssetMenu(fileName = "New Patrol Action", menuName = "Systems/NavMesh/Actions/Patrol")]
    public class PatrolAction : BaseAction
    {
        [Required, AssetList]
        [SerializeField]
        private GameObjectCollection _patrols;

        private int _nextPatrolPoint = 0;

        public override void Execute(StateMachine.StateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            agent.SetDestination(_patrols[_nextPatrolPoint].transform.position);
            
            if (agent.pathPending)
            {
                return;
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                _nextPatrolPoint = (_nextPatrolPoint + 1) % _patrols.Count;
            }
        }
    }
}
