using UnityEngine;
using System.Collections.Generic;
using RTS.Orders;

namespace RTS.Entities {
    public class Building : EntityComponent
    {
        public GameObject prefab_rallyFlag;
        public Vector3 rallyPoint = Vector3.zero;

        private Color baseColor = Color.white;
        public Color focusColor = Color.green;
        public Material material;

        private GameObject rallyFlagRef;

        public void Start()
        {
            material = GetComponent<MeshRenderer>().material;
            baseColor = material.color;
            if (!prefab_rallyFlag) prefab_rallyFlag = PrefabLoader.GetMoveArrow();
        }

        public void Update()
        {

        }

        
        public override void OnFocus(InteractionManager manager)
        {
            material.color = focusColor;
            if (rallyFlagRef)
            {
                rallyFlagRef.SetActive(true);
            } else
            {
                rallyFlagRef = Instantiate(prefab_rallyFlag, rallyPoint, prefab_rallyFlag.transform.rotation);
            }


            rallyFlagRef.transform.position = rallyPoint;
        }

        public override void OnSecondaryClickEntity(Entity thing, Vector3 point, bool additive = false)
        {
            SetRallyPoint(thing.transform.position);
        }

        public override void OnSecondaryClickOther(GameObject other, Vector3 pointer, bool additive = false)
        {
            SetRallyPoint(pointer);
        }

        public override void OnUnfocus(InteractionManager manager)
        {
            material.color = baseColor;
            if (rallyFlagRef)
            {
                rallyFlagRef.SetActive(false);
            }
        }

        public override void OnAssignOrder(Order order, bool additive = false) {
            if (order.orderType == OrderType.spawn) {
                if (additive) entity.entityDriver.AddOrder(order);
                else entity.entityDriver.ReplaceOrders(order);
            }
        }

        public void SetRallyPoint(Vector3 point)
        {
            rallyPoint = point;
            if (rallyFlagRef) rallyFlagRef.transform.position = rallyPoint;
        }

        public void SpawnUnit(GameObject prefab)
        {
            GameObject spawned = Instantiate(prefab, transform.position + (Vector3.right * 5), prefab.transform.rotation);
            Entity entityComponent = spawned.GetComponent<Entity>();
            Order moveOrder = new Order(entityComponent, OrderType.move);
            moveOrder.action = new Action_MoveTo(rallyPoint, moveOrder);
            entity.entityDriver.AddOrder(moveOrder);
        }
    }
}