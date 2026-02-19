using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform visualMesh;
    [SerializeField] private Animator animator;

    private const float GroundCheckRadius = 0.3f;
    private const float Speed = 8f;
    private const float JumpForce = 8f;
    private const float VisualRotationSpeed = 10f;

    private Rigidbody _rigidbody;
    private GravityBody _gravityBody;
    private PlayerInputActions _inputActions;

    private Vector2 _moveInput;
    private bool _jumpRequested;

    private void Awake() => _inputActions = new PlayerInputActions();

    private void OnEnable() {
        _inputActions.Enable();
        _inputActions.PlayerActionmap.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable() {
        _inputActions.PlayerActionmap.Jump.performed -= OnJumpPerformed;
        _inputActions.Disable();
    }

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _gravityBody = GetComponent<GravityBody>();
    }

    private void OnJumpPerformed(InputAction.CallbackContext context) {
        if (Physics.CheckSphere(groundCheck.position, GroundCheckRadius, groundMask)) _jumpRequested = true;
    }

    private void Update() {
        _moveInput = _inputActions.PlayerActionmap.Movement.ReadValue<Vector2>();
        var isGrounded = Physics.CheckSphere(groundCheck.position, GroundCheckRadius, groundMask);
        if (animator) animator.SetBool(IsJumping, !isGrounded);
    }

    private void FixedUpdate() {
        var isRunning = _moveInput.magnitude > 0.1f;
        if (isRunning) {
            var camForward = Vector3.ProjectOnPlane(cam.forward, transform.up).normalized;
            var camRight = Vector3.ProjectOnPlane(cam.right, transform.up).normalized;
            var moveDir = (camForward * _moveInput.y + camRight * _moveInput.x).normalized;
            _rigidbody.MovePosition(_rigidbody.position + moveDir * (Speed * Time.fixedDeltaTime));
            if (visualMesh) {
                var targetRot = Quaternion.LookRotation(moveDir, transform.up);
                visualMesh.rotation = Quaternion.Slerp(
                    visualMesh.rotation, targetRot, Time.fixedDeltaTime * VisualRotationSpeed
                );
            }
        }

        if (_jumpRequested) {
            _rigidbody.AddForce(-_gravityBody.GravityDirection * JumpForce, ForceMode.VelocityChange);
            _jumpRequested = false;
        }

        if (animator) animator.SetBool(IsRunning, isRunning);
    }
}