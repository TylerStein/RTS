using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickContext {
	public bool hasPoint;
	public bool hasObject;

	private Vector3 point;
	private GameObject thing;

	public Vector3 Point {
		get {
			return point;
		}
		set {
			hasPoint = true;
			point = value;
		}
	}

	public GameObject Thing {
		get {
			return thing;
		}
		set {
			hasObject = true;
			thing = value;
		}
	}

	public ClickContext() {
		hasPoint = false;
		hasObject = false;
	}

	public ClickContext(GameObject obj) {
		thing = obj;
		hasObject = true;
		hasPoint = false;
	}

	public ClickContext(GameObject obj, Vector3 pnt) {
		thing = obj;
		point = pnt;
		hasObject = true;
		hasPoint = true;
	}
}
[RequireComponent(typeof(Player))]
public class MouseInteraction : MonoBehaviour {
	public MousePosition mousePosition;
	private Player _player;

	public float maxDistance = 100;
	public Transform tr;
	public Camera cam;

	public Vector3 rayHitPos = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
		_player = GetComponent<Player>();
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast(tr.position, mousePosition.mouseForward, out hit, maxDistance, 1 << 0)) {
			rayHitPos = hit.point;
			ClickContext ctx = new ClickContext(hit.collider.gameObject, rayHitPos);
			bool shifted = Input.GetButton("Shift");
			if (Input.GetButtonDown("Primary")) {
				_player.InteractionManager.ResolvePrimaryClick(ctx, shifted);
			} else if (Input.GetButtonDown("Secondary")) {
				_player.InteractionManager.ResolveSecondaryClick(ctx, shifted);
			}
		} else {
			bool shifted = Input.GetButton("Shift");
			if (Input.GetButtonDown("Primary")) {
				_player.InteractionManager.ResolvePrimaryClick(new ClickContext(), shifted);
			} else if (Input.GetButtonDown("Secondary")) {
				_player.InteractionManager.ResolveSecondaryClick(new ClickContext(), shifted);
			}
			rayHitPos = tr.position + (mousePosition.mouseForward * maxDistance);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(rayHitPos, 0.15f);
	}
}
