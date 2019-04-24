using RTS2.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace RTS2.Orders
{
    [System.Serializable]
    public class MoveToContext : OrderContext
    {
        [SerializeField] public Vector3 moveTarget;

        public MoveToContext(EntityAgent agent, Vector3 target) : base(agent, target) {
            //
        }
    }

    [CreateAssetMenu(fileName = "New MoveTo", menuName = "RTS2/Orders/MoveTo")]
    public class MoveTo : OrderBehaviour
    {
        [SerializeField] private float pathClosedDistance = 0.2f;
        [SerializeField] private float maxSampleDistance = 50.0f;
        [SerializeField] private int areaMask = -1;

        public MoveTo() : base("MoveTo") {

        }

        public override void Execute(OrderContext context) {
            MoveToContext ctx = context as MoveToContext;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(ctx.targetPosition, out hit, maxSampleDistance, areaMask)) {
                ((MoveToContext)context).moveTarget = hit.position;
                context.agent.NavMeshAgent.SetDestination(hit.position);
                context.isComplete = false;
            } else {
                context.isComplete = true;
            }
        }

        public override bool UpdateBehaviour(OrderContext context) {
            if (context.isComplete) return true;

            float distance = Vector3.Distance(context.agent.transform.position, ((MoveToContext)context).moveTarget);

            bool pathComplete = (!context.agent.NavMeshAgent.pathPending && !context.agent.NavMeshAgent.hasPath);
            if (pathComplete || distance <= pathClosedDistance) {
                context.isComplete = true;
            }
            return context.isComplete;
        }

        public override bool IsValidTarget(EntityAgent agent, Entity target) {
            return IsValidTarget(agent, target.transform.position);
        }

        public override bool IsValidTarget(EntityAgent agent, Entity[] target) {
            if (target.Length == 0) return false;

            Vector3 avgLocation = Vector3.zero;
            foreach (Entity e in target) avgLocation += e.transform.position;
            avgLocation /= target.Length;

            return IsValidTarget(agent, avgLocation);
        }

        public override bool IsValidTarget(EntityAgent agent, Vector3 target) {
            NavMeshHit hit;
            return NavMesh.SamplePosition(target, out hit, maxSampleDistance, areaMask);
        }

        public override OrderContext CreateContext(EntityAgent angent, Entity target) {
            return new MoveToContext(angent, target.transform.position);
        }

        public override OrderContext CreateContext(EntityAgent agent, Entity[] target) {
            Vector3 pos = Vector3.zero;
            foreach (Entity e in target) pos += e.transform.position;
            pos /= target.Length;

            return new MoveToContext(agent, pos);
        }

        public override OrderContext CreateContext(EntityAgent agent, Vector3 target) {
            return new MoveToContext(agent, target);
        }

        public override void Cancel(OrderContext context) {
            context.agent.NavMeshAgent.ResetPath();
            context.isComplete = true;
        }
    }
}
