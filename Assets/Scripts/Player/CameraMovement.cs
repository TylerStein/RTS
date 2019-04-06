using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float moveSpeed = 12;
	public float rotationSpeed = 45;
	public float mouseThreshold = 0.75f;

	public Vector2 input;
	public float inputRotation;
	public Vector3 mousePosition;
	
	public Vector2 absInput;

	private Transform tr;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		inputRotation = Input.GetAxis("Rotation");

		// key rotate
		Vector3 rotationPoint = tr.position + tr.forward * 15;
		RaycastHit rh;
		if (Physics.Raycast(tr.position, tr.forward, out rh, 500, 1 << 0)) {
			// Debug.DrawLine(tr.position, rh.point, Color.white, Time.deltaTime);
			rotationPoint = rh.point;
		}
		float rotationAmount = rotationSpeed * inputRotation * Time.deltaTime;

		tr.RotateAround(rotationPoint, Vector3.up, rotationAmount);

		// Forward
		Vector3 forwardPos = tr.position + tr.forward * 2.0f;
		forwardPos.y = tr.position.y;
		Vector3 forwardMove = (forwardPos - tr.position).normalized * input.y * moveSpeed;

		// Right
		Vector3 rightMove = tr.right * input.x * moveSpeed;
		
		tr.position += (rightMove + forwardMove) * Time.deltaTime;
	}

	void OnDrawGizmos() {
		// Gizmos.color = Color.red;
		// Gizmos.DrawLine(tr.position, tr.position + tr.right * moveSpeed);

		// Vector3 forwardPos = tr.position + tr.forward * 2.0f;
		// forwardPos.y = tr.position.y;
		// Vector3 forwardDir = (forwardPos - tr.position).normalized;

		// Gizmos.color = Color.blue;
		// Gizmos.DrawLine(tr.position, tr.position + forwardDir * moveSpeed);

		// Gizmos.color = Color.green;
		// Gizmos.DrawLine(tr.position, tr.position + Vector3.up * moveSpeed);
	}
}
