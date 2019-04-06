using System.Collections;
using System.Collections.Generic;
using RTS.Orders;
using UnityEngine;

namespace RTS.Entities {
	public enum ResourceType {
		wood	= 0,
		stone	= 1,
		coal	= 2,
		iron	= 3,
	};

	public class Resource : EntityComponent {
		public GameObject depletedObject;
		public ResourceType resourceType;

		[Range(100, 10000)]
		public int resourceContent;

		public override void OnFocus(InteractionManager manager) {
			//
		}

		public override void OnUnfocus(InteractionManager manager) {
			//
		}
		public override void OnSecondaryClickEntity(Entity thing, Vector3 point, bool additive = false)
		{
			//
		}

		public override void OnSecondaryClickOther(GameObject other, Vector3 point, bool additive = false)
		{
			//
		}

        public override void OnAssignOrder(Order order, bool additive = false) {
            // 
        }

        public int TakeResources(int extractionRate) {
			int extracted = 0;
			if (this.resourceContent > 0) {
				this.resourceContent -= extractionRate;
				if (this.resourceContent <= 0) {
					OnDepleted();
					extracted = extractionRate + this.resourceContent;
					this.resourceContent = 0;
				} else extracted = extractionRate;
			}
			return extracted;
		}


		public void OnDepleted() {
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
			if (depletedObject) depletedObject.SetActive(true);
		}
	}
}