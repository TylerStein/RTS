using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.Orders {
    public class Action_Spawn : OrderAction
    {
        public Entity spawner;
        public GameObject entityPrefab;

        public const float spawnSeconds = 1.0f;
        private float spawnTimer = 0.0f;

        public Action_Spawn(Entity _spawner, GameObject _entityPrefab, Order _order) : base(_order)
        {
            spawner = _spawner;
            entityPrefab = _entityPrefab;
        }

        public override string GetDesctiptor() {
            return string.Format("Order (type={0}, prefab={1}, destination={2}", order.orderType.ToString(), entityPrefab.name, spawner.ToString()); 
        }

        
        public override void Execute() {
            isExecuted = true;
            isComplete = false;
            spawnTimer = 0.0f;
        }

        public override void Update() {
            if (spawnTimer < spawnSeconds) {
                spawnTimer += Time.deltaTime;
            } else {
                spawnTimer = spawnSeconds;
            }
        }

        public override void Cancel() {
            spawnTimer = 0;
            isExecuted = false;
            isComplete = false;
        }
    }
}