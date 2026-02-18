using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _cam; // Drag MainCamera here
    [SerializeField] private Animator _animator;

    private float _groundCheckRadius = 0.3f;
    private float _speed = 8f;
    private float _jumpForce = 8f;
    private float _rotationSpeed = 10f;

    private Rigidbody _rigidbody;
    private GravityBody _gravityBody;
    private PlayerInputActions _inputActions;

    private Vector2 _moveInput;
    private bool _jumpRequested;

    void Awake() {
        _inputActions = new PlayerInputActions();
    }

    void OnEnable() {
        _inputActions.Enable();
        _inputActions.PlayerActionmap.Jump.performed += OnJumpPerformed;
    }

    void OnDisable() {
        _inputActions.PlayerActionmap.Jump.performed -= OnJumpPerformed;
        _inputActions.Disable();
    }

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _gravityBody = GetComponent<GravityBody>();
    }

    void OnJumpPerformed(InputAction.CallbackContext context) {
        if (Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask))
            _jumpRequested = true;
    }

    void Update() {
        _moveInput = _inputActions.PlayerActionmap.Movement.ReadValue<Vector2>();

        bool isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        if (_animator != null) _animator.SetBool("isJumping", !isGrounded);
    }

    void FixedUpdate() {
        bool isRunning = _moveInput.magnitude > 0.1f;

        if (isRunning) {
            // Project camera axes onto the planet surface plane (perpendicular to player up)
            Vector3 camForward = Vector3.ProjectOnPlane(_cam.forward, transform.up).normalized;
            Vector3 camRight = Vector3.ProjectOnPlane(_cam.right, transform.up).normalized;

            // Combine into a single movement direction
            Vector3 moveDir = (camForward * _moveInput.y + camRight * _moveInput.x).normalized;

            // Move along surface
            _rigidbody.MovePosition(_rigidbody.position + moveDir * (_speed * Time.fixedDeltaTime));

            // Rotate player body to face movement direction (not camera direction)
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, transform.up);
            _rigidbody.MoveRotation(
                Quaternion.Slerp(_rigidbody.rotation, targetRotation, Time.fixedDeltaTime * _rotationSpeed)
            );
        }

        if (_jumpRequested) {
            _rigidbody.AddForce(-_gravityBody.GravityDirection * _jumpForce, ForceMode.VelocityChange);
            _jumpRequested = false;
        }

        if (_animator != null) _animator.SetBool("isRunning", isRunning);
    }
}