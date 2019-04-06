using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 lastScreenMousePosition = Vector3.zero;
    public Vector3 lastWorldMouse = Vector3.zero;
    public Vector3 mouseForward = Vector3.zero;

    public float worldMouseDistance = 5.0f;

    public Camera inputCamera;

    private Transform _cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        lastScreenMousePosition = Vector3.zero;
        inputCamera = Camera.main;
        _cameraTransform = inputCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        lastScreenMousePosition = Input.mousePosition;

        lastWorldMouse = inputCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, worldMouseDistance));
		mouseForward = (lastWorldMouse - _cameraTransform.position).normalized;
    }
}
