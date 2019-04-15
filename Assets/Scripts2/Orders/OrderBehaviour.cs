using UnityEngine;
using System.Collections;

using RTS2.Entities;
namespace RTS2.Orders
{
    public abstract class OrderBehaviour : ScriptableObject
    {
        [SerializeField] string behaviourName;

        [SerializeField] protected bool isExecuting;
        [SerializeField] protected OrderExecutionContext executionContext;
        [SerializeField] protected Entity entity;

        protected OrderBehaviour(string behaviourName = "NULL") {
            this.behaviourName = behaviourName;
        }

        public virtual void Execute() {
            //
        }

        public virtual void Cancel() {
            //
        }
    }
}