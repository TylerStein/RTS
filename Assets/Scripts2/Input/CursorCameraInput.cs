using UnityEngine;
using System.Collections;

public class CursorCameraInput : MonoBehaviour
{
    public Vector3 lastScreenMousePosition = Vector3.zero;
    public Vector3 lastWorldMouse = Vector3.zero;
    public Vector3 mouseForward = Vector3.zero;

    public float worldMouseDistance = 5.0f;
    public float maxHitDistance = 50;

    public Camera inputCamera;

    private Transform _cameraTransform;

    void Start() {
        lastScreenMousePosition = Vector3.zero;
        inputCamera = Camera.main;
        _cameraTransform = inputCamera.transform;
    }

    void Update() {
        lastScreenMousePosition = Input.mousePosition;

        lastWorldMouse = inputCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, worldMouseDistance));
        mouseForward = (lastWorldMouse - _cameraTransform.position).normalized;
    }

    public bool Raycast(out RaycastHit hit) {
        return Physics.Raycast(_cameraTransform.position, mouseForward, out hit, maxHitDistance, 1 << 0);
    }
}
