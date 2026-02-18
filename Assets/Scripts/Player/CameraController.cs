using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform _pivot;
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _sensitivity = 0.1f;
    [SerializeField] private float _minPitch = -20f;
    [SerializeField] private float _maxPitch = 60f;

    private PlayerInputActions _inputActions;
    private float _yaw;
    private float _pitch = 15f;

    void Awake() {
        _inputActions = new PlayerInputActions();
    }

    void OnEnable() {
        _inputActions.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable() {
        _inputActions.Disable();
    }

    void LateUpdate() {
        Vector2 delta = _inputActions.PlayerActionmap.MouseLook.ReadValue<Vector2>();

        _yaw += delta.x * _sensitivity;
        _pitch -= delta.y * _sensitivity;
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        // Rotate the pivot in local space.
        // Because CameraPivot is a child of Player, and GravityBody keeps
        // Player.up = planet surface normal, local Y here IS the surface normal.
        _pivot.localRotation = Quaternion.Euler(_pitch, _yaw, 0f);

        // Pull camera back behind the pivot and look toward it.
        // localRotation = identity means the camera's forward = pivot's forward = looks at pivot.
        transform.localPosition = new Vector3(0f, 0f, -_distance);
        transform.localRotation = Quaternion.identity;
    }
}