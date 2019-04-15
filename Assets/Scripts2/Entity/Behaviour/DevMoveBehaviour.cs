using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RTS2.Entities.Behaviours
{
    class DevMoveBehaviour : EntityBehaviour
    {
        static BehaviourDependency[] dependencies = {
            new BehaviourDependency() {
                behaviourType = typeof(NavMeshNavigationBehaviour)
            }
        };

        NavMeshNavigationBehaviour navMeshNavigation;

        public DevMoveBehaviour() : base(dependencies) {
            //
        }

        public override void Initialize() {
            navMeshNavigation = (NavMeshNavigationBehaviour)entity.GetBehaviour(typeof(NavMeshNavigationBehaviour));
        }

        public override void OnSetActionTargetLocation(Vector3 location) {
            navMeshNavigation.SetDestination(location);
        }
    }
}
