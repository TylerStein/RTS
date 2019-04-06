using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimator : MonoBehaviour {
	public float verticalMovement = 0.25f;
	public float degPerSecond = 180f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, degPerSecond * Time.deltaTime);
	}
}
