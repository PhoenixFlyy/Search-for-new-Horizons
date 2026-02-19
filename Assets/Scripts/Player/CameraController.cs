using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform pivot;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float sensitivity = 0.15f;
    [SerializeField] private float minPitch = -20f;
    [SerializeField] private float maxPitch = 60f;

    private PlayerInputActions _inputActions;
    private float _pitch = 15f;
    private Vector3 _camForwardWorld;

    private void Awake() => _inputActions = new PlayerInputActions();
    private void OnDisable() => _inputActions.Disable();
    
    private void OnEnable() {
        _inputActions.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start() => _camForwardWorld = pivot.parent.forward;

    private void LateUpdate() {
        var delta = _inputActions.PlayerActionmap.MouseLook.ReadValue<Vector2>();
        var planetUp = pivot.parent.up;
        
        _camForwardWorld = Vector3.ProjectOnPlane(_camForwardWorld, planetUp).normalized;
        _camForwardWorld = Quaternion.AngleAxis(delta.x * sensitivity, planetUp) * _camForwardWorld;
        
        _pitch -= delta.y * sensitivity;
        _pitch  = Mathf.Clamp(_pitch, minPitch, maxPitch);
        
        var yawRot = Quaternion.LookRotation(_camForwardWorld, planetUp);
        pivot.rotation   = yawRot * Quaternion.Euler(_pitch, 0f, 0f);
        
        transform.localPosition = new Vector3(0f, 0f, -distance);
        transform.localRotation = Quaternion.identity;
    }
}
