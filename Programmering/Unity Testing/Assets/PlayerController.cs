using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 350f;
    public float rotationSpeed = 12f;

    [Header("Camera")]
    public Transform cameraTransform;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // New Unity 6 physics fields
        rb.mass = 5f;
        rb.linearDamping = 0.5f;         // replaces drag
        rb.angularDamping = 0.5f;        // replaces angularDrag

        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Camera-relative directions
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 movement = camForward * v + camRight * h;

        if (movement.sqrMagnitude > 1f)
            movement.Normalize();

        // Physics-based movement
        rb.AddForce(movement * moveForce, ForceMode.Force);

        // Rotate toward movement direction
        if (movement.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(movement);
            Quaternion smoothRot = Quaternion.Slerp(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(smoothRot);
        }
    }
}
