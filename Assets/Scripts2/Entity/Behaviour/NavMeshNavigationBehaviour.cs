using UnityEngine;
using UnityEngine.AI;

namespace RTS2.Entities.Behaviours
{
    class NavMeshNavigationBehaviour : EntityBehaviour
    {
        public NavMeshAgent navMeshAgent;

        public NavMeshNavigationBehaviour() : base() {
            //
        }

        public bool SetDestination(Vector3 dest) {
            return navMeshAgent.SetDestination(dest);
        }
    }
}
